using ContactMate.Bll.Dtos;
using ContactMate.Bll.FluentValidations;
using ContactMate.Core.Errors;
using ContactMate.Dal.Entities;
using ContactMate.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace ContactMate.Bll.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository ContactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        ContactRepository = contactRepository;
    }

    public async Task<long> AddContactAsync(ContactCreateDto contactCreateDto, long userId)
    {
        var contactValidator = new ContactCreateDtoValidator();
        var result = contactValidator.Validate(contactCreateDto);

        if (!result.IsValid)
        {
            var errors = "";
            foreach (var error in result.Errors)
            {
                errors = errors + "\n" + error.ErrorMessage;
            }
            throw new ValidationFailedException(errors);
        }

        var contact = new Contact()
        {
            FirstName = contactCreateDto.FirstName,
            LastName = contactCreateDto.LastName,
            FullName = contactCreateDto.FirstName + " " + contactCreateDto.LastName,
            Email = contactCreateDto.Email,
            PhoneNumber = contactCreateDto.PhoneNumber,
            Address = contactCreateDto.Address,
            CreatedAt = DateTime.UtcNow,
            UserId = userId,
        };

        var contactId = await ContactRepository.InsertContactAsync(contact);
        return contactId;
    }

    public async Task DeleteContactAsync(long contactId, long userId)
    {
        var contactOfUser = await ContactRepository.
            SelectAllContacts().FirstOrDefaultAsync(c => c.Id == contactId && c.UserId == userId);
        if (contactOfUser is null)
            throw new EntityNotFoundException($"Contact with contactId: {contactId} and userId: {userId} not found to delete");
        await ContactRepository.DeleteContactAsync(contactOfUser);
    }

    public async Task<ICollection<ContactDto>> GetAllContacstAsync(long userId)
    {
        var contacts = await ContactRepository.SelectAllUserContactsAsync(userId);

        var contactsDto = contacts.Select(contact => ConvertToContactDto(contact));
        return contactsDto.ToList();
    }

    private ContactDto ConvertToContactDto(Contact contact)
    {
        return new ContactDto()
        {
            ContactId = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            Address = contact.Address,
        };
    }

    public async Task<ContactDto> GetContacDtotByContacId(long contactId)
    {
        var contact = await ContactRepository.SelectContactByContactIdAsync(contactId);
        var contactDto = ConvertToContactDto(contact);
        return contactDto;
    }

    public async Task UpdateContactAsync(ContactDto contactDto, long userId)
    {
        var contactDtoValidator = new ContactDtoValidator();
        var result = contactDtoValidator.Validate(contactDto);

        if (!result.IsValid)
        {
            var errors = "";
            foreach (var error in result.Errors)
            {
                errors = errors + "\n" + error.ErrorMessage;
            }
            throw new ValidationFailedException(errors);
        }

        var contactOfUser = await ContactRepository.
            SelectAllContacts().FirstOrDefaultAsync(c => c.Id == contactDto.ContactId && c.UserId == userId);
        if (contactOfUser is null)
            throw new EntityNotFoundException($"Contact with contactId: {contactDto.ContactId} and userId: {userId} not found to update");

        var contact = new Contact()
        {
            FirstName = contactDto.FirstName,
            LastName = contactDto.LastName,
            FullName = contactDto.FirstName + " " + contactDto.LastName,
            Email = contactDto.Email,
            PhoneNumber = contactDto.PhoneNumber,
            Address = contactDto.Address,
            UserId = userId,
        };

        await ContactRepository.UpdateContactAsync(contact);
    }
}

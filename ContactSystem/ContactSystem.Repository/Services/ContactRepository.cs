using ContactSystem.Core.Errors;
using ContactSystem.Dal;
using ContactSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactSystem.Repository.Services;

public class ContactRepository : IContactRepository
{
    private readonly MainContext MainContext;

    public ContactRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }
    
    public async Task DeleteContactByIdAsync(long contactId)
    {
        var contact = await SelectContactByIdAsync(contactId);
        MainContext.Contacts.Remove(contact);
        await MainContext.SaveChangesAsync();
    }

    public async Task<long> InsertContactAsync(Contact contact)
    {
        await MainContext.Contacts.AddAsync(contact);
        await MainContext.SaveChangesAsync();
        return contact.Id;
    }

    public IQueryable<Contact> SelectAllContacts()
    {
        return MainContext.Contacts;
    }

    public async Task<ICollection<Contact>> SelectAllContactsAsync()
    {
        var contacts = await MainContext.Contacts.ToListAsync();
        return contacts;
    }

    public async Task<ICollection<Contact>> SelectAllContactsWithPaginationAsync(int skip, int take)
    {
        var contacts = await SelectAllContacts().Skip(skip).Take(take).ToListAsync();
        return contacts;
    }

    public async Task<Contact> SelectContactByIdAsync(long contactId)
    {
        var contact = await MainContext.Contacts.FirstOrDefaultAsync(c => c.Id == contactId);
        return contact == null ? throw new EntityNotFoundException($"Contact with id: {contactId} not found") : contact;
    }

    public async Task<Contact> SelectContactByEmailAsync(string email)
    {
        var contact = await MainContext.Contacts.FirstOrDefaultAsync(c => c.Email == email);
        return contact == null ? throw new EntityNotFoundException($"Contact with email: {email} not found") : contact;
    }

    public async Task<Contact> SelectContactByUserIdAsync(long userId)
    {
        var contact = await MainContext.Contacts.FirstOrDefaultAsync(c => c.UserId == userId);
        return contact ?? throw new EntityNotFoundException($"Contact with Contact: {userId} not found");
    }

    public async Task<int> SelectTotalContactsCountAsync()
    {
        var totalCount = await MainContext.Contacts.CountAsync();
        return totalCount;
    }

    public async Task UpdateContactAsync(Contact contact)
    {
        var contactFromDb = await SelectContactByIdAsync(contact.Id);
        MainContext.Contacts.Update(contact);
        await MainContext.SaveChangesAsync();
    }

    public Task<Contact> SelectContactByFirstNameAsync(string firstName)
    {
        throw new NotImplementedException();
    }

    public Task<Contact> SelectContactByPhoneNumberAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }
}

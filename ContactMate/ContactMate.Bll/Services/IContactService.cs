using ContactMate.Bll.Dtos;

namespace ContactMate.Bll.Services;

public interface IContactService
{
    Task<long> AddContactAsync(ContactCreateDto contactCreateDto, long userId);
    Task<ICollection<ContactDto>> GetAllContacstAsync(long userId);
    Task DeleteContactAsync(long contactId, long userId);
    Task UpdateContactAsync(ContactDto contactDto, long userId);
    Task<ContactDto> GetContacDtotByContacId(long contactId);
}
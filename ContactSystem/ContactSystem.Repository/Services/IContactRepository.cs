using ContactSystem.Dal.Entities;

namespace ContactSystem.Repository.Services;

public interface IContactRepository
{
    Task<long> InsertContactAsync(Contact contact);
    Task DeleteContactByIdAsync(long contactId);
    Task UpdateContactAsync(Contact contact);
    Task<ICollection<Contact>> SelectAllContactsWithPaginationAsync(int skip, int take);
    Task<ICollection<Contact>> SelectAllContactsAsync();
    Task<Contact> SelectContactByIdAsync(long contactId);
    Task<Contact> SelectContactByUserIdAsync(long userId);
    Task<Contact> SelectContactByEmailAsync(string email);
    Task<Contact> SelectContactByFirstNameAsync(string firstName);
    Task<Contact> SelectContactByPhoneNumberAsync(string phoneNumber);
    Task<int> SelectTotalContactsCountAsync();
    IQueryable<Contact> SelectAllContacts();
}
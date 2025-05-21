using ContactSystem.Dal.Entities;

namespace ContactSystem.Repository.Services;

public interface IUserRepositroy
{
    Task<long> InsertUserAsync(User user);
    Task<User> SelectUserByIdAsync(long id);
    Task<User> SelectUserByUserNameAsync(string userName);
    Task UpdateUserRoleAsync(long userId, UserRole userRole);
    Task DeleteUserById(long userId);
}
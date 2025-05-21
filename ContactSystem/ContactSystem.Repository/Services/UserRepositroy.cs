using ContactSystem.Dal.Entities;

namespace ContactSystem.Repository.Services;

public class UserRepositroy : IUserRepositroy
{
    public Task DeleteUserById(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<long> InsertUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> SelectUserByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<User> SelectUserByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserRoleAsync(long userId, UserRole userRole)
    {
        throw new NotImplementedException();
    }
}

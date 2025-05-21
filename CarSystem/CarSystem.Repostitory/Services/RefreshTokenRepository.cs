using CarSystem.Dal.Entities;

namespace CarSystem.Repostitory.Services;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    public Task AddRefreshToken(RefreshToken refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshToken?> GetActiveTokenByUserIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<RefreshToken> SelectRefreshToken(string refreshToken, long userId)
    {
        throw new NotImplementedException();
    }
}

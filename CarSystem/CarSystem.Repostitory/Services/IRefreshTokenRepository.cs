using CarSystem.Dal.Entities;

namespace CarSystem.Repostitory.Services;

public interface IRefreshTokenRepository
{
    Task AddRefreshToken(RefreshToken refreshToken);
    Task<RefreshToken> SelectRefreshToken(string refreshToken, long userId);
    Task<RefreshToken?> GetActiveTokenByUserIdAsync(long userId);
}

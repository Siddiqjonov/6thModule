using ContactMate.Bll.Helpers;
using ContactMate.Bll.Services;
using ContactMate.Repository.Services;

namespace ContactMate.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        // Repository
        builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        builder.Services.AddScoped<IUserRepositroy, UserRepositroy>();
        builder.Services.AddScoped<IContactRepository, ContactRepository>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        // Bll
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IContactService, ContactService>();
        builder.Services.AddScoped<IUserRoleService, UserRoleService>();
        builder.Services.AddScoped<IUserService, UserService>();
    }
}

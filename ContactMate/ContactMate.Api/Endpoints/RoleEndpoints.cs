using ContactMate.Bll.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactMate.Api.Endpoints;

public static class RoleEndpoints
{
    public static void MapRoleEndpoints(this WebApplication app)
    {
        var userGroup = app.MapGroup("/api/userRole")
            .RequireAuthorization()
            .WithTags("UserRole Management");

        userGroup.MapGet("/getAll", [Authorize(Roles = "Admin, SuperAdmin")]
        async (IUserRoleService _userRoleService) =>
        {
            var roles = await _userRoleService.GetAllRolesAsync();
            return Results.Ok(roles);
        })
          .WithName("GetAllUsers");

        userGroup.MapGet("/getAllUsersByRoleName",
            [Authorize(Roles = "Admin, SuperAdmin")]
            [ResponseCache(Duration = 5, Location = ResponseCacheLocation.Any, NoStore = false)]
        async (string role, IUserRoleService _userRoleService) =>
        {
            var users = await _userRoleService.GetAllUsersByRoleNameAsync(role);
            return Results.Ok(users);
        })
        .WithName("GetUsersByRole");
    }
}

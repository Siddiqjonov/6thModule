﻿using ContactMate.Bll.Dtos;
using ContactMate.Bll.Services;
using ContactMate.Core.Errors;
using Microsoft.AspNetCore.Builder;

namespace ContactMate.Api.Endpoints;

public static class ContactEndpoints
{
    public static void MapContactEndpoints(this WebApplication app)
    {
        var userGroup = app.MapGroup("/api/contact")
            .RequireAuthorization().
            WithTags("Contact endpoints");

        userGroup.MapPost("/post", AddContact)
            .WithName("AddContact");

        userGroup.MapDelete("/delete", DeleteContact)
            .WithName("DeleteContact");

        userGroup.MapGet("/getAll", GetAllContacts)
            .WithName("GetAllContacts");

        userGroup.MapGet("/getById", GetContactById)
            .WithName("GetContactById");

        userGroup.MapPut("/update", UpdateContact)
            .WithName("UpdateContact");
    }

    public static async Task<IResult> AddContact(ContactCreateDto contactCreateDto, HttpContext context, IContactService contactService)
    {
        var userId = context.User.FindFirst("UserId")?.Value;
        if (userId is null)
            throw new ForbiddenException("Access forbidden to add contact");
        
        await contactService.AddContactAsync(contactCreateDto, long.Parse(userId));
        return Results.Ok();
    }

    public static async Task<IResult> DeleteContact(long contactId, HttpContext context, IContactService _service)
    {
        var userId = context.User.FindFirst("UserId")?.Value;
        if (userId is null)
            throw new ForbiddenException("Access forbidden to delete contact");
        
        await _service.DeleteContactAsync(contactId, long.Parse(userId));
        return Results.Ok();
    }

    public static async Task<IResult> UpdateContact(ContactDto contact, HttpContext context, IContactService _service)
    {
        var userId = context.User.FindFirst("UserId")?.Value;
        if (userId is null)
            throw new ForbiddenException("Access forbidden to update contact");
        
        await _service.UpdateContactAsync(contact, long.Parse(userId));
        return Results.Ok();
    }

    public static async Task<IResult> GetContactById(long contactId, HttpContext context, IContactService _service)
    {
        var userId = context.User.FindFirst("UserId")?.Value;
        if (userId is null)
            throw new ForbiddenException("Access forbidden to get contact by id");
        
        var res = await _service.GetContactByContacIdAsync(contactId, long.Parse(userId));
        return Results.Ok(res);
    }

    public static async Task<IResult> GetAllContacts(HttpContext context, IContactService _service)
    {
        var userId = context.User.FindFirst("UserId")?.Value;
        if (userId is null)
            throw new ForbiddenException("Access forbidden to get all contacts");
        
        var res = await _service.GetAllContactstAsync(long.Parse(userId));
        return Results.Ok(res);
    }
}

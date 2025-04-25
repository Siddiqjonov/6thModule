using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TaskManager.Bll.Dtos;
using TaskManager.Bll.Services;
using TaskManager.Dal.Entities;

namespace TaskManager.Api.Controllers;

[Route("api/toDoItem")]
[ApiController]
public class ToDoItemController : ControllerBase
{
    private readonly IToDoItemService ToDoItemService;
    private readonly ILogger<ToDoItemController> _logger;

    public ToDoItemController(IToDoItemService toDoItemService, ILogger<ToDoItemController> logger)
    {
        this.ToDoItemService = toDoItemService;
        _logger = logger;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddToDoItem(ToDoItemCreateDto toDoItemCreateDto)
    {
        try
        {
            await ToDoItemService.AddToDoItemAsync(toDoItemCreateDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Server error: {ex.Message}" });
        }
    }

    [HttpGet("getAll")]
    public async Task<ICollection<ToDoItemExtendedDto>> GetAll(int skip, int take)
    {
        _logger.LogInformation($"GetAll method has been used {DateTime.UtcNow}");

        try
        {
            throw new Exception("THIS IS A TEST ERROR FOR LOGGING IT DO DB AND FILE");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
        return await ToDoItemService.GetAllToDoItemsAsync(skip, take);
    }

    [HttpDelete("delete")]
    public async Task Delete(long id)
    {
        await ToDoItemService.DeleteToDoItemByIdAsync(id);
    }

    [HttpPut("update")]
    public async Task Update(ToDoItemExtendedDto toDoItem)
    {
        await ToDoItemService.UpdateToDoItemAsync(toDoItem);
    }

    [HttpGet("getById")]
    public async Task<ToDoItemExtendedDto> GetById(long id)
    {
        return await ToDoItemService.GetToDoItemByIdAsync(id);
    }

    [HttpGet("getIncomplited")]
    public async Task<ICollection<ToDoItemExtendedDto>> GetIncomplited(int skip, int take)
    {
        return await ToDoItemService.GetIncompletedToDoItemsAsync(skip, take);
    }

    [HttpGet("getCompleted")]
    public async Task<ICollection<ToDoItemExtendedDto>> GetCompleted(int skip, int take)
    {
        return await ToDoItemService.GetCompletedToDoItemsAsync(skip, take);
    }

    [HttpGet("getDueDate")]
    public async Task<ICollection<ToDoItemExtendedDto>> GetDueDate(DateTime dueDate)
    {
        return await ToDoItemService.GetToDoItemsByDueDateAsync(dueDate);
    }
}

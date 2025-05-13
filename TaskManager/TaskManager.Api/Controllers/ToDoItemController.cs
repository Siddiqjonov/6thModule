using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TaskManager.Api.Filters;
using TaskManager.Bll.Dtos;
using TaskManager.Bll.Services;
using TaskManager.Dal.Entities;

namespace TaskManager.Api.Controllers;

[EnableCors("AllowAll")]
[Route("api/toDoItem")]
//[ServiceFilter(typeof(LogActionFilter))]
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
    public async Task AddToDoItem(ToDoItemCreateDto toDoItemCreateDto)
    {
        _logger.LogInformation("new to do item added");
        await ToDoItemService.AddToDoItemAsync(toDoItemCreateDto);

    }

    [HttpGet("getAll")]
    public async Task<ICollection<ToDoItemExtendedDto>> GetAll(int skip, int take = 10)
    {
        _logger.LogInformation($"GetAll method has been used {DateTime.UtcNow}");

        try
        {
            int a = 0;
            int b = 3 / a;
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

    [HttpPost("send")]
    public async Task<IActionResult> SendSms(string number)
    {
        string url = @$"http://192.168.16.62:9090/sms/send?phoneNumber={number}";

        using HttpClient httpClient = new HttpClient();

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return Ok("SMS sent successfully.");
        }
        else
        {
            return StatusCode((int)response.StatusCode, "Failed to send SMS.");
        }
    }


}

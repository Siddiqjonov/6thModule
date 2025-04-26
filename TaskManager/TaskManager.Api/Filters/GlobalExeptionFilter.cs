using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Filters;

public class GlobalExeptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExeptionFilter> _logger;

    public GlobalExeptionFilter(ILogger<GlobalExeptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        Console.WriteLine($"Exception: {context.Exception.Message}");
        _logger.LogError($"Exception: {context.Exception.Message}");

        var result = new { error = "An unexpected error occurred" };

        context.Result = new ObjectResult(result.error)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
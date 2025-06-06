﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManager.Api.Filters;

public class LogActionFilter : ActionFilterAttribute
{
    private readonly ILogger<LogActionFilter> _logger;

    public LogActionFilter(ILogger<LogActionFilter> logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation($" => {context.HttpContext.Request.Method} - {context.ActionDescriptor.DisplayName}");
        Console.WriteLine($" => {context.HttpContext.Request.Method} - {context.ActionDescriptor.DisplayName}");
        //base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation($"Finished = {context.ActionDescriptor.DisplayName}");
        Console.WriteLine($"Finished = {context.ActionDescriptor.DisplayName}");
        //base.OnActionExecuted(context);
    }
}

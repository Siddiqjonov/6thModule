using Serilog;

namespace TaskManager.Api.Configurations;

public static class SelilogConfiguration
{
    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;

        var telegramBotToken = config["Serilog:WriteTo:2:Args:telegramApiKey"];
        var telegramChatId = config["Serilog:WriteTo:2:Args:telegramChatId"];

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .WriteTo.Telegram(telegramBotToken, telegramChatId) // ← Add this directly
            .CreateLogger();

        //builder.Logging.ClearProviders();
        builder.Logging.AddSerilog();
    }

}

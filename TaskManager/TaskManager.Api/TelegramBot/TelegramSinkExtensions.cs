using Serilog;
using Serilog.Configuration;

namespace TaskManager.Api.Sinks;

public static class TelegramSinkExtensions
{
    public static LoggerConfiguration Telegram(
        this LoggerSinkConfiguration loggerConfiguration,
        string telegramApiKey,
        string telegramChatId)
    {
        return loggerConfiguration.Sink(new TelegramSink(telegramApiKey, telegramChatId));
    }
}

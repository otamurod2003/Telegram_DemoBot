using Telegram.Bot;
using Telegram.Bot.Types.Enums;

internal class ProgramBase
{
    private static TelegramBotClient client;
    static void Main(string[] args)
    {
        // token, который вернул BotFather
        client = new TelegramBotClient(token);
        client.OnMessage += BotOnMessageReceived;
        client.OnMessageEdited += BotOnMessageReceived;
        client.StartReceiving();
        Console.ReadLine();
        client.StopReceiving();
    }
    private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
    {
        var message = messageEventArgs.Message;
        if (message?.Type == MessageType.TextMessage)
        {
            await client.SendTextMessageAsync(message.Chat.Id, message.Text);
        }
    }
}
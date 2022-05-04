using UraDaDavai_Chat_Bot.CommandsValidationMiddleware;
using Telegram.Bot;

namespace UraDaDavai_Chat_Bot.UserIOProvider
{
    internal class TelegramApiProvider : UserIOProviderBase
    {
        private readonly TelegramBotClient _bot;

        public TelegramApiProvider(CommandsValidationMiddlewareBase commandsValidationMiddleware, TelegramApiProviderDataLoader dataLoader) 
            : base(commandsValidationMiddleware)
        {
            var token = dataLoader.GetApiToken();
            _bot = new TelegramBotClient(token);

            _bot.OnMessage += OnMessageReceived;
        }

        private void OnMessageReceived(object? sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message.Text;
            var senderId = e.Message.Chat.Id;

            if (!string.IsNullOrEmpty(message))
            {
                var data = new TelegramCommandData(senderId.ToString(), message, SendResponce);
                CommandReceived?.Invoke(data);
            }
        }

        public override void Start()
        {
            _bot.StartReceiving();
            Console.ReadLine();
        }

        public override void SendResponce(string toId, string message)
        {
            _bot.SendTextMessageAsync(long.Parse(toId), message);
        }
    }
}

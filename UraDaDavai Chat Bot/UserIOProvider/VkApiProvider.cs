using UraDaDavai_Chat_Bot.CommandsValidationMiddleware;
using VkBotFramework;

namespace UraDaDavai_Chat_Bot.UserIOProvider
{
    internal class VkApiProvider : UserIOProviderBase
    {
        private readonly VkBot _bot;

        public VkApiProvider(CommandsValidationMiddlewareBase middleware, VkApiProviderDataLoader dataLoader)
            : base (middleware)
        {
            var apiToken = dataLoader.GetApiToken();
            var groupUrl = dataLoader.GetGroupUrl();

            _bot = new VkBot(apiToken, groupUrl);
            _bot.OnMessageReceived += OnMessageReceived;
        }

        public override void Start()
        {
            _bot.Start();
        }

        private void OnMessageReceived(object? sender, VkBotFramework.Models.MessageReceivedEventArgs e)
        {
            var senderId = e.Message.PeerId.ToString();
            var command = e.Message.Text;

            var data = new VkApiCommandData(senderId, command, SendResponce);
            CommandReceived?.Invoke(data);
        }

        public override void SendResponce(string toId, string message)
        {
            var peer = long.Parse(toId);

            try
            {
                SendMessage(peer, message);
            }
            catch (VkNet.Exception.MessageIsTooLongException)
            {
                var errorMsg = "Результат слишком длинный, не могу отправить.";
                SendMessage(peer, errorMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникло исключение: {e.GetType()}");
            }
        }

        private void SendMessage(long? peer, string responseMessage)
        {
            _bot.Api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                Message = responseMessage,
                PeerId = peer,
                RandomId = Environment.TickCount
            });
        }
    }
}

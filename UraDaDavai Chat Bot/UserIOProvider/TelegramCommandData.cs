using UraDaDavai_Chat_Bot.CommandsValidationMiddleware;

namespace UraDaDavai_Chat_Bot.UserIOProvider
{
    internal class TelegramCommandData : CommandDataBase
    {
        public TelegramCommandData(string senderId, string command, Action<string, string> sendResponceMethod)
            : base(senderId, command, sendResponceMethod) { }

        public override bool IsCommandFromGroupChat()
        {
            var id = long.Parse(SenderId);
            return id < 0;
        }
    }
}

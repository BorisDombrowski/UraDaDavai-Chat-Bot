using UraDaDavai_Chat_Bot.CommandsExecutor;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    public class CommandsValidationMiddleware : CommandsValidationMiddlewareBase
    {
        public CommandsValidationMiddleware(ICommandsExecutor executor) : base(executor) { }

        public override void OnCommandReceived(CommandDataBase commandData)
        {
            var command = commandData.Command.Trim();
            var startsByBotName = IsCommandStartsByBotName(command);

            if (commandData.IsCommandFromGroupChat() && !startsByBotName)
            {
                return;
            }

            if (startsByBotName)
            {
                command = RemoveBotNameFromCommand(command);
            }

            var commandResult = SendCommandForExecution(command);
            commandData.SendResponce(commandResult);
        }

        private bool IsCommandStartsByBotName(string command)
        {
            var split = command.Split(' ');
            return BotNameValidator.ValidateName(split[0]);
        }

        private string RemoveBotNameFromCommand(string command)
        {
            var split = command.Split(' ').ToList();
            split.RemoveAt(0);
            return string.Join(' ', split);
        }
    }
}

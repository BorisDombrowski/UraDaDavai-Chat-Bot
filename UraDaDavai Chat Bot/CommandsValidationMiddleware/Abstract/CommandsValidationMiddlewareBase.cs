using UraDaDavai_Chat_Bot.CommandsExecutor;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    public abstract class CommandsValidationMiddlewareBase
    {
        private ICommandsExecutor _commandsExecutor;
        private IBotNameValidator _botNameValidator;

        public CommandsValidationMiddlewareBase(ICommandsExecutor executor, IBotNameValidator botNameValidator)
        {
            _commandsExecutor = executor ?? throw new ArgumentNullException(nameof(executor));
            _botNameValidator = botNameValidator ?? throw new ArgumentNullException(nameof(botNameValidator));
        }

        public abstract void OnCommandReceived(CommandDataBase commandData);

        protected string SendCommandForExecution(string command)
        {
            return _commandsExecutor.ExecuteCommand(command);
        }

        protected bool IsBotName(string inputString)
        {
            return _botNameValidator.IsBotName(inputString);
        }
    }
}

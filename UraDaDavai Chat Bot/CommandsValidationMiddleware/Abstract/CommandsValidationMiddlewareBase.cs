using UraDaDavai_Chat_Bot.CommandsExecutor;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    public abstract class CommandsValidationMiddlewareBase
    {
        private ICommandsExecutor _commandsExecutor;

        public CommandsValidationMiddlewareBase(ICommandsExecutor executor)
        {
            if(executor == null)
            {
                throw new ArgumentNullException("Command executor is null");
            }

            _commandsExecutor = executor;
        }

        public abstract void OnCommandReceived(CommandDataBase commandData);

        protected string SendCommandForExecution(string command)
        {
            return _commandsExecutor.ExecuteCommand(command);
        }
    }
}

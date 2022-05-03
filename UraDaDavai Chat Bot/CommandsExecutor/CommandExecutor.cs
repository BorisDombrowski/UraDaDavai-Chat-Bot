using UraDaDavai_Chat_Bot.Commands;

namespace UraDaDavai_Chat_Bot.CommandsExecutor
{
    public class CommandExecutor : ICommandsExecutor
    {
        private Command[] _commands;

        public CommandExecutor(params Command[] commands)
        {
            _commands = commands;
        }

        public string ExecuteCommand(string command)
        {
            var cmd = _commands.FirstOrDefault(x => x.CheckStringConformity(command));
            return cmd?.Execute(command)
                 ?? "Команда не найдена или указаны неверные аргументы.\nОтправьте help, чтобы получить справку по командам.";
        }
    }
}

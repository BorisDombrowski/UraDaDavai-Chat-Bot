using UraDaDavai_Chat_Bot.Commands;
using UraDaDavai_Chat_Bot.CommandsExecutor;
using UraDaDavai_Chat_Bot.CommandsValidationMiddleware;
using UraDaDavai_Chat_Bot.UserIOProvider;


class Program
{
    private static void Main(string[] args)
    {
        var executor = new CommandExecutor(
            new StartCommand(),
            new HelpCommand(),
            new RepeatCommand(),
            new GenerateUraDaDavaiCommand());

        var nameValidator = new SimpleBotNameValidator();
        var middleware = new CommandsValidationMiddleware(executor, nameValidator);

        var dataLoader = new TelegramApiProviderDataLoader();
        var provider = new TelegramApiProvider(middleware, dataLoader);

        provider.Start();
    }
}


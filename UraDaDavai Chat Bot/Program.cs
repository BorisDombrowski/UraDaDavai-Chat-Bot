using UraDaDavai_Chat_Bot.Commands;
using UraDaDavai_Chat_Bot.CommandsExecutor;
using UraDaDavai_Chat_Bot.CommandsValidationMiddleware;
using UraDaDavai_Chat_Bot.UserIOProvider;

class Program
{
    private static void Main(string[] args)
    {
        ICommandsExecutor executor = new CommandExecutor(
            new HelpCommand(),
            new RepeatCommand(),
            new GenerateUraDaDavaiCommand());

        IBotNameValidator botNameValidator = new SimpleBotNameValidator();

        CommandsValidationMiddlewareBase middleware = new CommandsValidationMiddleware(executor, botNameValidator);

        VkApiProviderDataLoader dataLoader = new VkApiProviderDataLoader();

        UserIOProviderBase vkProvider = new VkApiProvider(middleware, dataLoader);
        vkProvider.Start();
    }
}


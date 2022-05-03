using UraDaDavai_Chat_Bot.Commands;
using UraDaDavai_Chat_Bot.CommandsExecutor;
using UraDaDavai_Chat_Bot.CommandsValidationMiddleware;
using System;

namespace IntegrationTests.TestEntities
{
    internal class SystemBuilder
    {
        public TestIOProvider Build(ResponceReceiver receiver)
        {
            ICommandsExecutor executor = new CommandExecutor(
            new HelpCommand(),
            new RepeatCommand(),
            new GenerateUraDaDavaiCommand());

            CommandsValidationMiddlewareBase midware = new CommandsValidationMiddleware(executor);

            TestIOProvider provider = new TestIOProvider(midware, receiver.ReceiveResponce);
            return provider;
        }
    }

    internal class TestIOProvider : UserIOProviderBase
    {
        private Action<long?, string> _responceReceiverMethod;

        public TestIOProvider(CommandsValidationMiddlewareBase commandsValidationMiddleware, Action<long?, string> responceReceiverMethod)
            : base(commandsValidationMiddleware)
        {
            _responceReceiverMethod += responceReceiverMethod;
        }

        //Вызывается из внешней компоненты
        public void OnCommandReceived(string command, long? senderId)
        {
            var data = new TestCommandData(senderId.ToString(), command, SendResponce);
            CommandReceived.Invoke(data);
        }

        public override void SendResponce(string toId, string message)
        {
            _responceReceiverMethod?.Invoke(long.Parse(toId), message);
        }

        public override void Start()
        {
            /*nothing to do*/
        }
    }

    internal class TestCommandData : CommandDataBase
    {
        public TestCommandData(string senderId, string command, Action<string, string> sendResponceMethod)
            : base(senderId, command, sendResponceMethod) { }

        public override bool IsCommandFromGroupChat()
        {
            var id = long.Parse(SenderId);
            return id > 2000000000;
        }
    }

    internal class ResponceReceiver
    {
        public long? lastResponcePeer = null;
        public string lastResponceMessage = null;

        public void ReceiveResponce(long? peer, string responseMessage)
        {
            lastResponcePeer = peer;
            lastResponceMessage = responseMessage;
        }
    }
}

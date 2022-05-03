using Xunit;
using IntegrationTests.TestEntities;

namespace IntegrationTests
{
    public class IntegrationTests
    {
        private SystemBuilder _builder = new SystemBuilder();
        private string _wrongCommandMsg = "Команда не найдена или указаны неверные аргументы.\nОтправьте help, чтобы получить справку по командам.";
        private string _helpResponce =
                "При использовании бота в беседе добавлейте перед командой ура/ura\n" +
                "\n" +
                "\n" +
                "• ген/gen <число_слов> [+] - генерация текста УРА ДА ДАВАЙ\n" +
                "-- <число_слов> - количество слов, которое должен содержать текст (от 1 до 300)\n" +
                "-- [+] - необязательный параметр, добавьте его, если все слова текста должны быть в верхнем регистре\n" +
                "\n" +
                "\n" +
                "• повтор/repeat <слово> <число_повторов>\n" +
                "• повтор/repeat <слова через пробел> <число_повторов> - генерация текста из повторяющейся фразы/слова\n" +
                "-- <слово> - слово, которое нужно повторять\n" +
                "-- <слова через пробел> - фраза, которую нужно повторять\n" +
                "-- <число_повторов> - сколько раз нужно повторить слово (от 1 до 1000)";

        [Fact(DisplayName = "Test 1.01 - repeat")]
        public void Test1()
        {
            var receiver = new ResponceReceiver(); 
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("repeat qwerty 1", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal("qwerty", res);
        }

        [Fact(DisplayName = "Test 1.02 - repeat")]
        public void Test2()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("repeat qwe rty 1", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal("qwe rty", res);
        }

        [Fact(DisplayName = "Test 1.03 - help")]
        public void Test3()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("help", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_helpResponce, res);
        }

        [Fact(DisplayName = "Test 1.04 - gen")]
        public void Test4()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("gen 10", 100);
            var res = receiver.lastResponceMessage.Split(' ').Length;

            Assert.Equal(10, res);
        }

        [Fact(DisplayName = "Test 1.05 - gen")]
        public void Test5()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("gen 10 +", 100);
            var res = receiver.lastResponceMessage;
            var resLength = receiver.lastResponceMessage.Split(' ').Length;

            Assert.Equal(10, resLength);
            Assert.Equal(res.ToUpper(), res);
        }

        [Fact(DisplayName = "Test 1.06 - not a command")]
        public void Test6()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("qwerty", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_wrongCommandMsg, res);
        }

        [Fact(DisplayName = "Test 1.07 - wrong repeat")]
        public void Test7()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("repeat qwerty 1001", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_wrongCommandMsg, res);
        }

        [Fact(DisplayName = "Test 1.08 - wrong repeat")]
        public void Test8()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("repeat qwerty qwerty", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_wrongCommandMsg, res);
        }

        [Fact(DisplayName = "Test 1.09 - wrong help")]
        public void Test9()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("help qwerty", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_wrongCommandMsg, res);
        }

        [Fact(DisplayName = "Test 1.10 - wrong gen")]
        public void Test10()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("gen", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_wrongCommandMsg, res);
        }

        [Fact(DisplayName = "Test 1.11 - wrong gen")]
        public void Test11()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("gen -100", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_wrongCommandMsg, res);
        }

        [Fact(DisplayName = "Test 1.12 - wrong gen")]
        public void Test12()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("gen qwerty", 100);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_wrongCommandMsg, res);
        }

        [Fact(DisplayName = "Test 2.01 - repeat in group chat")]
        public void Test13()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("ura repeat qwerty 1", 2000000001);
            var res = receiver.lastResponceMessage;

            Assert.Equal("qwerty", res);
        }

        [Fact(DisplayName = "Test 2.02 - wrong repeat in group chat")]
        public void Test14()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("repeat qwerty 1", 2000000001);
            var res = receiver.lastResponceMessage;

            Assert.Null(res);
        }

        [Fact(DisplayName = "Test 2.03 - help in group chat")]
        public void Test15()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("ura help", 2000000001);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_helpResponce, res);
        }

        [Fact(DisplayName = "Test 2.03 - wrong help in group chat")]
        public void Test16()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("help", 2000000001);
            var res = receiver.lastResponceMessage;

            Assert.Null(res);
        }

        [Fact(DisplayName = "Test 2.04 - gen in group chat")]
        public void Test17()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("ura gen 10", 2000000001);
            var res = receiver.lastResponceMessage.Split(' ').Length;

            Assert.Equal(10, res);
        }

        [Fact(DisplayName = "Test 2.05 - wrong gen in group chat")]
        public void Test18()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("gen 10", 2000000001);
            var res = receiver.lastResponceMessage;

            Assert.Null(res);
        }

        [Fact(DisplayName = "Test 2.06 - not a command in group chat")]
        public void Test19()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("ura qwerty", 2000000001);
            var res = receiver.lastResponceMessage;

            Assert.Equal(_wrongCommandMsg, res);
        }

        [Fact(DisplayName = "Test 2.07 - other message in group chat")]
        public void Test20()
        {
            var receiver = new ResponceReceiver();
            var provider = _builder.Build(receiver);

            provider.OnCommandReceived("qwerty", 2000000001);
            var res = receiver.lastResponceMessage;

            Assert.Null(res);
        }
    }
}
using Xunit;
using UraDaDavai_Chat_Bot.Commands;
using System;

namespace CommandsTests
{
    public class HelpCommandTests
    {
        private Command _help = new HelpCommand();
        private string _helpResponce =
                "ѕри использовании бота в беседе добавлейте перед командой ура/ura\n" +
                "\n" +
                "\n" +
                "Х ген/gen <число_слов> [+] - генераци€ текста ”–ј ƒј ƒј¬ј…\n" +
                "-- <число_слов> - количество слов, которое должен содержать текст (от 1 до 300)\n" +
                "-- [+] - необ€зательный параметр, добавьте его, если все слова текста должны быть в верхнем регистре\n" +
                "\n" +
                "\n" +
                "Х повтор/repeat <слово> <число_повторов>\n" +
                "Х повтор/repeat <слова через пробел> <число_повторов> - генераци€ текста из повтор€ющейс€ фразы/слова\n" +
                "-- <слово> - слово, которое нужно повтор€ть\n" +
                "-- <слова через пробел> - фраза, которую нужно повтор€ть\n" +
                "-- <число_повторов> - сколько раз нужно повторить слово (от 1 до 1000)";

        [Fact(DisplayName = "Test 01")]
        public void Test1()
        {            
            Assert.False(_help.CheckStringConformity("qwerty"));
        }

        [Fact(DisplayName = "Test 02")]
        public void Test2()
        {           
            Assert.True(_help.CheckStringConformity("help"));
        }

        [Fact(DisplayName = "Test 03")]
        public void Test3()
        {            
            Assert.False(_help.CheckStringConformity("help qwerty"));
        }

        [Fact(DisplayName = "Test 04")]
        public void Test4()
        {
            Assert.Equal(_helpResponce, _help.Execute("help"));
        }

        [Fact(DisplayName = "Test 05")]
        public void Test5()
        {
            Assert.Throws<ArgumentException>(() => _help.Execute("qwerty"));
        }
    }
}
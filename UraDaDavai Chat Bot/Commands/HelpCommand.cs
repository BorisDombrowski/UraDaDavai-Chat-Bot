

namespace UraDaDavai_Chat_Bot.Commands
{
    public class HelpCommand : Command
    {
        public override bool CheckStringConformity(string inputString)
        {
            var split = inputString.Split(' ');

            if (split.Length == 1)
            {
                if (split[0].ToLower() == "/help" || split[0].ToLower() == "help")
                {
                    return true;
                }
            }

            return false;
        }

        protected override string CommandExecution(string inputString)
        {
            return
            "При использовании бота в беседе добавлейте перед командой @ura_da_davai_bot\n" +
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
        }
    }
}

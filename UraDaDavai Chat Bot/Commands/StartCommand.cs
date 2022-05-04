using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.Commands
{
    public class StartCommand : Command
    {
        public override bool CheckStringConformity(string inputString)
        {
            var split = inputString.Split(' ');

            if (split.Length == 1)
            {
                if (split[0].ToLower() == "/start")
                {
                    return true;
                }
            }

            return false;
        }

        protected override string CommandExecution(string inputString)
        {
            return "Приветствую! Отправь команду /help, чтобы узнать подробности.";
        }
    }
}

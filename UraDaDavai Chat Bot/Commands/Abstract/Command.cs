using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.Commands
{
    public abstract class Command
    {
        public abstract bool CheckStringConformity(string inputString);

        public string Execute(string inputString)
        {
            if(!CheckStringConformity(inputString))
            {
                throw new ArgumentException();
            }

            return CommandExecution(inputString);
        }

        protected abstract string CommandExecution(string inputString);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.CommandsExecutor
{
    public interface ICommandsExecutor
    {
        string ExecuteCommand(string command);
    }
}

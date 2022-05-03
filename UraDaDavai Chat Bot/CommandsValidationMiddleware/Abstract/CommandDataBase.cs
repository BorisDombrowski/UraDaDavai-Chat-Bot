using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    public abstract class CommandDataBase
    {
        public string SenderId { get; }
        public string Command { get; }
        private Action<string, string> _sendResponceMethod;

        public CommandDataBase(string senderId, string command, Action<string, string> sendResponceMethod)
        {
            if(sendResponceMethod == null)
            {
                throw new ArgumentNullException("Send responce method is null");
            }

            SenderId = senderId;
            Command = command;
            _sendResponceMethod += sendResponceMethod;
        }

        public void SendResponce(string message)
        {
            _sendResponceMethod?.Invoke(SenderId, message);
        }

        public abstract bool IsCommandFromGroupChat();
    }
}

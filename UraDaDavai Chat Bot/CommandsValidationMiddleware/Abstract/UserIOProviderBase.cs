using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    public abstract class UserIOProviderBase
    {
        protected event Action<CommandDataBase> CommandReceived;

        public UserIOProviderBase(CommandsValidationMiddlewareBase commandsValidationMiddleware)
        {
            if(commandsValidationMiddleware == null)
            {
                throw new ArgumentNullException("Command validation middleware is null");
            }

            CommandReceived += commandsValidationMiddleware.OnCommandReceived;
        }

        public abstract void Start();
        public abstract void SendResponce(string toId, string message);
    }
}

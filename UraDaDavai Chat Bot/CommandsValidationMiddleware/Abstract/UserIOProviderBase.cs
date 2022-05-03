using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    public abstract class UserIOProviderBase
    {
        protected Action<CommandDataBase> CommandReceived;

        public UserIOProviderBase(CommandsValidationMiddlewareBase commandsValidationMiddleware)
        {
            if(commandsValidationMiddleware == null)
            {
                throw new ArgumentNullException(nameof(commandsValidationMiddleware));
            }

            CommandReceived += commandsValidationMiddleware.OnCommandReceived;
        }

        public abstract void Start();
        public abstract void SendResponce(string toId, string message);
    }
}

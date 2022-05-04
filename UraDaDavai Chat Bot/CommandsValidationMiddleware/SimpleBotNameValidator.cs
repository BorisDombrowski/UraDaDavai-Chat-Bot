using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    internal class SimpleBotNameValidator : IBotNameValidator
    {
        private readonly string[] _names = { "ура", "ura" };

        public bool IsBotName(string inputString)
        {
            return _names.Contains(inputString.ToLower());
        }
    }
}

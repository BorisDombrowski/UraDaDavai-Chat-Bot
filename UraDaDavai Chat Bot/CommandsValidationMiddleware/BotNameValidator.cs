using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    internal static class BotNameValidator
    {
        private static string[] _names = { "ура", "ura" };

        /// <summary>
        /// Проверяет, является ли входящая строка именем бота
        /// </summary>
        /// <param name="name">Строка, которую необходимо проверить</param>
        /// <returns></returns>
        public static bool ValidateName(string name)
        {
            return _names.Contains(name.ToLower());
        }
    }
}

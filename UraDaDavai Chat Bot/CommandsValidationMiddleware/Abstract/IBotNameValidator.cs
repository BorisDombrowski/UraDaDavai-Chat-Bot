using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.CommandsValidationMiddleware
{
    public interface IBotNameValidator
    {
        /// <summary>
        /// Проверяет, является ли входящая строка именем бота
        /// </summary>
        /// <param name="inputString">Строка, которую необходимо проверить</param>
        /// <returns></returns>
        bool IsBotName(string inputString);
    }
}

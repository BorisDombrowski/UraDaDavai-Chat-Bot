using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.UserIOProvider
{
    internal class VkApiProviderDataLoader
    {
        private bool _loaded = false;
        private string _apiToken;
        private string _groupUrl;

        /// <summary>
        /// Метод загрузки дннных для работы с API из файла
        /// </summary>
        private void LoadData()
        {
            var file = File.ReadAllLines("api_data.txt", Encoding.UTF8);

            _apiToken = file[0];
            _groupUrl = file[1];

            _loaded = true;
        }

        /// <summary>
        /// Метод для получения токена для Vk API
        /// </summary>
        /// <returns>Токен Vk API</returns>
        public string GetApiToken()
        {
            if (!_loaded)
            {
                LoadData();
            }

            return _apiToken;
        }

        /// <summary>
        /// Метод для получения ссылки на группу Vk, с которой взаимодействует бот
        /// </summary>
        /// <returns>Ссылка на группу в Vk</returns>
        public string GetGroupUrl()
        {
            if (!_loaded)
            {
                LoadData();
            }

            return _groupUrl;
        }
    }
}

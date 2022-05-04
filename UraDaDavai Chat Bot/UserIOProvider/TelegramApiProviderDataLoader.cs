using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraDaDavai_Chat_Bot.UserIOProvider
{
    internal class TelegramApiProviderDataLoader
    {
        private string _apiToken;
        private bool _loaded = false;

        private void LoadData()
        {
            var file = File.ReadAllLines("api_data.txt");
            _apiToken = file[0];
        }

        public string GetApiToken()
        {
            if(!_loaded)
            {
                LoadData();
            }

            return _apiToken;
        }
    }
}

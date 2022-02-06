using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Raminagrobis.WPF2.ApiClient;

namespace Raminagrobis.WPF2.Pages
{
    internal class ApiPage
    {
        private Client _clientApi;
        public Client ClientApi { get => _clientApi; private set => _clientApi = value; }

        public ApiPage()
        {
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile("appsettings.json", false, true).Build();
            _clientApi = new Client(config.GetSection("APIurl").Value, new System.Net.Http.HttpClient());
        }
    }
}

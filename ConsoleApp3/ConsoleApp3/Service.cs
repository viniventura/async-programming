using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public static class Service
    {

        public static string GetPageUol()
        {
            HttpClient httpClient = new HttpClient();
            var httpResponseMessage = httpClient.GetAsync("https://www.uol.com.br/").Result;
            return httpResponseMessage.Content.ReadAsStringAsync().Result;
        }

        public static async Task<string> GetPageUolAsync()
        {
            HttpClient httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.GetAsync("https://www.uol.com.br/");
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }

        public static async Task<string> GetPageTerraAsync()
        {
            HttpClient httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.GetAsync("https://www.terra.com.br/");
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Xamarin_GitHub.Data.Api
{
    public static class ApiConnection
    {
        public const string HostUrl = "https://api.github.com";

        private static HttpClient BuildClient()
        {
            var client = new HttpClient {MaxResponseContentBufferSize = 256000};
            return client;
        }

        public static async Task<string> DoGet(string endpoint)
        {
            var uri = new Uri(endpoint);
            var client = BuildClient();
            var response = await client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                return "";
            }
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
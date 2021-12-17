using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MekajikiPtyPlayer.Connection
{
    public static class Api
    {
        public static async Task<string> GetTokenAsync(IPAddress server, string name, string token)
        {
            string uri =  "/api/v1/GenerateToken";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://" + server);
            client.DefaultRequestHeaders.Add("user", name);
            client.DefaultRequestHeaders.Add("otp", token);
            var response = await client.PostAsync(uri, null);
            response.EnsureSuccessStatusCode();
            return response.Content.ToString();
        }
    }
}
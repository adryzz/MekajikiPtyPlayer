using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MekajikiPtyPlayer.Connection
{
    public static class Api
    {
        public static string GetToken(Uri server, string name, string token)
        {
            using HttpClient client = new HttpClient();
            
            string endpoint =  "api/v1/GenerateToken";
            Uri uri = new Uri(server + endpoint);
            using HttpRequestMessage message = new HttpRequestMessage();
            
            message.Method = HttpMethod.Post;
            message.RequestUri = uri;
            message.Headers.Add("user", name);
            message.Headers.Add("otp", token);
            message.Content = null;
            
            var response = client.Send(message);
            response.EnsureSuccessStatusCode();
            return response.Content.ToString();
        }
    }
}
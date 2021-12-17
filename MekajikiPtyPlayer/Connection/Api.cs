using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using MekajikiPtyPlayer.Types;

namespace MekajikiPtyPlayer.Connection
{
    public static class Api
    {
        public static string GetToken(Uri server, string name, string token)
        {
            string endpoint =  "api/v1/GenerateToken";
            Uri uri = new Uri(server + endpoint);
            using HttpRequestMessage message = new HttpRequestMessage();
            
            message.Method = HttpMethod.Post;
            message.RequestUri = uri;
            message.Headers.Add("user", name);
            message.Headers.Add("otp", token);
            message.Content = null;
            
            var response = call(message);
            response.EnsureSuccessStatusCode();
            return response.Content.ToString();
        }

        public static IEnumerable<AnimeSeries> GetAnimeListing(Uri server, string token)
        {
            string endpoint =  "api/v1/GetAnimeListing";
            Uri uri = new Uri(server + endpoint);
            using HttpRequestMessage message = new HttpRequestMessage();
            
            message.Method = HttpMethod.Get;
            message.RequestUri = uri;
            message.Headers.Add("token", token);
            message.Content = null;
            
            var response = call(message);
            response.EnsureSuccessStatusCode();
            
            string json = response.Content.ReadAsStringAsync().Result;

            var listing = JsonSerializer.Deserialize<AnimeListing>(json);

            return listing.Series;
        }
        
        
        private static HttpResponseMessage? call(HttpRequestMessage message)
        {
            #if DEBUG
            using var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = 
                (httpRequestMessage, cert, cetChain, policyErrors) => true;
            
            using HttpClient client = new HttpClient(handler);
            #else
            using HttpClient client = new HttpClient();
            #endif
            return client.Send(message);
        }
    }
}
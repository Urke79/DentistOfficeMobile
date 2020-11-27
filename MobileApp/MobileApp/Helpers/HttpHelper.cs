using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Helpers
{
    public class HttpHelper
    {
        // TO DO - dependency inject this one
        static HttpClient httpClient = new HttpClient();
        public async static Task SendRequestAsync<T>(HttpMethod httpMethod, string apiUrl, T selectedObject)
        {
            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(apiUrl),
                Content = new StringContent(JsonConvert.SerializeObject(selectedObject), Encoding.UTF8, "application/json")
            };

            await httpClient.SendAsync(request);
        }
    }
}

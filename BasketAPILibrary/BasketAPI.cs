using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BasketAPILibrary
{
    internal class BasketAPI : IBasketAPI
    {
        private readonly Uri baseUri = new Uri("http://127.0.0.1:9005/api/basket/");

        public async Task<bool> ChangeItemAsync(int itemId, int quantity)
        {
            HttpClient c = new HttpClient();
            c.BaseAddress = baseUri;

            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("itemId", itemId.ToString()),
                new KeyValuePair<string, string>("quantity", quantity.ToString()),
            });

            HttpResponseMessage response = await c.PostAsync("", stringContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ClearCartAsync()
        {
            HttpClient c = new HttpClient();
            c.BaseAddress = baseUri;

            HttpResponseMessage response = await c.DeleteAsync(baseUri);

            return response.IsSuccessStatusCode;
        }
    }
}

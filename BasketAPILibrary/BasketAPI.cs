using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasketAPILibrary
{
    internal class BasketAPI : IBasketAPI
    {
        public BasketAPI(BasketOptions configure)
        {
            Url = configure.Url;
            baseUri = new Uri(Url);
        }

        private Uri baseUri;
        private string Url;

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

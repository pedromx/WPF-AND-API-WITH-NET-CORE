using PROJECT.UI.models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PROJECT.UI.providers
{
    public class CustomProvider : ICustomProvider
    {
        private const string URL = "https://localhost:44323/TextProcess";
        public async Task<List<string>> GetOrderOptions()
        {
            var api = $"{URL}/options";
            var response = await HttpGet(api);
            var result = JsonConvert.DeserializeObject<List<string>>(response);
            return result;
        }

        public async Task<string> GetOrderedText(TextOrder textOrder)
        {
            var text = textOrder.Text.RemoveCarriageReturn();
            var api = $"{URL}/{text}/order/{textOrder.Option}";
            var response = await HttpGet(api);

            return response;
        }

        public async Task<string> GetTextStatistics(string text)
        {
            var txt = text.RemoveCarriageReturn();
            var api = $"{URL}/{txt}/statistics/";
            var response = await HttpGet(api);
            return response;
        }

        private async Task<string> HttpGet(string URL)
        {
            using (var client = new HttpClient())
            {
                var getResponse = await client.GetAsync(URL);

                var result = await getResponse.Content.ReadAsStringAsync();

                return result;
            }
        }
    }
}

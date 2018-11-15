using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DNC.Core;
using DNC.Core.Configuration;
using DNC.Core.Domain.Common;
using DNC.Core.Domain.Walmart;
using DNC.Core.Domain.Walmart.Items;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DNC.Data.Walmart
{
    public class WalmartService : IWalmartServiceContext
    {
        private readonly WalmartApiConfig walmartApiConfig;

        public WalmartService(IOptions<WalmartApiConfig> walmartApiConfig)
        {
            this.walmartApiConfig = walmartApiConfig.Value;
        }

        public async Task<ItemSearch> SearchItemByTextAsync(string searchText)
        {
            ItemSearch itemSearch = null;
            var path = "search?apiKey=" + this.walmartApiConfig.API_KEY + "&query=" + searchText;
            var result = await CallWalmartApi(path);
            var serializedItems = JsonConvert.DeserializeObject<ItemSearch>(result.Content);
            itemSearch = serializedItems != null ? serializedItems : throw new Exception("Results not found");
            return itemSearch;
        }

        public async Task<List<Item>> GetItemByItemIdAsync(string itemId)
        {
            List<Item> items = null;
            var path = "items?ids=" + itemId + "&apiKey=" + this.walmartApiConfig.API_KEY;
            var result = await CallWalmartApi(path);
            var serializedItems = JsonConvert.DeserializeObject<Root>(result.Content);
            items = serializedItems.items != null ? serializedItems.items.ToList() : null;
            return items;
        }

        public async Task<List<ItemRecommendation>> GetItemRecommendationByItemIdAsync(string itemId)
        {
            List<ItemRecommendation> itemRecommendation = null;
            var path = "nbp?apiKey=" + this.walmartApiConfig.API_KEY + "&itemId=" + itemId;
            var result = await CallWalmartApi(path);
            var serializedItems = JsonConvert.DeserializeObject<List<ItemRecommendation>>(result.Content);
            itemRecommendation = serializedItems != null ? serializedItems : throw new Exception(result.Content);
            return itemRecommendation;
        }

      
        private async Task<HttpResponse> CallWalmartApi(string path)
        {
            var result = new HttpResponse();

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(this.walmartApiConfig.BASE_API_URI)
            };

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    result.StatusCode = response.StatusCode;
                    result.Content = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }

    
}

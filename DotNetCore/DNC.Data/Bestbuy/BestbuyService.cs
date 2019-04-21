using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DNC.Core;
using DNC.Core.Configuration;
using DNC.Core.Domain.Bestbuy.Products;
using DNC.Core.Domain.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DNC.Data.Bestbuy
{
    public class BestbuyService : IBestbuyServiceContext
    {
        private readonly BestbuyApiConfig bestbuyApiConfig;

        public BestbuyService(IOptions<BestbuyApiConfig> bestbuyApiConfig)
        {
            this.bestbuyApiConfig = bestbuyApiConfig.Value;
        }
        public async Task<ProductSearch> SearchProductByTextAsync(string searchText)
        {
            ProductSearch productSearch = null;
            var path = $"products(search={searchText})?format=json&apiKey={this.bestbuyApiConfig.API_KEY}";
            var result = await CallBestbuyApi(path);

            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

            try
            {
                var serializedSearchResult = JsonConvert.DeserializeObject<ProductSearch>(result.Content, jsonSerializerSettings);
                productSearch = serializedSearchResult != null ? serializedSearchResult : throw new Exception("Results not found");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return productSearch;

        }

        private async Task<HttpResponse> CallBestbuyApi(string path)
        {
            var result = new HttpResponse();

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(this.bestbuyApiConfig.BASE_API_URI)
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

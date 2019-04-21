using DNC.Core.Domain.Store;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace XStoreMvcApp.Services
{
    public class XStoreWebApi : IXStoreService
    {
        //private readonly IOptions<AwsCognitoSettings> cognitoSettings;
        //private ITokenService _tokenService;
        //public WalmartStoreWebapi(ITokenService tokenService, IOptions<AwsCognitoSettings> cognitoSettings)
        //{
        //    _tokenService = tokenService;
        //    this.cognitoSettings = cognitoSettings;
        //}
        //private readonly string walmartApiBaseUri = "https://localhost:44326/api/";
        private readonly string xStoreApiBaseUri = "http://localhost:50050/api/";

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            var _client = new HttpClient();
            Product product = null;
            var path = "products/" + productId;
            _client.BaseAddress = new Uri(xStoreApiBaseUri); // this.cognitoSettings.Value.WalMartApiBaseUri);
            //var token = await _tokenService.GetTokenAsync();
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    product = JsonConvert.DeserializeObject<Product>(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }

        public async Task<List<Recommendation>> GetProductRecommendationsByIdAsync(string productId)
        {
            var _client = new HttpClient();
            List<Recommendation> productRecommendations = null;
            var path = "products/" + productId + "/recommendations";
            _client.BaseAddress = new Uri(xStoreApiBaseUri);
            //var token = await _tokenService.GetTokenAsync();
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var serializedRecommendations = JsonConvert.DeserializeObject<List<Recommendation>>(result);

                    productRecommendations = serializedRecommendations != null ? serializedRecommendations : throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No recommendation is found for this product");
            }
            return productRecommendations;
        }

        public async Task<SearchResult> SearchProductAsync(string searchTerm)
        {
            var _client = new HttpClient();
            SearchResult productSearch = null;
            var path = "search/" + searchTerm;
            _client.BaseAddress = new Uri(xStoreApiBaseUri);
            //var token = await _tokenService.GetTokenAsync();
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var serializedResult = JsonConvert.DeserializeObject<SearchResult>(result);
                    productSearch = serializedResult != null ? serializedResult : throw new Exception("Results not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productSearch;
        }
    }
}

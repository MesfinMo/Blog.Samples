using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DNC.Core.Data;
using DNC.Core.Domain.Store;

namespace DNC.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryRest walmartRepository;

        public ProductService(IRepositoryRest walmartRepository)
        {
            this.walmartRepository = walmartRepository;
        }
        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return (await this.walmartRepository.GetProductByProductIdAsync(productId))?[0];
        }

        public async Task<List<Recommendation>> GetProductRecommendationByIdAsync(string productId)
        {
            return await this.walmartRepository.GetRecommendationsByProeuctIddAsync(productId);
        }

        public async Task<SearchResult> SearchProductByTextAsync(string searchText)
        {
            return await this.walmartRepository.SearchProductByTextAsync(searchText);
        }
    }
}

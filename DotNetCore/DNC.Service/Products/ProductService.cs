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
        private readonly IRepositoryRest xStoreRepository;

        public ProductService(IRepositoryRest xStoreRepository)
        {
            this.xStoreRepository = xStoreRepository;
        }
        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return (await this.xStoreRepository.GetProductByProductIdAsync(productId))?[0];
        }

        public async Task<List<Recommendation>> GetProductRecommendationByIdAsync(string productId)
        {
            return await this.xStoreRepository.GetRecommendationsByProeuctIddAsync(productId);
        }

        public async Task<SearchResult> SearchProductByTextAsync(string searchText)
        {
            return await this.xStoreRepository.SearchProductByTextAsync(searchText);
        }
    }
}

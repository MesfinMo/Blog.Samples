using DNC.Core.Domain.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Service.Products
{
    public interface IProductService
    {
        Task<SearchResult> SearchProductByTextAsync(string searchText);
        Task<Product> GetProductByIdAsync(string productId);
        Task<List<Recommendation>> GetProductRecommendationByIdAsync(string productId);
    }
}

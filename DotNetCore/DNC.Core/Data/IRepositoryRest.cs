using DNC.Core.Domain.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Core.Data
{
    public interface IRepositoryRest
    {
        Task<SearchResult> SearchProductByTextAsync(string searchText);
        Task<List<Product>> GetProductByProductIdAsync(string productId);
        Task<List<Recommendation>> GetRecommendationsByProeuctIddAsync(string productId);
    }
}

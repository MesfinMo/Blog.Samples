using DNC.Core.Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XStoreMvcApp.Services
{
    public interface IXStoreService
    {
        Task<SearchResult> SearchProductAsync(string searchTerm);
        Task<Product> GetProductByIdAsync(string productId);
        Task<List<Recommendation>> GetProductRecommendationsByIdAsync(string productId);
    }
}
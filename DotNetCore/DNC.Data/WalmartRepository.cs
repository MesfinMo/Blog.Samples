using DNC.Core.Data;
using DNC.Core.Domain.Store;
using DNC.Data.Walmart;
using DNC.Data.Infrastrucure.Mapper.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DNC.Core.Domain.Walmart.Items;
using DNC.Core;
using System.Linq;

namespace DNC.Data
{
    public class WalmartRepository : IRepositoryRest
    {
        #region Fields
        private readonly IWalmartServiceContext serviceContext;

        #endregion
        public WalmartRepository(IWalmartServiceContext serviceContext)
        {
            this.serviceContext = serviceContext;
        }

        public async Task<List<Product>> GetProductByProductIdAsync(string productId)
        {
            var items = await this.serviceContext.GetItemByItemIdAsync(productId);
            return items.Select(item => item.ToDomain<Product>()).ToList();
        }

        public async Task<List<Recommendation>> GetRecommendationsByProeuctIddAsync(string productId)
        {
            var itemRecoms = await this.serviceContext.GetItemRecommendationByItemIdAsync(productId);
            return itemRecoms.Select(recom => recom.ToDomain<Recommendation>()).ToList();
        }

        public async Task<SearchResult> SearchProductByTextAsync(string searchText)
        {
            var searchResult = await this.serviceContext.SearchItemByTextAsync(searchText);
            return searchResult.ToDomain<SearchResult>();
        }
    }
}

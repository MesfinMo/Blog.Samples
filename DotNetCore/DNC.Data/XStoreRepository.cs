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
using DNC.Data.Bestbuy;

namespace DNC.Data
{
    public class XStoreRepository : IRepositoryRest
    {
        #region Fields
        private readonly IWalmartServiceContext serviceContext;
        private readonly IBestbuyServiceContext bestbuyServiceContext;


        #endregion
        public XStoreRepository(IWalmartServiceContext serviceContext, IBestbuyServiceContext bestbuyServiceContext)
        {
            this.serviceContext = serviceContext;
            this.bestbuyServiceContext = bestbuyServiceContext;
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
            var bestbuySearchResult = await this.bestbuyServiceContext.SearchProductByTextAsync(searchText);
            bestbuySearchResult.resultSize = bestbuySearchResult.to - bestbuySearchResult.from + 1;
            var bestbuyResultDomain = bestbuySearchResult.ToDomain<SearchResult>();
            bestbuyResultDomain.SearchProducts.ForEach(x => x.Product.ProductSource = ProductSourceType.Bestbuy.ToString());
            var walmartResultDomain =  searchResult.ToDomain<SearchResult>();
            walmartResultDomain.SearchProducts.ForEach(x => x.Product.ProductSource = ProductSourceType.Walmart.ToString());
            walmartResultDomain.TotalResult += bestbuyResultDomain.TotalResult;
            walmartResultDomain.ResultSize += bestbuyResultDomain.ResultSize;
            walmartResultDomain.SearchProducts.AddRange(bestbuyResultDomain.SearchProducts);
            return walmartResultDomain;
        }

        public SearchResult MergeSearchResults(List<SearchResult> searchResults)
        {
            var result = new SearchResult();
            if(searchResults != null && searchResults.Count > 0)
            {
                foreach(var searchResult in searchResults)
                {

                }
            }
            return result;
        }
    }
}

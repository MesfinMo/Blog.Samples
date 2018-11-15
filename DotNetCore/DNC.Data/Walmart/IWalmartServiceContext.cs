using DNC.Core;
using DNC.Core.Domain.Walmart.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Data.Walmart
{
    public partial interface IWalmartServiceContext
    {
        Task<ItemSearch> SearchItemByTextAsync(string searchText);
        Task<List<Item>> GetItemByItemIdAsync(string itemId);
        Task<List<ItemRecommendation>> GetItemRecommendationByItemIdAsync(string itemId);
    }

}

using DNC.Core;
using DNC.Core.Data;
using DNC.Core.Domain.Walmart.Items;
using DNC.Data.Walmart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Data
{
    public partial class ApiRepository
    {
        #region Fields
        private readonly IWalmartServiceContext serviceContext;

        #endregion

        #region Ctor
        public ApiRepository(IWalmartServiceContext serviceContext)
        {
            this.serviceContext = serviceContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entities by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public async Task<List<Item>> GetByIdAsync(string id)
        {
            return await this.serviceContext.GetItemByItemIdAsync(id);
        }

        /// <summary>
        /// Search Item By Search Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<ItemSearch> SearchByTextAsync(string text)
        {
            return await this.serviceContext.SearchItemByTextAsync(text);
        }

        /// <summary>
        /// Get Item recommendations By idt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<ItemRecommendation>> GetRecommendationsByIdAsync(string id)
        {
            return await this.serviceContext.GetItemRecommendationByItemIdAsync(id);
        }
        #endregion
    }
}

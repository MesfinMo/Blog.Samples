using DNC.Core;
using DNC.Core.Domain.Bestbuy.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Data.Bestbuy
{
    public interface IBestbuyServiceContext
    {
        Task<ProductSearch> SearchProductByTextAsync(string searchText);

    }
}

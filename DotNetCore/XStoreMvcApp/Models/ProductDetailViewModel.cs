using DNC.Core.Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XStoreMvcApp.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<Recommendation> Recommendations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Store
{
    public class SearchProduct : BaseDomain
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}

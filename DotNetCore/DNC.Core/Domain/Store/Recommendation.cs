using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Store
{
    public class Recommendation : BaseDomain
    {
        public string ProductId { get; set; }
        public string OfferType { get; set; }
        public bool IsTwoDayShippingEligible { get; set; }

        public Product Product { get; set; }
    }
}

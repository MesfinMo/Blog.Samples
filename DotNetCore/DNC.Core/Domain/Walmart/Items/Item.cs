using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Walmart.Items
{
    public class Item : BaseResponse
    {
        public string itemId { get; set; }
        public int parentItemId { get; set; }
        public string name { get; set; }
        public double salePrice { get; set; }
        public string categoryPath { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string brandName { get; set; }
        public string thumbnailImage { get; set; }
        public string mediumImage { get; set; }
        public string largeImage { get; set; }
        public string productTrackingUrl { get; set; }
        public double standardShipRate { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public bool marketplace { get; set; }
        public string sellerInfo { get; set; }
        public string productUrl { get; set; }
        public string customerRating { get; set; }
        public int numReviews { get; set; }
        public string customerRatingImage { get; set; }
        public string categoryNode { get; set; }
        public bool bundle { get; set; }
        public bool clearance { get; set; }
        public bool preOrder { get; set; }
        public string stock { get; set; }
        public Attribute attributes { get; set; }
        public string addToCartUrl { get; set; }
        public string affiliateAddToCartUrl { get; set; }
        public bool freeShippingOver35Dollars { get; set; }
        public bool availableOnline { get; set; }
        public bool isTwoDayShippingEligible { get; set; }
    }
}

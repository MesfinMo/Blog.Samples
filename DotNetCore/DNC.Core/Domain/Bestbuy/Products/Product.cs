using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Bestbuy.Products
{
    public class Product
    {
        public long sku { get; set; }
        public string score { get; set; }
        public string productId { get; set; }
        public string name { get; set; }
        public string source { get; set; }
        public string type { get; set; }
        public string startDate { get; set; }

        [JsonProperty(PropertyName = "new")]
        public bool New { get; set; }
        public bool active { get; set; }
        public bool lowPriceGuarantee { get; set; }
        public string activeUpdateDate { get; set; }
        public double regularPrice { get; set; }
        public double salePrice { get; set; }
        public bool clearance { get; set; }
        public bool onSale { get; set; }
        public string planPrice { get; set; }
        public Image[] images { get; set; }
        public string image { get; set; }
        public string largeFrontImage { get; set; }
        public string mediumImage { get; set; }
        public string thumbnailImage { get; set; }
        public string largeImage { get; set; }
        public string shortDescription { get; set; }

    }
}

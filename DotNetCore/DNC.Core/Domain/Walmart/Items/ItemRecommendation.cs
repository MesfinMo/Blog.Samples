using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Walmart.Items
{
    public class ItemRecommendation : Item
    {
        public GiftOptions giftOptions { get; set; }
        public ImageEntity[] imageEntities { get; set; }
        public string offerType { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Walmart.Items
{
    public class ImageEntity
    {
        public string thumbnailImage { get; set; }
        public string mediumImage { get; set; }
        public string largeImage { get; set; }
        public string entityType { get; set; }
    }
}

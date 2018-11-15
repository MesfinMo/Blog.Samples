using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Walmart.Items
{
    public class ItemSearch : BaseResponse
    {
        public string query { get; set; }
        public string sort { get; set; }
        public string responseGroup { get; set; }
        public int totalResults { get; set; }
        public int start { get; set; }
        public int numItems { get; set; }
        public Item[] items { get; set; }
    }
}

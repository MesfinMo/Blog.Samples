using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Bestbuy.Products
{
    public class ProductSearch : BaseResponse
    {
        public string sort { get; set; }
        public string searchTerm { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public int resultSize { get; set; }
        public int currentPage { get; set; }
        public int total { get; set; }
        public int totalPages { get; set; }
        public double queryTime { get; set; }
        public double totalTime { get; set; }
        public bool partial { get; set; }
        public string canonicalUrl { get; set; }
        public Product[] products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Domain.Store
{
    public class SearchResult : BaseDomain
    {
        public string SearchTerm { get; set; }
        public string SortOrder { get; set; }
        public int TotalResult { get; set; }
        public int Index { get; set; }
        public int ResultSize { get; set; }
        public List<SearchProduct> SearchProducts { get; set; }
    }
}

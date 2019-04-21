using System;
using System.Collections.Generic;
using System.Text;

namespace DNC.Core.Configuration
{
    public class BestbuyApiConfig : ISettings
    {
        public string BASE_API_URI { get; set; }
        public string API_KEY { get; set; }
    }
}

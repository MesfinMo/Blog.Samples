using DNC.Core.Configuration;
using DNC.Core.Domain.Bestbuy.Products;
using DNC.Data.Bestbuy;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Data.Tests.BestbuyApi
{
    [TestClass]
    public class TestBestbuyApi
    {
        IBestbuyServiceContext bestbuyService;
        private static BestbuyApiConfig bestbuyApiConfig;

        [ClassInitialize]
        public static void Initialize(TestContext testContext) 
        //https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2017
        {
            bestbuyApiConfig = new BestbuyApiConfig()
            {
                API_KEY = testContext.Properties["BESTBUY_API_KEY"].ToString(),
                BASE_API_URI = testContext.Properties["BESTBUY_BASE_API_URI"].ToString()
            };
        }

        [TestMethod]
        public async Task SearchProductByText_ShouldReturnProductsForGivenSearchTerm()
        {

            var mock = new Mock<IOptions<BestbuyApiConfig>>();
            mock.Setup(m => m.Value).Returns(bestbuyApiConfig);

            bestbuyService = new BestbuyService(mock.Object);

            var searchTerm = "ipad";

            var result = await bestbuyService.SearchProductByTextAsync(searchTerm); // as ProductSearch;

            Assert.IsTrue(result.products[0].name.ToLower().Contains(searchTerm));

        }
    }
}

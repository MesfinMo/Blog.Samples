using DNC.Core.Configuration;
using DNC.Data.Walmart;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Data.Tests.WalmartApi
{
    [TestClass]
    public class TestWalmartApi
    {
        IWalmartServiceContext walmartService;
        private static WalmartApiConfig walmartApiConfig;

        [ClassInitialize]
        public static void Initialize(TestContext testContext) //https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2017
        {
            walmartApiConfig = new WalmartApiConfig()
            {
                API_KEY = testContext.Properties["API_KEY"].ToString(),
                BASE_API_URI = testContext.Properties["BASE_API_URI"].ToString()
            };
        }

        [TestMethod]
        public async Task GetItemByItemId_ShouldReturnItemForGivenItemId()
        {

            var mock = new Mock<IOptions<WalmartApiConfig>>();
            mock.Setup(m => m.Value).Returns(walmartApiConfig);

            walmartService = new WalmartService(mock.Object);

            var itemId = "12417832";

            var result = await walmartService.GetItemByItemIdAsync(itemId);

            Assert.AreEqual(result[0].itemId, itemId);

        }
    }
}

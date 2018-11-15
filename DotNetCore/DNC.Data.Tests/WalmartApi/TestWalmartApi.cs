using DNC.Core.Configuration;
using DNC.Data.Walmart;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Data.Tests.WalmartApi
{
    [TestClass]
    public class TestWalmartApi
    {
        IWalmartServiceContext walmartService;

        [TestMethod]
        public async Task GetItemByItemId_ShouldReturnItemForGivenItemId()
        {
            var walmartConfig = new WalmartApiConfig()
            {
                API_KEY = "52txne3qyx4pnke2wxacsxff",
                BASE_API_URI = "http://api.walmartlabs.com/v1/"
            };

            var mock = new Mock<IOptions<WalmartApiConfig>>();
            mock.Setup(m => m.Value).Returns(walmartConfig);

            walmartService = new WalmartService(mock.Object);

            var itemId = "12417832";

            var result = await walmartService.GetItemByItemIdAsync(itemId);

            Assert.AreEqual(result[0].itemId, itemId);

        }
    }
}

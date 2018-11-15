using AutoMapper;
using DNC.Core.Data;
using DNC.Core.Domain.Walmart.Items;
using DNC.Core.Infrastructure.Mapper;
using DNC.Data.Infrastrucure.Mapper;
using DNC.Data.Walmart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Data.Tests.Repositories
{
    [TestClass]
    public class TestWalmartRepository
    {
        IRepositoryRest walmartRepository;

        [TestInitialize]
        public void TestInit()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.AddProfile(typeof(StoreMapperConfiguration));
            });

            AutoMapperConfiguration.Init(config);
        }


        [TestMethod]
        public async Task GetProductByProductIdAsync_ShouldReturnProductForGivenProductId()
        {
            var items = new Item[]  {
                new Item { itemId= "12417832" }
            };
            var itemId = "12417832";

            var mock = new Mock<IWalmartServiceContext>();
            mock.Setup(m => m.GetItemByItemIdAsync(itemId)).Returns(Task.FromResult(items.ToList()));

            walmartRepository = new WalmartRepository(mock.Object);


            var result = await walmartRepository.GetProductByProductIdAsync(itemId);

            Assert.AreEqual(result[0].ProductId, itemId);

        }

        [TestMethod]
        public async Task SearchProductByTextAsync_ShouldReturnSearchResultForSearchTex()
        {
            var searchItem = new ItemSearch { query = "ipod", items = new Item[] { new Item { itemId = "42608125" } } };

            var searchText = "ipod";

            var mock = new Mock<IWalmartServiceContext>();
            mock.Setup(m => m.SearchItemByTextAsync(searchText)).Returns(Task.FromResult(searchItem));

            walmartRepository = new WalmartRepository(mock.Object);


            var result = await walmartRepository.SearchProductByTextAsync(searchText);

            Assert.AreEqual(result.SearchTerm, searchText);
            mock.VerifyAll();

        }

        [TestMethod]
        public async Task GetRecommendationsByProeuctIddAsync_ShouldReturnRecommendationsForProduct()
        {
            var recommendations = new List<ItemRecommendation>() { new ItemRecommendation { itemId = "42608125", name = "Onn by Walmart skin for apple ipod touch", offerType = "ONLINE_AND_STORE" } };
            var recommendItemId = "12417832";

            var mock = new Mock<IWalmartServiceContext>();
            mock.Setup(m => m.GetItemRecommendationByItemIdAsync(recommendItemId)).Returns(Task.FromResult(recommendations));

            walmartRepository = new WalmartRepository(mock.Object);


            var result = await walmartRepository.GetRecommendationsByProeuctIddAsync(recommendItemId);

            Assert.AreEqual(result[0].ProductId, "42608125");
            Assert.AreEqual(result[0].Product.ProductName, "Onn by Walmart skin for apple ipod touch");
            mock.VerifyAll();

        }
    }
}

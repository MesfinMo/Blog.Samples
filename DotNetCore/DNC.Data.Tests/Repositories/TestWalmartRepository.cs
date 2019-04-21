using AutoMapper;
using DNC.Core.Data;
using DNC.Core.Domain.Bestbuy.Products;
using DNC.Core.Domain.Walmart.Items;
using DNC.Core.Infrastructure.Mapper;
using DNC.Data.Bestbuy;
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
        IRepositoryRest xStoreRepository;

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

            var products = new Product[]  {
                new Product { productId = "1219661412848" }
            };
            var productId = "1219661412848";

            var mock = new Mock<IWalmartServiceContext>();
            var bbmock = new Mock<IBestbuyServiceContext>();

            mock.Setup(m => m.GetItemByItemIdAsync(itemId)).Returns(Task.FromResult(items.ToList()));

            xStoreRepository = new XStoreRepository(mock.Object, bbmock.Object);


            var result = await xStoreRepository.GetProductByProductIdAsync(itemId);

            Assert.AreEqual(result[0].ProductId, itemId);

        }

        [TestMethod]
        public async Task SearchProductByTextAsync_ShouldReturnSearchResultForSearchTex()
        {
            var searchItem = new ItemSearch { query = "ipod", items = new Item[] { new Item { itemId = "42608125" } } };

            var searchProduct = new ProductSearch { queryTime = 3.2, products = new Product[] { new Product { productId = "1219661412848" } } };

            var searchText = "ipod";

            var mock = new Mock<IWalmartServiceContext>();
            var bbmock = new Mock<IBestbuyServiceContext>();

            mock.Setup(m => m.SearchItemByTextAsync(searchText)).Returns(Task.FromResult(searchItem));

            xStoreRepository = new XStoreRepository(mock.Object, bbmock.Object);


            var result = await xStoreRepository.SearchProductByTextAsync(searchText);

            Assert.AreEqual(result.SearchTerm, searchText);
            mock.VerifyAll();

        }

        [TestMethod]
        public async Task GetRecommendationsByProeuctIddAsync_ShouldReturnRecommendationsForProduct()
        {
            var recommendations = new List<ItemRecommendation>() { new ItemRecommendation { itemId = "42608125", name = "Onn by Walmart skin for apple ipod touch", offerType = "ONLINE_AND_STORE" } };
            var recommendItemId = "12417832";

            var mock = new Mock<IWalmartServiceContext>();
            var bbmock = new Mock<IBestbuyServiceContext>();

            mock.Setup(m => m.GetItemRecommendationByItemIdAsync(recommendItemId)).Returns(Task.FromResult(recommendations));

            xStoreRepository = new XStoreRepository(mock.Object, bbmock.Object);


            var result = await xStoreRepository.GetRecommendationsByProeuctIddAsync(recommendItemId);

            Assert.AreEqual(result[0].ProductId, "42608125");
            Assert.AreEqual(result[0].Product.ProductName, "Onn by Walmart skin for apple ipod touch");
            mock.VerifyAll();

        }
    }
}

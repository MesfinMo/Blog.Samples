using DNC.Core.Data;
using DNC.Core.Domain.Store;
using DNC.Core.Domain.Walmart.Items;
using DNC.Service.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.Service.Tests.Products
{
    [TestClass]
    public class ProductServiceTests
    {
        
        [TestMethod]
        public async Task SearchProductByTextAsync_ShouldReturnSearchResultForSearchText()
        {
            var searchText = "ipod";
            var searchResult = new SearchResult();
            
            var products = new Product[] { new Product { ProductId = "42608125", ProductName = "Onn by Walmart skin for apple ipod touch" } };
            var searchProducts = new SearchProduct[] { new SearchProduct { Product = products[0], ProductId = "42608125" } };
            searchResult.SearchProducts = searchProducts.ToList();
            searchResult.SearchTerm = searchText;
            var mock = new Mock<IRepositoryRest>();
            mock.Setup(m => m.SearchProductByTextAsync(searchText)).Returns(Task.FromResult(searchResult));


            var productService = new ProductService(mock.Object);


            var result = await productService.SearchProductByTextAsync(searchText);

            Assert.AreEqual(result.SearchTerm, searchText);
            Assert.AreEqual(result.SearchProducts[0].Product.ProductId, "42608125");

        }

        [TestMethod]

        public async Task GetProductByIdAsync_ShouldReturnProductForGivenId()
        {
            var productId = "42608125";
            var products = new Product[] { new Product { ProductId = productId, ProductName = "Onn by Walmart skin for apple ipod touch" } };
            var mock = new Mock<IRepositoryRest>();
            mock.Setup(m => m.GetProductByProductIdAsync(productId)).Returns(Task.FromResult(products.ToList()));

            var productService = new ProductService(mock.Object);

            var result = await productService.GetProductByIdAsync(productId);

            Assert.AreEqual(result.ProductId, productId);

        }

        [TestMethod]

        public async Task GetProductRecommendationByIdAsync_ShouldReturnRecommendationsForProduct()
        {
            var productId = "12417832";
            var OfferType = "ONLINE_AND_STORE";


            var recommendations = new Recommendation[] { new Recommendation { ProductId = productId, OfferType = "ONLINE_AND_STORE" } };

            var mock = new Mock<IRepositoryRest>();

            mock.Setup(m => m.GetRecommendationsByProeuctIddAsync(productId)).Returns(Task.FromResult(recommendations.ToList()));

            var productService = new ProductService(mock.Object);

            var result = await productService.GetProductRecommendationByIdAsync(productId);

            Assert.IsTrue(result != null, "Should not return null");
            Assert.IsTrue(result.Count > 0, "Should return at least one recommendation");
            Assert.AreEqual(result[0].OfferType, OfferType);
            Assert.AreEqual(result[0].ProductId, productId);


        }
    }
}

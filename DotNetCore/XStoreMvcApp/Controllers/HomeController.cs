using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DNC.Core.Domain.Store;
using Microsoft.AspNetCore.Mvc;
using XStoreMvcApp.Models;
using XStoreMvcApp.Services;

namespace XStoreMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private IXStoreService xStoreService;

        public HomeController(IXStoreService xStoreService)
        {
            this.xStoreService = xStoreService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[Authorize]
        public async Task<IActionResult> SearchProduct(string searchTerm)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    string accessToken = await HttpContext.GetTokenAsync("access_token");
            //    string idToken = await HttpContext.GetTokenAsync("id_token");
            //    string expiresIn = await HttpContext.GetTokenAsync("expires_in");
            //    var jwtHandler = new JwtSecurityTokenHandler();
            //    var readableToken = jwtHandler.ReadToken(accessToken);
            //    // Now you can use them. For more info on when and how to use the
            //    // Access Token and ID Token, see https://auth0.com/docs/tokens
            //}

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var result = await this.xStoreService.SearchProductAsync(searchTerm);
                return PartialView("_SearchResult", result);
            }
            else
            {
                var result = new ErrorViewModel { ErrorMessage = "Please enter search term, and try again", ErrorLevel = ErrorLevel.Serious };
                return PartialView("_ErrorMessage", result);
            }

        }

        public async Task<IActionResult> ProductDetail(string productId)
        {
            var result = new ProductDetailViewModel();
            try
            {
                result.Product = await this.xStoreService.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                var err = new ErrorViewModel { ErrorMessage = ex.Message, ErrorLevel = ErrorLevel.Serious };
                return PartialView("_ErrorMessage", err);
            }
            try
            {
                result.Recommendations = await this.xStoreService.GetProductRecommendationsByIdAsync(productId);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.Recommendations = new List<Recommendation>();
            }
            return PartialView("_ProductDetail", result);
        }
    }
}

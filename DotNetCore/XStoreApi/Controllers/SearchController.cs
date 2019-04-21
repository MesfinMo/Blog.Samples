using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNC.Core.Domain.Store;
using DNC.Service.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductService productService;
        public SearchController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/Search
        //[Authorize(Policy = "WebUserReader")]
        [HttpGet("{query}", Name = "Get")]
        public async Task<ActionResult<SearchResult>> Get(string query)
        {
            //var usr = User.Claims;
            return await this.productService.SearchProductByTextAsync(query);
        }
    }
}
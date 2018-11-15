using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNC.Core.Domain.Store;
using DNC.Service.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WalmartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/Products/49053771
        //[Authorize(Policy = "WebUserReader")]
        [HttpGet("{productId}", Name = "GetProduct")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> Get(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest(productId);
            }

            var result = await this.productService.GetProductByIdAsync(productId);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // GET: api/Products/49053771/Recommendations
        //[Authorize(Policy = "WebUserReader")]
        [HttpGet("{productId}/recommendations", Name = "GetProductRecommendations")]
        public async Task<ActionResult<List<Recommendation>>> GetProductRecommendations(string productId)
        {
            return await this.productService.GetProductRecommendationByIdAsync(productId);
        }
    }
}
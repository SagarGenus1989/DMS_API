using GLink_API.Common;
using GLink_API.Interface;
using GLink_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GLink_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProductList")]
        public async Task<Response<List<ProductDto>>> GetProductList(string search, string token, long userId, int flag)
        {
            try
            {
                var result = await _productService.GetProductList(search, token, userId, flag);

                
                if (result == null || !result.Any())
                {
                    return new Response<List<ProductDto>>(404, ResponseMessage.NotFound, new List<ProductDto>());
                }

                return new Response<List<ProductDto>>(200, ResponseMessage.Success, result.ToList());
            }
            catch (Exception ex)
            {
                string errorMessage = $"{ex.Message}";
                return new Response<List<ProductDto>>((int)HttpStatusCode.InternalServerError, errorMessage, null);
            }
        }

    }
}

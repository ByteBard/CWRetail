using CWRetail.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWRetail.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "P1",
                    Price = 1.11,
                    Type = "Drink",
                    Active = true,
                }
            };

            return Ok(products);
        }
    }
}

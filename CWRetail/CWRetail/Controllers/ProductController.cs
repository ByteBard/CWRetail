using CWRetail.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CWRetail.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }
    }
}

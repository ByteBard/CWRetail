using CWRetail.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace CWRetail.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController
        : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string _invalidPriceMsg = "invalid price (should be 2 digit decimal)..";
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllProduct/{orderByAsc}/{sortBy?}")]
        public async Task<ActionResult<List<Product>>> Get(bool orderByAsc, string? sortBy = null)
        {
            switch (sortBy?.ToLower())
            {
                case "type":
                    if (orderByAsc) return Ok(await _context.Products.OrderBy(x => x.Type).ToListAsync());
                    return Ok(await _context.Products.OrderByDescending(x => x.Type).ToListAsync());
                case "price":
                    if (orderByAsc) return Ok(await _context.Products.OrderBy(x => x.Price).ToListAsync());
                    return Ok(await _context.Products.OrderByDescending(x => x.Price).ToListAsync());
                case "active":
                    if (orderByAsc) return Ok(await _context.Products.OrderBy(x => x.Active).ToListAsync());
                    return Ok(await _context.Products.OrderByDescending(x => x.Active).ToListAsync());
                default:
                    if (orderByAsc) return Ok(await _context.Products.OrderBy(x => x.Name).ToListAsync());
                    return Ok(await _context.Products.OrderByDescending(x => x.Name).ToListAsync());
            }

        }

        [HttpPost("CreateProduct/{name}/{price}/{type}/{active}")]
        public async Task<ActionResult> Create(string name, string price, string type, bool active)
        {
            var priceRegx = new Regex("[0-9]?[0-9]?(\\.[0-9][0-9]?)?");
            var isValidPrice = priceRegx.IsMatch(price);

            if (!isValidPrice || !double.TryParse(price, out var priceNum)) return BadRequest(_invalidPriceMsg);

            var product = new Product
            {
                Name = name,
                Price = priceNum,
                Type = type,
                Active = active
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok($"Id: {product.Id}, Name: {name} successfully created!");

        }

        [HttpPost("UpdateProduct/{id}/{name}/{price}/{type}/{active}")]
        public async Task<ActionResult> Update(int id, string name, string price, string type, bool active)
        {
            var priceRegx = new Regex("[0-9]?[0-9]?(\\.[0-9][0-9]?)?");
            var isValidPrice = priceRegx.IsMatch(price);

            if (!isValidPrice || !double.TryParse(price, out var priceNum)) return BadRequest(_invalidPriceMsg);
            var existingProduct = _context.Products.SingleOrDefault(b => b.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = name;
                existingProduct.Type = type;
                existingProduct.Price = priceNum;
                existingProduct.Active = active;
                await _context.SaveChangesAsync();
                return Ok($"Id: {existingProduct.Id}, Name: {name} successfully updated!");
            }

            return BadRequest($"Id: {id}, Name: {name} updated failed (no such record)!");
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingProduct = _context.Products.SingleOrDefault(b => b.Id == id);
            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                await _context.SaveChangesAsync();
                return Ok($"Id: {existingProduct.Id}, Name: {existingProduct} successfully deleted!");
            }

            return BadRequest($"Id: {id}, removed failed (no such record)!");
        }
    }
}

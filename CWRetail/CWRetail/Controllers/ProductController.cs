using CWRetail.Model;
using CWRetail.Provider;
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
        private readonly string _invalidTypeMsg = "Type should not be empty";
        private readonly string _invalidNameMsg = "Type should not be empty";
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllProduct/{orderByAsc}/{sortBy?}")]
        public async Task<ActionResult<List<Product>>> Get(bool orderByAsc, string? sortBy = null)
        {
            if (!_context.Products.Any())
            {
                var defaultData = ProductProvider.CreateDefaultData();
                await _context.Products.AddRangeAsync(defaultData);
                await _context.SaveChangesAsync();
            }

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
            if (string.IsNullOrEmpty(name)) return BadRequest(_invalidNameMsg);
            if (string.IsNullOrEmpty(type)) return BadRequest(_invalidTypeMsg);
            var priceRegx = new Regex("[0-9]?[0-9]?(\\.[0-9][0-9]?)?");
            var isValidPrice = priceRegx.IsMatch(price);

            if (!isValidPrice || !double.TryParse(price, out var priceNum)) return BadRequest(_invalidPriceMsg);

            var product = ProductProvider.CreateProduct(name, priceNum, type, active);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok($"Id: {product.Id}, Name: {name} successfully created!");

        }

        [HttpPost("UpdateProduct/{id}/{name}/{price}/{type}/{active}")]
        public async Task<ActionResult> Update(int id, string name, string price, string type, bool active)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest(_invalidNameMsg);
            if (string.IsNullOrEmpty(type)) return BadRequest(_invalidTypeMsg);
            var priceRegx = new Regex("[0-9]?[0-9]?(\\.[0-9][0-9]?)?");
            var isValidPrice = priceRegx.IsMatch(price);

            if (!isValidPrice || !double.TryParse(price, out var priceNum)) return BadRequest(_invalidPriceMsg);
            var existingProduct = _context.Products.SingleOrDefault(b => b.Id == id);
            if (existingProduct != null)
            {

                ProductProvider.GetUpdatedProduct(existingProduct, name, priceNum, type, active);
                await _context.SaveChangesAsync();
                return Ok($"Id: {existingProduct.Id}, Name: {name} successfully updated!");
            }

            return BadRequest($"Id: {id}, Name: {name} updated failed (no such record)!");
        }

        [HttpPost("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingProduct = ProductProvider.GetDeleteProduct(_context.Products.ToArray(), id);
            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                await _context.SaveChangesAsync();
                return Ok("successfully deleted!");
            }
            return BadRequest("delete failed");
        }
    }
}

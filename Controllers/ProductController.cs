using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using oshopAPI.Context;
using oshopAPI.Entities;

namespace oshopAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly OShopDbContext _context;

        public ProductController(OShopDbContext context)
        {
            _context = context;
        }

        //[HttpGet("categories")]
        //https://yourdomain.com/api/product
        [HttpGet]
        public IActionResult GetProducts()
        {
            var categories = _context.Products.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound(); // Return 404 Not Found if the product with the specified ID is not found.
            }

            return Ok(product);
        }

        // Additional API actions...

        //[HttpPost("create-category")]
        //https://yourdomain.com/api/category
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data");
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction("GetProducts", new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null || product.Id != id)
            {
                return BadRequest();
            }

            var productToUpdate = _context.Products.Find(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            productToUpdate.title = product.title;
            productToUpdate.price = product.price;
            productToUpdate.imageUrl = product.imageUrl;
            productToUpdate.category = product.category;

            _context.Products.Update(productToUpdate);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

    }

}

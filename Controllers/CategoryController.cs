using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using oshopAPI.Context;
using oshopAPI.Entities;

namespace oshopAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly OShopDbContext _context;

        public CategoryController(OShopDbContext context)
        {
            _context = context;
        }

        //[HttpGet("categories")]
        //https://yourdomain.com/api/category
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        // Additional API actions...

        //[HttpPost("create-category")]
        //https://yourdomain.com/api/category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Invalid category data");
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction("GetCategories", new { id = category.Id }, category);
        }
    }

}

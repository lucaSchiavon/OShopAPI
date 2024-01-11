using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using oshopAPI.Entities.Security;
using oshopAPI.Models.Security;

namespace oshopAPI.Controllers
{
    public class SecurityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SecurityController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    // Add any additional properties to the user object
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // You can customize the response as needed
                    return Ok(new { Message = "User created successfully." });
                }

                return BadRequest(new { Errors = result.Errors });
            }

            return BadRequest(new { Message = "Invalid registration data." });
        }


        [HttpGet("getUser/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                // You can customize the response as needed
                return Ok(new
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    // Include any additional user properties you want to expose
                });
            }

            return NotFound(new { Message = "User not found." });
        }

    }
}

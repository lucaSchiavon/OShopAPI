using Microsoft.AspNetCore.Identity;

namespace oshopAPI.Entities.Security
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties can be added here
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // You can add more custom properties based on your application's needs

        // Example: Custom method
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

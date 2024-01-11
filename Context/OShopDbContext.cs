using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using oshopAPI.Entities;
using oshopAPI.Entities.Security;
using System.Reflection.Emit;

namespace oshopAPI.Context
{
    public class OShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public OShopDbContext(DbContextOptions<OShopDbContext> options)
            : base(options)
        {
        }

        //Add any additional DbSet declarations for your application's models here
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>()
           .HasKey(c => c.Id);

            builder.Entity<Category>()
            .Property(c => c.Id)
            .ValueGeneratedNever();


            // builder.Ignore<IdentityUserLogin<string>>();
        }
    }
}

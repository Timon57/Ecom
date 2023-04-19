using Ecom.web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace Ecom.web.Data
{
    public class EcomDbContext :IdentityDbContext
    {
        public EcomDbContext(DbContextOptions<EcomDbContext>options):base(options)
        {
                
        }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ProductModel> Product { get; set; }

        //Data first approach
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryModel>().ToTable("Category");
            builder.Entity<ProductModel>().ToTable("Product");

            //builder.Ignore<ProductModel>();
            //builder.Ignore<CategoryModel>();

            base.OnModelCreating(builder);
        }
    }
}

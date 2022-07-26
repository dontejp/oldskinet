using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

// The Store Context talks directly to the database and stores and grabs data






namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {

        //Injecting the DBContextOptions is what allows us to use the DBSet
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }


        //Since were using EFCore we needed to set up the Entities we are working with
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
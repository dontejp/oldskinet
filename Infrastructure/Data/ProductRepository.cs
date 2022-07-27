using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();                    //??
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType) 
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
            /*line 29: finds the first line of data that matches what were looking for 
            we could replace this with SingleOrDefault... They do the same thing...
            however the later throws and exeption if there is duplicate the original does not
            */
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductType)    // when in postman these allow us to grab the product type and brand so it wont appear as null
                .Include(p => p.ProductBrand)
                .ToListAsync(); // this is the point where our query is sent to sql and get the data back
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
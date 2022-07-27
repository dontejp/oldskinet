using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]     //validates that the root parameter is an integar 
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //Below was used before we added the generic repository
        // private readonly IProductRepository _repo;

        // public ProductsController(IProductRepository repo)
        // {
        //     _repo = repo;
        // }
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;
            // _repo = repo;
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsRepo.ListAllAsync();

            return Ok(products);
        }

        //Below is expecting to see an integar below on line 36
        [HttpGet("{id}")]  
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productsRepo.GetByIdAsync(id);
        } 


        [HttpGet("brands")]

        /* IReadOnlyList
        Since were returning an IReadOnlyList we will get an error that 
        states we cant do this directly... 
        In order to get past this error we wrap everything in an Ok() statement.
        */

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}
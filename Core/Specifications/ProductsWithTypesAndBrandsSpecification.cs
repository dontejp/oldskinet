using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product> //we specify the type we are using here <Product>
    {

        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)      // "int?" dictates that this is anoptional parameter
            : base(x =>
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId ) &&  //checks for the value of the brandId ... if the left side of the || operator is false we execute the right side
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1),
            productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {

                switch(productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p=> p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            
        }
    }
}
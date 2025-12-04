using EticaretAPI.Application.Abstractions;
using EticaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetAllProducts()
         => new()
         {
             new() { Id = Guid.NewGuid(), Name = "Product 1", Stock = 100, Price = 200 },
             new() { Id = Guid.NewGuid(), Name = "Product 2", Stock = 100, Price = 200 },
             new() { Id = Guid.NewGuid(), Name = "Product 3", Stock = 100, Price = 200 },
             new() { Id = Guid.NewGuid(), Name = "Product 4", Stock = 100, Price = 200 },

         };
    }
}

using EticaretAPI.Application.Repositories;
using EticaretAPI.Application.ViewModels.Products;
using EticaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EticaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository productWriteRepository;
        readonly private IProductReadRepository productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            this.productWriteRepository = productWriteRepository;
            this.productReadRepository = productReadRepository;

        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(productReadRepository.GetAll(false));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
           return Ok(productReadRepository.GetByIdAsync(id,false));
        }   

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await productWriteRepository.AddAsync(new Product
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            });
            await productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }



        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product? updatedProduct = await productReadRepository.GetByIdAsync(model.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Name = model.Name;
                updatedProduct.Price = model.Price;
                updatedProduct.Stock = model.Stock;
                await productWriteRepository.SaveAsync();
                return Ok();
            }
            return NotFound();
        }
   

    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
             await productWriteRepository.RemoveAsync(id);
             await productWriteRepository.SaveAsync();
                return Ok();
        }
    }

}

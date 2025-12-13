 using EticaretAPI.Application.Repositories;
using EticaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EticaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository productWriteRepository;
        readonly private IProductReadRepository productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            this.productWriteRepository = productWriteRepository;
            this.productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await productWriteRepository.AddRangeAsync(new()
            //{
            //    new () {Id=Guid.NewGuid(),Name="Product1",Price=100, CreatedDate=DateTime.UtcNow,Stock=10},
            //    new () {Id=Guid.NewGuid(),Name="Product1",Price=200, CreatedDate=DateTime.UtcNow,Stock=20},
            //    new () {Id=Guid.NewGuid(),Name="Product1",Price=300, CreatedDate=DateTime.UtcNow,Stock=30},
            //});
            //await productWriteRepository.SaveAsync();
            Product p = await productReadRepository.GetByIdAsync("464dc0e4-195d-420b-8075-cdb2478b02a2",false);
            p.Name = "Test";
            await  productWriteRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
           Product product = await  productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}


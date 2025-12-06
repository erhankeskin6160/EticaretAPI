 using EticaretAPI.Application.Repositories;
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
        public async void Get() 
        {
          await  productWriteRepository.AddRangeAsync(new()
            {
                new () {Id=Guid.NewGuid(),Name="Product1",Price=100, CreatedDate=DateTime.UtcNow,Stock=10},
                new () {Id=Guid.NewGuid(),Name="Product1",Price=200, CreatedDate=DateTime.UtcNow,Stock=20},
                new () {Id=Guid.NewGuid(),Name="Product1",Price=300, CreatedDate=DateTime.UtcNow,Stock=30},
            });
            await productWriteRepository.SaveAsync();
        }
    }
}

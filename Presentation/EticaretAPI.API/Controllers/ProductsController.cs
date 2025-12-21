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
        readonly private IOrderWriteRepository orderWriteRepository;
        readonly private ICustomerWriteRepository customerWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            this.productWriteRepository = productWriteRepository;
            this.productReadRepository = productReadRepository;
            this.orderWriteRepository = orderWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await productWriteRepository.AddAsync(new()
            {
                Name = "Product 1",
                Price = 100,
                Stock = 10,
                CreatedDate = DateTime.UtcNow
            });
            await productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task Get(string id)
        {

            //Product product = await  productReadRepository.GetByIdAsync(id);
            // return Ok(product);
            var customerId = Guid.NewGuid();
            await customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Mesfd" });
            await orderWriteRepository.AddAsync(new() { Description = "sad", Adress = "dfdsff sadsad",CustomerId= customerId });
            await orderWriteRepository.SaveAsync();
        }

    }
}


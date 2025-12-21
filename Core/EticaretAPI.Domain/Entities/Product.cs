using EticaretAPI.Domain.Entities.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

        public int CustomerId { get; set; } 
        public ICollection<Order> Orders { get; set; }
    }

    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }  
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.Entities.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<ShopCartItem> OrderItems { get; set; } = new List<ShopCartItem>();
        public string UserLogin { get; set; }

    }
}

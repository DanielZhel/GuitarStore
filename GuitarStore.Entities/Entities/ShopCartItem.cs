using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GuitarStore.Entities.Entities
{
    public class ShopCartItem
    {
        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        public decimal Price { get; set; }
        [AllowNull]
        public string ShopCartId { get; set; }
    }
}

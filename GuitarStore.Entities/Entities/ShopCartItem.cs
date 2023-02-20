using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GuitarStore.Entities.Entities.Item;

namespace GuitarStore.Entities.Entities
{
    public class ShopCartItem
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string ModelName { get; set; }
        public string Descripton { get; set; }
        public int ItemId { get; set; }
        public string Image { get; set; }
        [AllowNull]
        public string ShopCartId { get; set; }
    }
}

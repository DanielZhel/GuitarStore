using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStore.Entities.Entities
{
    public class ShopCart
    {
        [AllowNull]
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }

    }
}

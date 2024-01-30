﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = null!;
        public Product Product { get; set; } = null!;

    }
}

﻿namespace SimplyHorsePower.Models
{
    public class AddCartItem
    {
        [Key]
        public int CartItemId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        public CartItem ToCartItem()
        {
            return new CartItem
            {
                CartItemId = CartItemId,
                Quantity = Quantity,
                DateCreated = DateCreated,
                ProductId = ProductId,
                ShoppingCartId = ShoppingCartId
               
            };
        }

    }
}

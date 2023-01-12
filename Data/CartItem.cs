namespace SimplyHorsePower.Data
{
    public class CartItem
    {
       
        [Key]
        public int CartItemId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        [Required]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }       

        [Required]
        [ForeignKey("ShoppingCartId")]
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}

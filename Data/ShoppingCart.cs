namespace SimplyHorsePower.Data
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }

        public System.DateTime DateCreated { get; set; }    

        [Required]
        [ForeignKey("NormalizedUserName")]
        public string NormalizedUserName { get; set; } 
        
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}

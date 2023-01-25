namespace SimplyHorsePower.Data
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}

        [Required]
        public string ProductName { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string MainProductImageLocation { get; set; }


        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }

        [ForeignKey("MakeId")]
        public string MakeId { get; set; }

        [NotMapped]
        public List<ProductGalleryImage> ProductGalleryImages { get; set; } = new List<ProductGalleryImage>();


    }
}

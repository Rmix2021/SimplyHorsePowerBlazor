namespace SimplyHorsePower.Data
{
    public class ProductGalleryImage
    {

        [Key]
        public int ProductGalleryImageId { get; set; }

        [Required]
        public string ProductGalleryImageName { get; set; }       

        [Required]
        public string ProductGalleryImageLocation { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

    }
}

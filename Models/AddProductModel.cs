namespace SimplyHorsePower.Models
{
    public class AddProductModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        public double ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public IFormFile MainImageData { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public string MakeId { get; set; }

        public List<ProductGalleryImage> ProductGalleryImages { get; set; } = new List<ProductGalleryImage>();

        public Product ToProduct()
        {
            return new Product
            {
                ProductName = ProductName,
                ProductPrice = ProductPrice,
                ProductDescription = ProductDescription,
                CategoryId = CategoryId,
                MakeId = MakeId,
                MainProductImage = ToByte()

            };
        }
        public byte[] ToByte()
        {
            IFormFile file = this.MainImageData;
            long length = file.Length;
            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);
            return bytes;
        }

    }
}

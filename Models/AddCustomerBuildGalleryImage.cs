namespace SimplyHorsePower.Models
{
    public class AddCustomerBuildGalleryImage
    {
        [Key]
        public int ProductGalleryImageId { get; set; }

        [Required]
        public string ProductGalleryImageName { get; set; }

        public int ProductId { get; set; }

        public IFormFile ProductGalleryByte { get; set; }



        public ProductGalleryImage ToProductGalleryImage()
        {
            return new ProductGalleryImage
            {
                ProductGalleryImageName = ProductGalleryImageName,
                ProductGalleryImageId = ProductGalleryImageId,
                ProductGalleryByte = ToByteProductGalleryImage(),
                ProductId = ProductId

            };
        }
        public byte[] ToByteProductGalleryImage()
        {
            IFormFile file = this.ProductGalleryByte;
            long length = file.Length;
            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);
            return bytes;
        }

    }
}

﻿namespace SimplyHorsePower.Models
{
    public class AddCustomerBuildGalleryImage
    {
        [Key]
        public int BuildGalleryImageId { get; set; }

        [Required]
        public string BuildGalleryImageName { get; set; }
      
        public int CustomerBuildId { get; set; }


        public IFormFile BuildGalleryByte { get; set; }

        public BuildGalleryImage ToBuildGalleryImage()
        {
            return new BuildGalleryImage
            {
                BuildGalleryImageName = BuildGalleryImageName,
                BuildGalleryImageId = BuildGalleryImageId,
                BuildGalleryByte = ToByteBuildGalleryImage(),
                CustomerBuildId = CustomerBuildId

            };
        }
        public byte[] ToByteBuildGalleryImage()
        {
            IFormFile file = this.BuildGalleryByte;
            long length = file.Length;
            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);
            return bytes;
        }
    }
}

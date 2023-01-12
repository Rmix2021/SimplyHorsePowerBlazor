﻿namespace SimplyHorsePower.Models
{
    public class AddCustomerBuild
    {

        [Key]
        public int CustomerBuildId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerBuildTitle { get; set; }

        [Required]
        public string CustomerBuildDescription { get; set; }

        //[Required]
        //public byte[] MainBuildImage { get; set; }

        public IFormFile MainImageData { get; set; }

        public List<BuildGalleryImage> BuildGalleryImages { get; set; } = new List<BuildGalleryImage>();


        public CustomerBuild ToCustomerBuild()
        {
            return new CustomerBuild
            {
                CustomerName = CustomerName,
                CustomerBuildTitle = CustomerBuildTitle,
                CustomerBuildDescription = CustomerBuildDescription,
                MainBuildImage = ToByte()

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

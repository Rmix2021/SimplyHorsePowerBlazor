namespace SimplyHorsePower.Data
{
    public class CustomerBuild
    {
        [Key]
        public int CustomerBuildId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerBuildTitle { get; set; }

        [Required]
        public string CustomerBuildDescription { get; set; }


        [Required]
        public string MainBuildImageLoation { get; set; }


        public List<BuildGalleryImage> BuildGalleryImages { get; set; } = new List<BuildGalleryImage>();
         

       
    }
}

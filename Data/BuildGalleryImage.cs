namespace SimplyHorsePower.Data
{
    public class BuildGalleryImage
    {
        [Key]
        public int BuildGalleryImageId { get; set; }

        [Required]
        public string BuildGalleryImageName { get; set; }

        [Required]
        public string BuildGalleryImageLocation { get; set; }

        [ForeignKey("CustomerBuildId")]
        public int CustomerBuildId { get; set; }
   

        
    }
}

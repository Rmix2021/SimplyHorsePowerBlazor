namespace SimplyHorsePower.Models
{
    public class AddMake
    {
        [Key]
        public int MakeId { get; set; }

        [Required]
        public string MakeName { get; set; }

        public Make ToMake()
        {
            return new Make
            {
                MakeId = MakeId,
                MakeName = MakeName
            };
        }
    }
}

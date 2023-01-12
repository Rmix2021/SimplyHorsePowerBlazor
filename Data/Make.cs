namespace SimplyHorsePower.Data
{
    public class Make
    {
        [Key]
        public int MakeId { get; set; }

        [Required]
        public string MakeName { get; set; }
    }
}

namespace SimplyHorsePower.Models
{
    public class AddCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public Category ToCategory()
        {
            return new Category
            {
                CategoryID = CategoryID,
                CategoryName = CategoryName
            };
        }
    }
}

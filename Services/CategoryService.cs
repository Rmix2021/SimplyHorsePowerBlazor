namespace SimplyHorsePower.Services
{
    public class CategoryService
    {
        public List<Category> Categories { get; set; }

        readonly ApplicationDbContext _context;

        readonly ILogger _logger;

        public CategoryService(ApplicationDbContext context, ILoggerFactory factory)
        {
            this._context = context;
            _logger = factory.CreateLogger<CategoryService>();
        }
        public void AddNewCategory(AddCategory name)
        {
            var category = name.ToCategory();
            _context.Add(category);
            _context.SaveChanges();
        }
        public Category GetACategory( int id)
        {
            return this._context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
        }
      
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var categoryList = await _context.Categories.ToListAsync();
            return categoryList;
        }

        public async Task<List<SelectListItem>> CategoryDropDownListAsync()
        {
            List<SelectListItem> DropDownList = new List<SelectListItem>();
            Categories = await GetAllCategoriesAsync();
            foreach (var category in Categories)
            {
                DropDownList.Add(new SelectListItem { Value = category.CategoryName, Text = category.CategoryName });
            }
            return DropDownList;
        }
    }
}

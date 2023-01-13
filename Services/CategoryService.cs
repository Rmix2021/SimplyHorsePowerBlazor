namespace SimplyHorsePower.Services
{
    public class CategoryService
    {
        public List<Category> Categories { get; set; }

        readonly ApplicationDbContext _context;


        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public CategoryService(ApplicationDbContext context, ILoggerFactory factory)
        {
            this._context = context;
        }
        public async Task<bool> AddNewCategoryAsync(Category name)
        {
            await _context.Categories.AddAsync(name);
            await _context.SaveChangesAsync();       ;
            return true;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category>  GetACategoryAsync( int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryID.Equals(id));
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

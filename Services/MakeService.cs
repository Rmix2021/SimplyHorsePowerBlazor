namespace SimplyHorsePower.Services
{
    public class MakeService
    {
        public List<Make> Makes { get; set; }

        readonly ApplicationDbContext _context;

        readonly ILogger _logger;

        public MakeService(ApplicationDbContext context, ILoggerFactory factory)
        {
            this._context = context;
            _logger = factory.CreateLogger<MakeService>();
        }

        public async Task<bool> AddNewMakeAsync(Make name)
        {
            await _context.Makes.AddAsync(name);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Make> GetAMakeAsync(int Id)
        {
            Make make = await _context.Makes.FirstOrDefaultAsync(c => c.MakeId.Equals(Id));
            return make;
        }
   
        public async Task<List<Make>> GetAllMakesAsync()
        {
            var makeList = await _context.Makes.ToListAsync();
            return makeList;
        }
      
        public async Task<List<SelectListItem>> MakeDropDownListAsync()
        {
            List<SelectListItem> DropDownList = new List<SelectListItem>();
            Makes = await GetAllMakesAsync();
            foreach(var make in Makes)
            {
                DropDownList.Add(new SelectListItem { Value = make.MakeName, Text = make.MakeName }); 
            }
            return DropDownList;
        }
      
    }
}

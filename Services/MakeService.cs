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
        public void AddNewMake(AddMake name)
        {
            var make = name.ToMake();
            _context.Add(make);
            _context.SaveChanges();
        }
        public List<Make> GetAllMakes()
        {
            var makeList = _context.Makes.ToList();
            return makeList;
        }

        public Make GetAMake(int id)
        {
            return this._context.Makes.Where(x => x.MakeId == id).FirstOrDefault();
        }

        public List<SelectListItem> MakeDropDownList()
        {
            List<SelectListItem> DropDownList = new List<SelectListItem>();
            Makes = GetAllMakes();
            foreach(var make in Makes)
            {
                DropDownList.Add(new SelectListItem { Value = make.MakeName, Text = make.MakeName }); 
            }
            return DropDownList;
        }
    }
}

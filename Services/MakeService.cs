namespace SimplyHorsePower.Services
{
    public class MakeService
    {
        public List<Make> Makes { get; set; }

        readonly ApplicationDbContext _context; 

        public MakeService(ApplicationDbContext context)
        {
            this._context = context;
            
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

        public async Task<bool> UpdateMakeAsync(Make make)
        {
            _context.Makes.Update(make);
            await _context.SaveChangesAsync();
            return true;
        }

        //public async task<list<selectlistitem>> makedropdownlistasync()
        //{
        //    list<selectlistitem> dropdownlist = new list<selectlistitem>();
        //    makes = await getallmakesasync();
        //    foreach(var make in makes)
        //    {
        //        dropdownlist.add(new selectlistitem { value = make.makeid.tostring(), text = make.makename }); 
        //    }
        //    return dropdownlist;
        //}
        public async Task<bool> DeleteMakeAsync(Make make)
        {
            _context.Remove(make);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

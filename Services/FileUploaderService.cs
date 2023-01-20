

namespace SimplyHorsePower.Services
{

    public class FileUploaderService
    {
        readonly ApplicationDbContext _context;
      

        public FileUploaderService(ApplicationDbContext context)
        {
            this._context = context;
      

        }

       
        public string MainProductImageLocation { get; set; }

    }
}

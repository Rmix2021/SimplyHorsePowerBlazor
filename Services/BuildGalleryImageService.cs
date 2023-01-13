namespace SimplyHorsePower.Services
{
    public class BuildGalleryImageService
    {
        readonly ApplicationDbContext _context;
        readonly ILogger _logger;

        public BuildGalleryImageService(ApplicationDbContext context, ILoggerFactory factory)
        {
            this._context = context;
            this._logger = factory.CreateLogger<BuildGalleryImageService>();
        }


        public async Task<bool> AddNewProductAsync(Product name)
        {
            await _context.Products.AddAsync(name);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddNewBuildGalleryImageAsync(BuildGalleryImage name)
        {
            await _context.buildGalleryImages.AddAsync(name);           
            await _context.SaveChangesAsync();
            return true;
        }

        public List<BuildGalleryImage> GetAllFilteredBuildGalleryImages(int id)
        {
            List<BuildGalleryImage> buildGalleryImages = new List<BuildGalleryImage>();
            var buildGalleryImageList = _context.buildGalleryImages
               .Where(x => x.CustomerBuildId == id);
            foreach (var buildGalleryImage in buildGalleryImageList)
            {
                buildGalleryImages.Add(buildGalleryImage);
            }
            return buildGalleryImages;
        }

        public BuildGalleryImage GetABuildGalleryImage(int id)
        {
            return this._context.buildGalleryImages.Where(x => x.BuildGalleryImageId == id).FirstOrDefault();
        }

    }
}

namespace SimplyHorsePower.Services
{
    public class ProductGalleryImageService
    {

        readonly ApplicationDbContext _context;
    

        public ProductGalleryImageService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddNewProductGalleryImage(ProductGalleryImage name)
        {
            await _context.productGalleryImages.AddAsync(name);
            await _context.SaveChangesAsync();
            return true;
        }

    
        public  List<ProductGalleryImage> GetAllFilteredProductGalleryImages(int id)
        {
            List<ProductGalleryImage> productGalleryImages = new List<ProductGalleryImage>();
            var productGalleryImageList = _context.productGalleryImages.Where(x => x.ProductId == id);

            foreach (var productGalleryImage in productGalleryImageList)
            {
                productGalleryImages.Add(productGalleryImage);
            }
            return productGalleryImages;
        }

        public async Task<ProductGalleryImage> GetAProductGalleryImageAsync(int Id)
        {
            ProductGalleryImage productGalleryImage = await _context.productGalleryImages.FirstOrDefaultAsync(c => c.ProductGalleryImageId.Equals(Id));
            return productGalleryImage;
        }
        public async Task<bool> DeleteProductGalleryImageAsync(ProductGalleryImage productGalleryImage)
        {

            _context.Remove(productGalleryImage);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

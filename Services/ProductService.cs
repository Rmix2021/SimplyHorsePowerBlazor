

using static SimplyHorsePower.Services.ProductService;

namespace SimplyHorsePower.Services
{
    public class ProductService
    {
        readonly ApplicationDbContext _context;
        //readonly FileUploaderService _fileUploaderContext;

        public ProductService(ApplicationDbContext context)
        {
            this._context = context;
            //this._fileUploaderContext = fileUploaderService;
          
        }
       
  
        public async Task<bool> DeleteProductAsync(Product product)
        {
            
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var productList = await _context.Products.ToListAsync();
            return productList;
        }
      
        public async Task<Product> GetAProductAsync(int Id)
        {
        Product product = await _context.Products.FirstOrDefaultAsync(c => c.ProductId.Equals(Id));
            return product;
        }

        public async Task<List<Product>> GetFilteredProductsByMakeAsync(string makeId)
        {
            var productList = await this._context.Products.Where(x =>x.MakeId == makeId).ToListAsync();
            return productList;
        }

        public async Task<List<Product>> GetFilteredProductsByCategoryAsync(string categoryId)
        {        
            var productList = await this._context.Products.Where(x=>x.CategoryId == categoryId).ToListAsync();
            return productList;
        }

        public async Task<List<Product>> GetFilteredProductsByCatMakeAsync(string categoryId, string makeId)
        {
            var productList = await this._context.Products.Where(x=>x.CategoryId == categoryId).Where(x=>x.MakeId == makeId).ToListAsync();
            return productList;            
        }

        public async void UpdateProductAsync(int productid, string productname, double productprice, string productdescription )
        {
            var updateProduct = _context.Products.Find(productid);
            updateProduct.ProductName = productname;
            updateProduct.ProductPrice = productprice;
            updateProduct.ProductDescription = productdescription;
            await _context.SaveChangesAsync();           
        }

        public async void UpdatePricingByMakeAsync(string makeid, double percentAdjust)
        {
            var ProductList =await GetFilteredProductsByMakeAsync(makeid);
            foreach (var product in ProductList)
            {
                product.ProductPrice = product.ProductPrice * percentAdjust;
                await _context.SaveChangesAsync();
                
            }
            
        }

        public async void UpdatePricingByCategoryAsync(string categoryid, double percentAdjust)
        {
            var ProductList = await GetFilteredProductsByCategoryAsync(categoryid);
            foreach (var product in ProductList)
            {
                product.ProductPrice = product.ProductPrice * percentAdjust;
                _context.SaveChanges();
            }
        }

        public async void UpdatePricingByMakeCatAsync(string categoryid, string makeid, double percentAdjust)
        {
            var ProductList = await GetFilteredProductsByCatMakeAsync(categoryid, makeid);
            foreach (var product in ProductList)
            {
                product.ProductPrice = product.ProductPrice * percentAdjust;
                _context.SaveChanges();

            }
        }


   
        public async Task<bool> AddNewProductAsync(Product name)
        {
            var product = name;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }
    
    }
}

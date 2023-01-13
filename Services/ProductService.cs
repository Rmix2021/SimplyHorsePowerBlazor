

namespace SimplyHorsePower.Services
{
    public class ProductService
    {
        readonly ApplicationDbContext _context;
       

        public ProductService(ApplicationDbContext context, ILoggerFactory factory)
        {
            this._context = context;
          
        }
        public async Task<bool> AddNewProductAsync(Product name)
        {
            await _context.Products.AddAsync(name);
            await _context.SaveChangesAsync();
            return true;
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

        public async Task<List<Product>> GetFilteredProductsByMakeAsync(string makename)
        {
            var productList = await this._context.Products.Where(x =>x.MakeName == makename).ToListAsync();
            return productList;
        }

        public async Task<List<Product>> GetFilteredProductsByCategoryAsync(string categoryname)
        {        
            var productList = await this._context.Products.Where(x=>x.CategoryName == categoryname).ToListAsync();
            return productList;
        }

        public async Task<List<Product>> GetFilteredProductsByCatMakeAsync(string categoryname, string makename)
        {
            var productList = await this._context.Products.Where(x=>x.CategoryName == categoryname).Where(x=>x.MakeName == makename).ToListAsync();
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

        public async void UpdatePricingByMakeAsync(string makename, double percentAdjust)
        {
            var ProductList =await GetFilteredProductsByMakeAsync(makename);
            foreach (var product in ProductList)
            {
                product.ProductPrice = product.ProductPrice * percentAdjust;
                await _context.SaveChangesAsync();
                
            }
            
        }

        public async void UpdatePricingByCategoryAsync(string categoryname, double percentAdjust)
        {
            var ProductList = await GetFilteredProductsByCategoryAsync(categoryname);
            foreach (var product in ProductList)
            {
                product.ProductPrice = product.ProductPrice * percentAdjust;
                _context.SaveChanges();
            }
        }

        public async void UpdatePricingByMakeCatAsync(string categoryname, string makename, double percentAdjust)
        {
            var ProductList = await GetFilteredProductsByCatMakeAsync(categoryname, makename);
            foreach (var product in ProductList)
            {
                product.ProductPrice = product.ProductPrice * percentAdjust;
                _context.SaveChanges();

            }
        }


    }
}

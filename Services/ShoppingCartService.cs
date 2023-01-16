namespace SimplyHorsePower.Services
{
    public class ShoppingCartService
    {

        readonly ApplicationDbContext _context;

        public ShoppingCartService(ApplicationDbContext context, ILoggerFactory factory)
        {
            this._context = context;
        }

   
        public async Task<bool> AddNewShoppingCartAsync(ShoppingCart shoppingcart)
        {
            await _context.ShoppingCarts.AddAsync(shoppingcart);
            await _context.SaveChangesAsync();
            return true;
        }

        public ShoppingCart GetAShoppingCart(string userName)
        {
            return this._context.ShoppingCarts.Where(x => x.NormalizedUserName == userName)
                .Include(x =>x.CartItems)
                .ThenInclude(x=>x.Product)
                .FirstOrDefault();
        }         
    }
}

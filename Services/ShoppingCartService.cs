using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SimplyHorsePower.Models;
using SimplyHorsePower.Data;
using SimplyHorsePower.Services;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimplyHorsePower.Services
{
    public class ShoppingCartService
    {

        readonly ApplicationDbContext _context;
        readonly ILogger _logger;

        public ShoppingCartService(ApplicationDbContext context, ILoggerFactory factory)
        {
            this._context = context;
            this._logger = factory.CreateLogger<ShoppingCartService>();
        }

        public ShoppingCart AddNewShoppingCart(ShoppingCart shoppingcart)
        {            
            _context.Add(shoppingcart);
            _context.SaveChanges();
            return shoppingcart;
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

﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SimplyHorsePower.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<ProductGalleryImage> productGalleryImages { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public List<IFormFile> File { get; internal set; }
        public DbSet<CustomerBuild> customerBuilds { get; set; }
        public DbSet<BuildGalleryImage> buildGalleryImages { get; set; }
    }
}
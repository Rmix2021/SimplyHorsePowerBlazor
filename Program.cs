var builder = WebApplication.CreateBuilder(args);
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //options.UseSqlServer(connectionString));
    options.UseMySql(connectionString, serverVersion));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)

    //required for administration page to function
        .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policybuilder
    => policybuilder.RequireClaim(Claims.AdminOnly));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsUser", policybuilder
    => policybuilder.RequireClaim(Claims.IsUser));
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddScoped<MakeService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductGalleryImageService>();
builder.Services.AddScoped<ShoppingCartService>();
builder.Services.AddScoped<CartItemService>();
builder.Services.AddScoped<CustomerBuildsService>();
builder.Services.AddScoped<BuildGalleryImageService>();
builder.Services.AddScoped<FileUploaderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

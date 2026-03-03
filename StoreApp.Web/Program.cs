using StoreApp.Data.Concrete;
using StoreApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using StoreApp.Web.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
 builder.Services.AddDbContext<StoreDbContext>(options=>{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:StoreDbConnection"],
    b => b.MigrationsAssembly("StoreApp.Web"));
 });
 builder.Services.AddScoped<IStoreRepository,EFStoreRepository>();
 builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();
app.UseStaticFiles();

//ürün detayı için route tanımlaması
app.MapControllerRoute(
    name: "productdetails",
    pattern: "{name}",
    defaults: new { controller = "Home", action = "Details" }
);

//kategori ve ürün adı url'de görünecek şekilde route tanımlaması

app.MapControllerRoute(
    name: "product_in_category",
    pattern: "products/{category?}",
    defaults: new { controller = "Home", action = "Index" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

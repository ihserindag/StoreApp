using StoreApp.Data.Concrete;
using StoreApp.Data.Abstract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
 builder.Services.AddDbContext<StoreDbContext>(options=>{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:StoreDbConnection"],
    b => b.MigrationsAssembly("StoreApp.Web"));
 });
 builder.Services.AddScoped<IStoreRepository,EFStoreRepository>();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

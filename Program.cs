using DanieliPetShop.Data;
using DanieliPetShop.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //work with mvc 
builder.Services.AddTransient<IRepository, Repository>(); //create instance of the interface and class. 
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlite("DataSource = MyPetShop.Db")); //create a local data base with sql lite. 
var app = builder.Build();


app.UseStaticFiles();

using (var scope = app.Services.CreateScope()) //once the web is closed the DB will delete.
{
    var context = scope.ServiceProvider.GetRequiredService<ShopContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();

using Microsoft.EntityFrameworkCore;
using VRGamersWhoLift.Models.database;

//File configs middleware for the app

//creates WebApplicationBuilder object
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DI - Find Migration commnads on pg 147
builder.Services.AddDbContext<VRGamersWhoLiftContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("VRGamersWhoLiftContext"))); //related to appsettings.json connection string name


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute( //Identifies Default route
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

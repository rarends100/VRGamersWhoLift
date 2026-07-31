using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VRGamersWhoLift.Models.Abstract;
using VRGamersWhoLift.Models.database;
using VRGamersWhoLift.Services;

//File configs middleware for the app

//https://learn.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-10.0 -> turtorial create users and seed data for authorization


//creates WebApplicationBuilder object
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Here we can register custom services using .AddTransient, .AddSingleton,
//or .AddScoped<I,T>() ~ <interface, implemnetation> 
//https://www.youtube.com/watch?v=9J9a77ga9R0 - each possible method determines the service time to live
builder.Services.AddScoped<IDBContext, DBContext>();


// Identity Framework Core Config - enable IdentityUser and IdenentityRole
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
}).AddEntityFrameworkStores<VRGamersWhoLiftContext>()
  .AddDefaultTokenProviders();



// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DI - Find Migration commnads on pg 147
builder.Services.AddDbContext<VRGamersWhoLiftContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("VRGamersWhoLiftContext"))); //related to appsettings.json connection string name


WebApplication app = builder.Build();

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

// config app to use authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

//calls the method in ConfigureIdentity.cs to preconfigure the roles for seed users
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    await ConfigureIdentity.CreateInitUsersAsync(scope.ServiceProvider);
}

app.MapControllerRoute( //Identifies Default route — I am calling this middle ware last on purpose
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

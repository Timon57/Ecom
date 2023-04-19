using Ecom.web.Data;
using Ecom.web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EcomDbContext>(op =>
{
    op.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ecom;Integrated Security=True;TrustServerCertificate=False;");

});
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<EcomDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(op =>
{
    op.Password.RequireNonAlphanumeric = false;
    op.Password.RequiredLength = 3;
    op.Password.RequireDigit = false;
    op.Password.RequireUppercase= false;
    op.Password.RequireLowercase= false;
});

builder.Services.AddScoped<IProductService,ProductService>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

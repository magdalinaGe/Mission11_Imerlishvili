using Microsoft.EntityFrameworkCore;
using Mission11_Imerlishvili.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookstoreConnection"])
);

builder.Services.AddScoped<IBookStoreRepository, EFBookStoreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
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

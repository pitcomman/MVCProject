using Microsoft.EntityFrameworkCore;
using MVCStart.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connection = @"server=(local)\SQLEXPRESS; database=workshop; uid=sa; pwd=1234;";
builder.Services.AddDbContext<WorkshopContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

//ต้องเอาไว้บนๆ เดี๋ยวมันจะเจอตัวอื่นก่อนไม่แสดง Error นี้
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Error/404";
        await next();
    }

});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});

//builder.Services.AddSingleton<IHelper, Helper>();

//builder.Services.AddScoped<IHelper, Helper>();

builder.Services.AddTransient<IHelper, Helper>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
    /*(sp =>
{
    return new Helper(true);
});*/

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

//app.MapControllerRoute(
//    name: "pages",
//    pattern: "blog/{*article}",
//    defaults: new  {controller="Blog",action="Article" });



app.MapControllerRoute(
    name: "article",
    pattern: "{controller}/{action}/{name}/{id}");

app.MapControllerRoute(
    name: "pages",
    pattern: "{controller}/{action}/{page}/{pageSize}");

app.MapControllerRoute(
    name: "getbyid",
    pattern: "{controller}/{action}/{productid}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=products}/{action=index}/{id?}");

app.Run();

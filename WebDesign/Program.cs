using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
// NESNE türetmeleri Depedency Injection Mantýðý ile
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IRepositories<TBLBlog>, Repositories<TBLBlog>>();
builder.Services.AddScoped<IRepositories<TBLCategories>, Repositories<TBLCategories>>();
builder.Services.AddScoped<IRepositories<TBLUser>, Repositories<TBLUser>>();



// Giriþ Yapýlacak ve Çýkýþ Yapýlacak Sayfalar belirtiliyor.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(opt =>
        {
            opt.LoginPath = "/admin/Login/";
            opt.LogoutPath = "/admin/Cikis";
            opt.AccessDeniedPath = "/admin/Yetkisiz";
        });


var app = builder.Build();

app.UseStaticFiles(); // images Css ve JS dosyalarýný depolayýp çalýþtýrabilmemizi saðlayan Middleware wwwroot aktif etme.

app.UseRouting();
app.UseAuthentication(); // Kullanýcý Giriþi Aktif Etme
app.UseAuthorization(); // Giriþ Yapan Kullanýcýnýn Yetkisine göre sayfa açacak isek aktif ettiðimiz Middleware
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

// Admin Paneli Route Yapýsý, https://localhost:45/admin yazýnca Login sayfasýna otomatik gidecek.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
    );
});

app.Run();

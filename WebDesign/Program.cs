using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
// NESNE t�retmeleri Depedency Injection Mant��� ile
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IRepositories<TBLBlog>, Repositories<TBLBlog>>();
builder.Services.AddScoped<IRepositories<TBLCategories>, Repositories<TBLCategories>>();
builder.Services.AddScoped<IRepositories<TBLUser>, Repositories<TBLUser>>();



// Giri� Yap�lacak ve ��k�� Yap�lacak Sayfalar belirtiliyor.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(opt =>
        {
            opt.LoginPath = "/admin/Login/";
            opt.LogoutPath = "/admin/Cikis";
            opt.AccessDeniedPath = "/admin/Yetkisiz";
        });


var app = builder.Build();

app.UseStaticFiles(); // images Css ve JS dosyalar�n� depolay�p �al��t�rabilmemizi sa�layan Middleware wwwroot aktif etme.

app.UseRouting();
app.UseAuthentication(); // Kullan�c� Giri�i Aktif Etme
app.UseAuthorization(); // Giri� Yapan Kullan�c�n�n Yetkisine g�re sayfa a�acak isek aktif etti�imiz Middleware
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

// Admin Paneli Route Yap�s�, https://localhost:45/admin yaz�nca Login sayfas�na otomatik gidecek.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
    );
});

app.Run();

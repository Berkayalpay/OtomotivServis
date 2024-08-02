using OtomotivServisSatis.Data;
using OtomotivServisSatis.Service.Abstract;
using OtomotivServisSatis.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace OtomotivServisSatis.WebUI
{
    public class Program
    {
        //Bir Servisi .NET Core da kullanabilmemiz için onu sisteme tanýtmamýz gerekiyor.
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DatabaseContext>();

            builder.Services.AddTransient(typeof(IService<>),typeof(Service<>)); //Ara katmaný kullanmamýzý saðlar kendi servisimizi.
            builder.Services.AddTransient<ICarService, CarService>();

            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x=>
            {
                x.LoginPath = "/Account/Login";
                x.AccessDeniedPath = "/AccessDenied";
                x.LogoutPath = "/Account/Logout";
                x.Cookie.Name = "Admin";
                x.Cookie.MaxAge = TimeSpan.FromDays(7); //Giriþ yapan kullanýcý 7 gün boyunca giriþ yapabilsin.
                x.Cookie.IsEssential = true;
            });

            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminPolicy",policy => policy.RequireClaim(ClaimTypes.Role,"Admin"));
                x.AddPolicy("UserPolicy",policy => policy.RequireClaim(ClaimTypes.Role,"Admin","User"));
                x.AddPolicy("CustomerPolicy",policy => policy.RequireClaim(ClaimTypes.Role,"Admin","User","Customer"));
            });

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
           name: "admin",
           pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}" //Main içerisindeki index action çalýþýr
         );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
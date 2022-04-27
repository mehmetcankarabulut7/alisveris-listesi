using Bitirme_Proje.Business.Classes;
using Bitirme_Proje.Business.Interfaces;
using Bitirme_Proje.DataAccess.Classes;
using Bitirme_Proje.DataAccess.Interfaces;
using Bitirme_Proje.EntityFramework;
using Bitirme_Proje.EntityFramework.Entities;
using Bitirme_Proje.ViewModel;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bitirme_Proje
{
    public class Startup
    {
        IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(a => a.LoginPath = "/Home/Index");

            services.AddDbContext<BitirmeDbContext>(opt => {
                opt.UseSqlServer(_config.GetConnectionString("BitirmeDb"));
            });

            services.AddSession();

            services.AddTransient<BitirmeDbContext>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<ListProduct>();
            
            services.AddTransient<ICategoryDal, EfCategoryDal>();
            services.AddTransient<IUserDal, EfUserDal>();
            services.AddTransient<IShoppingListDal, EfShoppingListDal>();
            services.AddTransient<IProductDal, EfProductDal>();
            services.AddTransient<IListProductDal, EfListProductDal>();

            services.AddTransient<ICategoryService, CategoryManager>();            
            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<IShoppingListService, ShoppingListManager>();
            services.AddTransient<IProductService, ProductManager>();
            services.AddTransient<IListProductService, ListProductManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}

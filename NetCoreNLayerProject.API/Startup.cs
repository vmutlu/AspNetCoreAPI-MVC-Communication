using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreNLayerProject.API.Extensions;
using NetCoreNLayerProject.API.Filters;
using NetCoreNLayerProject.Core.Repository;
using NetCoreNLayerProject.Core.Service;
using NetCoreNLayerProject.Core.UnitOfWorks;
using NetCoreNLayerProject.Data;
using NetCoreNLayerProject.Data.Repositories;
using NetCoreNLayerProject.Data.UnitOfWorks;
using NetCoreNLayerProject.Service.Services;

namespace NetCoreNLayerProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:NlayerProjectContext"].ToString(), x =>
                 {
                     x.MigrationsAssembly("NetCoreNLayerProject.Data");
                 });
            });


            services.AddControllers(o =>
            {
                o.Filters.Add(new ValidationFilter()); //filterim tüm controllerlarda geçerli olacak
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

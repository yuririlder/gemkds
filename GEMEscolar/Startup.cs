using GEMEscolar.Configurations;
using GEMEscolar.Configurations.Mapper;
using GEMEscolar.Core.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GEMEscolar
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
            services.AddSession();
            services.AddControllersWithViews();
#if DEBUG
            services.AddDbContext<GEMContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("ConnectionStringTST")));      
#else
            services.AddDbContext<GEMContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("ConnectionString")));

#endif
            services.RegisterServicesConfig(Configuration);
            services.ConfigureAutomapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}");
            });
        }
    }
}

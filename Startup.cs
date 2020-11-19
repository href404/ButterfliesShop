using ButterfliesShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ButterfliesShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IButterfliesQuantityService, ButterfliesQuantityService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "ButterflyRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Butterfly", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}

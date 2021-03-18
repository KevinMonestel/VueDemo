using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;
using VueNetDemo.FrontEnd.Contract.Account;
using VueNetDemo.FrontEnd.Implementation.Account;
using VueNetDemo.FrontEnd.Shared.Models.Configurations;

namespace VueNetDemo.FrontEnd.WebUI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public AppConfiguration _appConfiguration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            _appConfiguration = new AppConfiguration();
            _configuration.Bind("AppConfiguration", _appConfiguration);

            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton(this._appConfiguration);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSpaStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.Options.SourcePath = "ClientApp/";
                    spa.UseVueCli(npmScript: "serve");
                }
                else
                {
                    spa.Options.SourcePath = "dist";
                }
            });
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataCallingFirefighters.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using DataCallingFirefighters.ApplicationServices.GetParkingTerminalListUseCase;
using DataCallingFirefighters.ApplicationServices.Ports.Gateways.Database;
using DataCallingFirefighters.ApplicationServices.Repositories;
using DataCallingFirefighters.DomainObjects.Ports;

namespace DataCallingFirefighters.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DutaCallingFirefighter>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "DataCallingFirefighters.db")}")
            );

            services.AddScoped<IDataCallingFirefighterDatabaseGateway, DataCallingFirefighterEFSqliteGateway>();

            services.AddScoped<DbDataCallingFirefighterRepository>();
            services.AddScoped<IReadOnlyDataCallingFirefighterRepository>(x => x.GetRequiredService<DbDataCallingFirefighterRepository>());
            services.AddScoped<IDataCallingFirefighterRepository>(x => x.GetRequiredService<DbDataCallingFirefighterRepository>());

 
            services.AddScoped<IGetDataCallingFirefighterListUseCase, GetDataCallingFirefighterListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

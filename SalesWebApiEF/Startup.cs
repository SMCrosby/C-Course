using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SalesWebApiEF.Data;

namespace SalesWebApiEF {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();


            //creates the connection to a particular database
            services.AddDbContext<SalesContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SalesDb"));      //goes to appsettings for ConnectionString called SalesDb
            });

            //configures support for Cross-origin Scripting support. 
            //It allows or denies one website to access this server
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            //This is where CORS is configured      --options is just a variable
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                                            //--Origin = websites
                                            //--Method = can choose which methods they can/can't call
                                            //--Header = can force input to receive access --like a password


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

           
            //automatically updates database with any migrations that have yet to be updated in the database
            using(var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope()) {
                    scope.ServiceProvider.GetService<SalesContext>().Database.Migrate();
            }


        }
    }
}

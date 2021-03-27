using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Data;
using Microsoft.EntityFrameworkCore;
using DemoApp.Domain;

namespace DemoApp
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoApp", Version = "v1" });
            });

            var server = Configuration["DBServer"] ?? "ms-sql-server";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "1StrongPwd!!";
            var database = Configuration["DBName"] ?? "DemoApp";


            services.AddDbContext<DemoAppDbContext>(options =>
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}")
            );

            services.AddCors(options =>
            {
                options.AddPolicy(name: "Dev",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .AllowCredentials();
                                  });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoApp v1"));
            }

            app.UseCors("Dev");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
            PopulateDB(app);
        }

        private static void PopulateDB(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<DemoAppDbContext>());
            }
        }

        private static void SeedData(DemoAppDbContext demoAppDbContext)
        {
            Console.WriteLine("Applying Migrations.......");
            demoAppDbContext.Database.Migrate();
            if (!demoAppDbContext.Cars.Any())
            {
                Console.WriteLine("Seeding data");
                demoAppDbContext.Cars.Add(new Car()
                {
                    Make = "Honda",
                    Model = "City",
                    Price = 1100000

                });
                demoAppDbContext.SaveChanges();
                Console.WriteLine("Seeding Completed");
            }
            else
            {
                Console.WriteLine("No need for Migration");
            }
        }
    }
}

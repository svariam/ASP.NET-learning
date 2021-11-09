using BookAPI_Project.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI_Project
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
            //           services.AddRazorPages();
            services.AddMvc();
            var connectionString = Configuration["connectionString:bookDbConnectionStrinig"];
            services.AddDbContext<BookDbContext>(c => c.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
                     context.SeedDataContext();
            //          app.UseHttpsRedirection();
            //           app.UseStaticFiles();

            app.UseRouting();

            //          app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //         endpoints.MapRazorPages();
                /*    endpoints.MapGet("/", async context =>
                     {
                         await context.Response.WriteAsync("Hello World");

                     });*/
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{api}/{id?}"
                    );
            });
        }
    }
}

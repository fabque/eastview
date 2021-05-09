using EastviewRestAPI.Models;
using EastviewRestAPI.Patterns;
using EastviewRestAPI.Patterns.Impl;
using EastviewRestAPI.Repositories.Interface;
using EastviewRestAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EastviewRestAPI.Services;
using EastviewRestAPI.Services.Interfaces;

namespace eastviewRestAPI
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
            AddSwagger(services);

            services.AddDbContext<EastviewDbContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("EastviewDbContext")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICitizenRepository, CitizenRepository>();
            services.AddScoped<ICitizenTaskRepository, CitizenTaskRepository>();

            services.AddScoped<ICitizenService, CitizenService>();
            services.AddScoped<ICitizenTaskService, CitizenTaskService>();

            services.AddControllers();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Eastview {groupName}",
                    Version = groupName,
                    Description = "Eastview API",
                    Contact = new OpenApiContact
                    {
                        Name = "Eastview",
                        Email = string.Empty,
                        Url = new Uri("https://eastview.io/"),
                    }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eastviev API V1");
            });

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

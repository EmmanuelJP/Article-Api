using Article.Model.Entities;
using Article.Service;
<<<<<<< Updated upstream
=======
using Article.Service.DTOs;
using AutoMapper;
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
<<<<<<< Updated upstream
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
=======
using Microsoft.OpenApi.Models;
using Article.Service.Map;

>>>>>>> Stashed changes

namespace Article.Api
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
<<<<<<< Updated upstream
            services.AddSingleton<IBaseService<Model.Entities.Article>, Service.ArticleService>();
=======
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IBaseService<ArticleDto>, ArticleService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArticleCRUD", Version = "v1" });

            });
            services.AddHealthChecks()
                .AddCheck("Article.Api.Check", () => HealthCheckResult.Healthy());
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<ArticleProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
>>>>>>> Stashed changes
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArticleCRUD v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("HealthArticle");
            });
        }
    }
}

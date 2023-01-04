using Article.Service.DTOs;
using Article.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Article.Model.Contexts;
using Article.Repository;
using AutoMapper;
using Article.Service.Map;
using Microsoft.EntityFrameworkCore;

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
            services.AddDbContext<ArticleDbContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("Connection")));
            services.AddControllers();
            services.AddScoped<ArticleRepository>();
            services.AddScoped<IBaseService<ArticleDto>,ArticleService>();
            var MapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<ArticleProfile>();
            });
            IMapper mapper = MapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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

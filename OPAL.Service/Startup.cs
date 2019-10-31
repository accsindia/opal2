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
using OPAL.Application.Interfaces;
using OPAL.Application.Search.Queries.GetBasicSearch;
using OPAL.Caching;
using OPAL.Search;
using ServiceStack.Redis;

namespace OPAL.Service
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
            services.AddScoped<IGetBasicSearchQuery, GetBasicSearchQuery>();
            services.AddScoped<ISearchService, SearchService>();
            services.Decorate<ISearchService, CachingService>();
            services.Decorate<ISearchService>((inner, provider) => new CachingService(inner, provider.GetRequiredService<IRedisClient>()));

            services.AddSingleton<IRedisClient>(x => {
                var server = Environment.GetEnvironmentVariable("REDIS_HOST");
                var port = Environment.GetEnvironmentVariable("REDIS_PORT");
                
                var manager = new RedisManagerPool(string.Format("{0}:{1}",server, port));
                
                return manager.GetClient();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

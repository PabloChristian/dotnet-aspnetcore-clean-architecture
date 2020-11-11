using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces.Catalogo;
using CleanArchitecture.Application.Mapper.Catalogo;
using CleanArchitecture.Core.Interfaces.Catalogo;
using CleanArchitecture.Infrastructure.Context.Catalogo;
using CleanArchitecture.Infrastructure.Repository.Catalogo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using HealthChecks.UI.Client;
using AutoMapper;

namespace CleanArchitecture.ApiRest
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
            services.AddDbContext<ProdutoDbContext>(options =>
            {
                options.UseInMemoryDatabase("Produtos");
            });

            services.AddAutoMapper(typeof(IProdutoService));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddHealthChecks().AddUrlGroup(new Uri("http://www.igti.com.br"), "IGTI", HealthStatus.Healthy);
            services.AddHealthChecksUI().AddInMemoryStorage();

            services.AddControllers();

            services.AddSwaggerGen();
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

            app.UseSwagger();

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API - v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHealthChecks("/status",
                new HealthCheckOptions
                {
                    ResponseWriter = async (context, report) => {
                        var result = JsonConvert.SerializeObject(new
                        {
                            status = report.Status.ToString(),
                            healthChecks = report.Entries.Select(e => new {
                                check = e.Key,
                                error = e.Value.Exception?.Message,
                                status = Enum.GetName(typeof(HealthStatus), e.Value.Status)
                            })
                        });

                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                });


            app.UseHealthChecks("/hcui-data", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();


            });
        }
    }
}

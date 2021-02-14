using BlueModas.Api.Repository;
using BlueModas.Api.Repository.BlueContext;
using BlueModas.Api.Repository.Interface;
using BlueModas.Api.Services;
using BlueModas.Api.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace BlueModas.Api
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
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlueModas.Api", Version = "v1" });
            });
            InitializeContainer(services);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlueModas.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void InitializeContainer(IServiceCollection app)
        {
            app.AddDbContext<LojaBlueContext>();
            app.AddScoped<IProdutoService, ProdutoService>();
            app.AddScoped<IProdutoRepository, ProdutoRepository>();


            app.AddScoped<IClienteService, ClienteService>();
            app.AddScoped<IClienteRepository, ClienteRepository>();


            app.AddScoped<IPedidoService, PedidoService>();
            app.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}

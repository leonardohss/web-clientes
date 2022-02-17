using AutoMapper;
using Clientes.App.Dtos;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Interfaces;
using Clientes.Infra.Data.Contexto;
using Clientes.Infra.Data.Repositorio;
using Clientes.Servico.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Clientes.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<SqlServerContexto>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connectionstring"));
            });

            AddDependencies(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clientes.App", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clientes.App v1"));

                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected virtual void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IBaseRepositorio<Cliente>, BaseRepositorio<Cliente>>();
            services.AddScoped<IBaseServico<Cliente>, BaseServico<Cliente>>();
            services.AddScoped<IClienteServico, ClienteServico>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<ClienteDTO, Cliente>();
            }).CreateMapper());
        }
    }
}

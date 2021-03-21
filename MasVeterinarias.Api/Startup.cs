using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MasVeterinarias.Application.Services;
using MasVeterinarias.Domain.Interfaces;
using MasVeterinarias.Infraestructure.Data;
using MasVeterinarias.Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MasVeterinarias.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllers();
           
            services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            

            services.AddDbContext<MasVeterinariasBDContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("gabriel"))
            );

            services.AddMvc().AddFluentValidation(options =>
                    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IEmpleadoService, EmpleadoService>();
            services.AddTransient<ICitaService, CitaService>();
            services.AddTransient<IVeterinariaService, VeterinariaService>();
            services.AddTransient<IDetallesCitaService, DetallesCitaService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IServicioService, ServicioService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

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

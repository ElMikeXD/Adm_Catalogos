using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EGobX.NTemplate.API.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using EGobX.NTemplate.API.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;
using System.Reflection;
using System;
using System.IO;
using EGobX.NTemplate.API.Middlewares;

namespace EGobX.Template.API
{
    /// <summary>
    /// Clase para la inicialización de las configuraciones requeridas en ejecución.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor de la clase startup 
        /// </summary>
        /// <param name="configuration"> Representa un conjunto de propiedades de configuración de la aplicación clave/valor </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Atributo que representa las propiedades de configuración.
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Método en donde las opciones de configuración se establecen por convención
        /// </summary>
        /// <param name="services"> Especifica el contrato para una colección de descriptores de servicio.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<TemplateContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var mappingConfig = new MapperConfiguration( mc  => {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddServiceCollection();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Api Template", Version = "V1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Método para la especificación del modo de respuesta de la aplicación a las solicitudes HTTP.
        /// </summary>
        /// <param name="app"> Proporciona mecanismos para configurar la canalización de solicitudes de una aplicación</param>
        /// <param name="env"> Proporciona información sobre el entorno de alojamiento web en el que se ejecuta la aplicación </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Template Catalog");
            });

            #region[Permite el acceso al proyecto de angular de manera local]
            string[] origins = new string[] { "http://localhost:4200", "http://localhost:8015" }; 
            app.UseCors(b => b.AllowAnyMethod().AllowAnyHeader().WithOrigins(origins));
            #endregion

            app.UseMiddleware<RequestCultureMiddleware>();
            app.UseMvc();
        }
    }
}

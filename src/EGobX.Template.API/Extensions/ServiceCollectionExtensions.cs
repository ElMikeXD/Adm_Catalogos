using EGobX.NTemplate.API.Containers;
using Microsoft.Extensions.DependencyInjection;

namespace EGobX.NTemplate.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"> Representa la clase donde se harán las configuraciones para la DI </typeparam>
        /// <param name="services"> Especifica el contrato para una colección de descriptores de servicio. </param>
        public static void AddConfiguration<T>(this IServiceCollection services) where T : IConfigurationDI, new()
        {
            var Configuration = new T();
            Configuration.AddDependecy(services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"> Especifica el contrato para una colección de descriptores de servicio </param>
        public static void AddServiceCollection(this IServiceCollection services)
        {
            services.AddConfiguration<TemplateDependecy>();
        }
    }
}

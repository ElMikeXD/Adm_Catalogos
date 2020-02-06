using Microsoft.Extensions.DependencyInjection;

namespace EGobX.NTemplate.API.Extensions
{
    /// <summary>
    /// Interfaz que contiene los métodos correspondientes a la configuración de inyecciones de dependencia
    /// </summary>
    public interface IConfigurationDI
    {
        /// <summary>
        /// Método para la definición de la agregación de dependencias
        /// </summary>
        /// <param name="services"> Especifica una colección de descripciones de servicios.</param>
        void AddDependecy(IServiceCollection services);
    }
}

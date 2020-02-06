using EGobX.Core.Repositories;
using EGobX.NTemplate.Domain.DTO;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;

namespace EGobX.NTemplate.Service.Interfaces.Service
{
    /// <summary>
    /// Interfaz del servicio de búsqueda de los registros de template.
    /// </summary>
    public interface IFinderTemplateService : IFinderService<Template>
    {
        /// <summary>
        /// Atributo que contiene los parámetros de búqueda así como tambien los parámetros de paginación.
        /// </summary>
        FinderTemplateDTO finderTemplateDTO { get; set; }

        /// <summary>
        /// Método para asignar filtros a una expresión. 
        /// </summary>
        void SetExpression();
    }
}

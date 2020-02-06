using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Implements.Catalog.Response;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;

namespace EGobX.NTemplate.ViewModel.Services
{
    /// <summary>
    /// Interfaz que implementa la interfaz que contiene los métodos genéricos para la busqueda de registros.
    /// </summary>
    public interface IFinderTemplateViewModelService: IFinderViewModelService<Template, TemplateViewModel>
    {

        /// <summary>
        /// Método para la busqueda de entidades por medio de parametros.
        /// </summary>
        /// <param name="finderTemplateViewModel">Parámetro que contiene los valores de filtro y los parámtros de paginación.</param>
        /// <returns>Objeto que contiene los registros consultados y la información de paginación</returns>
        GetResponse<TemplateViewModel> GetByParam(FinderTemplateViewModel finderTemplateViewModel);

    }
}

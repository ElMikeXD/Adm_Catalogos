using AutoMapper;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Service;
using EGobX.NTemplate.ViewModel.Services.Abstractions.AbstractClasses;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;

namespace EGobX.NTemplate.ViewModel.Services
{
    /// <summary>
    /// Clase que hereda de una clase genérica métodos para mapear información al actualizar o cambiar de estado a una entidad.
    /// </summary>
    public class UpdaterTemplateViewModelService : UpdaterViewModelService<Template, CreatorTemplateViewModel>, IUpdaterTemplateViewModelService
    {
        /// <summary>
        /// Método constructor que recibe tres parámetros e inicializa o asigna datos por defecto.
        /// </summary>
        /// <param name="_mapper"> Dependencia correspondiente a la biblioteca que se encarga de mapear tipos diferentes de objetos. </param>
        /// <param name="_updaterTemplateService"> Dependencia correspondiente al servicio de actualización de una entidad. </param>
        /// <param name="_finderTemplateService"> Dependencia correspondiente al servicio de busqueda de una entidad. </param>
        public UpdaterTemplateViewModelService(IMapper _mapper, IUpdaterTemplateService _updaterTemplateService, IFinderTemplateService _finderTemplateService) :
            base(_mapper, _updaterTemplateService, _finderTemplateService)
        {
        }
    }
}

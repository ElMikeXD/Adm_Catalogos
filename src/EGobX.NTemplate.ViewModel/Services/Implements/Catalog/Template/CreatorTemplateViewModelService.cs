using AutoMapper;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Service;
using EGobX.NTemplate.ViewModel.Services.Abstractions.AbstractClasses;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;

namespace EGobX.NTemplate.ViewModel.Services
{
    /// <summary>
    /// Clase para mapear los datos cuando se crea un registro.
    /// </summary>
    public class CreatorTemplateViewModelService : CreatorViewModelService<Template, CreatorTemplateViewModel>, ICreatorTemplateViewModelService
    {
        /// <summary>
        /// Constructor de la clase que inicializa e asigna datos por defecto
        /// </summary>
        /// <param name="_mapper"> Dependencia correspondiente a la biblioteca que se encarga de mapear tipos diferentes de objetos. </param>
        /// <param name="_creatorService"> Dependencia correspondiente al servicio de creación de una entidad. </param>
        public CreatorTemplateViewModelService(IMapper _mapper, ICreatorTemplateService _creatorService):
            base(_mapper, _creatorService)
        {
        }
    }
}

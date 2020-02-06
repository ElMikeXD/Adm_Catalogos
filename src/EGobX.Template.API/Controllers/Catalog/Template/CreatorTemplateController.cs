using Microsoft.AspNetCore.Mvc;
using EGobX.NTemplate.ViewModel.Services;
using EGobX.NTemplate.API.Abstractions.AbstractClasses;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;

namespace EGobX.NTemplate.API.Controllers
{
    /// <summary>
    /// Clase que tiene como proposito de exponer método de creación para el catálogo de Template
    /// </summary>
    [Route("api/Template")]
    [ApiController]
    public class CreatorTemplateController : CreatorController<Domain.Entities.Template, CreatorTemplateViewModel>
    {
        /// <summary>
        /// Constructor que recibe como parámetro ICreatorTemplateViewModelService
        /// </summary>
        /// <param name="_creatorTemplateViewModelService"> Representa la instancia de la dependencia que tiene la clase con la interfaz ICreatorViewModel.</param>
        public CreatorTemplateController(ICreatorTemplateViewModelService _creatorTemplateViewModelService) :
            base(_creatorTemplateViewModelService)
        { }
    }
}

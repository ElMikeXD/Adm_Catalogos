using Microsoft.AspNetCore.Mvc;
using EGobX.NTemplate.ViewModel.Services;
using EGobX.NTemplate.API.Abstractions.AbstractClasses;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;

namespace EGobX.NTemplate.API.Controllers.Catalog.Template
{
    /// <summary>
    /// Clase que se encarga de solicitar a la clase UpdaterTemplateService que almacene una entidad para actualizarla.
    /// </summary>
    [Route("api/Template")]
    [ApiController]
    public class UpdaterTemplateController : UpdaterController<Domain.Entities.Template, CreatorTemplateViewModel>
    {
        /// <summary>
        /// Constructor de la clase que recibe como dependencia una interfaz de tipo IUpdaterTemplateViewModelService e inicializa o asigna datos por defecto.
        /// </summary>
        /// <param name="_updaterTemplateViewModelService"> Representa la instancia de la dependencia que tiene la clase con la interfaz IUpdaterViewModel </param>
        public UpdaterTemplateController(IUpdaterTemplateViewModelService _updaterTemplateViewModelService) :
            base(_updaterTemplateViewModelService)
        {
        }
    }
}
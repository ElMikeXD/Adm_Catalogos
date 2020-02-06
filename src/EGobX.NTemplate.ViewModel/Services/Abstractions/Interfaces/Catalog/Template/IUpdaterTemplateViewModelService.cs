using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;

namespace EGobX.NTemplate.ViewModel.Services
{
    /// <summary>
    /// Interfaz de la clase que tiene como propósito mapear al actualizar o cambiar el estado lógico de una entidad.
    /// </summary>
    public interface IUpdaterTemplateViewModelService : IUpdaterViewModelService<Template, CreatorTemplateViewModel>
    {

    }
}

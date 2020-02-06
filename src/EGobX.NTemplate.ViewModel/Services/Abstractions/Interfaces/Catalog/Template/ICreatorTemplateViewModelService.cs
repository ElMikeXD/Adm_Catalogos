using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;

namespace EGobX.NTemplate.ViewModel.Services
{
    /// <summary>
    /// Interfaz que implementa la interfaz de la clase CreatorViewModelService y recibe dos entidades, un tipo Template y un TemplateViewModel.
    /// </summary>
    public interface ICreatorTemplateViewModelService : ICreatorViewModelService<Template, CreatorTemplateViewModel>
    {

    }
}

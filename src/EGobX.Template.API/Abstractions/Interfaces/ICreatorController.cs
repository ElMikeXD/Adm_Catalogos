using Microsoft.AspNetCore.Mvc;

namespace EGobX.NTemplate.API.Abstractions.Interfaces
{
    /// <summary>
    /// Clase que contiene el método Create.
    /// </summary>
    /// <typeparam name="TViewModel"> ViewModel genérico. </typeparam>
    public interface ICreatorController<TViewModel>
    {
        /// <summary>
        /// Método que tiene como parámetro un tipo ViewModel.
        /// </summary>
        /// <param name="viewModel"> Parámetro que permite la creación de una entidad de  tipo ViewModel. </param>
        ActionResult Create([FromBody] TViewModel viewModel);
    }
}

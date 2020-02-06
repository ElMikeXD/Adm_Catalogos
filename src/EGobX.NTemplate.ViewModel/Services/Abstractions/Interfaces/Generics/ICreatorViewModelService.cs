using EGobX.NTemplate.Domain.Entities.Base;
using System;

namespace EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics
{
    /// <summary>
    /// Interfaz de la clase genérica que mapea las entidades al crear.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica. </typeparam>
    /// <typeparam name="TViewModel"> ViewModel genérico. </typeparam>
    public interface ICreatorViewModelService<TEntity, in TViewModel> 
        where TEntity : ICatalogEntity
    {
        /// <summary>
        /// Método que recibe como parámetro un tipo ViewModel.
        /// </summary>
        /// <param name="_viewModel"> Representa la información nueva del catálogo. </param>
        /// <returns>Retorna el Guid del registro creado.</returns>
        Guid Create(TViewModel _viewModel);
    }
}

using System;
using EGobX.NTemplate.Domain.Entities.Base;

namespace EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics
{
    /// <summary>
    /// Interfaz de la clase genérica que mapea las entidades para la actualización o cambio de estado lógico.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad de tipo genérica </typeparam>
    /// <typeparam name="TViewModel"> ViewModel de tipo genérico </typeparam>
    public interface IUpdaterViewModelService<TEntity, TViewModel>
        where TEntity : ICatalogEntity
    {
        /// <summary>
        /// Definición para el método de actualización de una entidad.
        /// </summary>
        /// <param name="_id"> Identificador correspondiente a una entidad. </param>
        /// <param name="_viewModel"> Representa la información nueva a actualizar del catálogo. </param>
        void Update(Guid _id, TViewModel _viewModel);

        /// <summary>
        /// Método para el cambio de estado lógico de una entidad. 
        /// </summary>
        /// <param name="_id"> Representa el identificador de una entidad a actualizar del catálogo. </param>
        /// <param name="_isActive"> Representa el estado lógico a actualizar de una entidad. </param>
        void UpdateState(Guid _id, bool _isActive);
    }
}

using System;
using System.Collections.Generic;

namespace EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics
{
    /// <summary>
    /// Interfaz de la clase FinderViewModelService que contiene métodos para obtener la busqueda de una entidad o lista de entidades.
    /// </summary>
    /// <typeparam name="TEntity">TEntity:ICatalogEntity</typeparam>
    /// <typeparam name="TViewModel">TViewModel</typeparam>
    public interface IFinderViewModelService<TEntity, TViewModel> where TEntity : class
    {
        /// <summary>
        /// Método para obtener una entidad.
        /// </summary>
        /// <param name="_id">Returns Retorna un viewModel</param>
        /// <returns></returns>
        TViewModel Get(Guid _id);

        /// <summary>
        /// Método para obtener una lista de entidades de tipo TViewModel
        /// </summary>
        /// <returns></returns>
        List<TViewModel> GetAll();

        /// <summary>
        /// Método para la busqueda de una lista de entidades por medio del nombre.
        /// </summary>
        /// <param name="_name">Representa el nombre de una entidad</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        List<TViewModel> GetByName(string _name);
    }
}
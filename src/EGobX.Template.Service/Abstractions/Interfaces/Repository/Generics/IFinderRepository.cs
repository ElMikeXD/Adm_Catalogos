using System;
using System.Collections.Generic;
using EGobX.Core.Repositories;

namespace EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics
{
    /// <summary>
    /// Interfaz de la clase genérica que contiene los métodos para la busqueda de una entidad o una lista de entidades.
    /// </summary>
    /// <typeparam name="TEntity">TEntity : ICatalogEntity</typeparam>
    public interface IFinderRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Método para la busqueda de una entidad.
        /// </summary>
        /// <param name="_id">Representa el identificador de una entidad.</param>
        /// <returns>Retorna una entidad genérica.</returns>
        TEntity Get(Guid _id);

        /// <summary>
        /// Método para la busqueda de una lista de entidades.
        /// </summary>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Método para la busqueda de una lista de entidades por medio del nombre.
        /// </summary>
        /// <param name="_name">Representa el nombre de una entidad</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        IEnumerable<TEntity> GetByName(string _name);

        /// <summary>
        /// Método para la busqueda de entidades por medio de parametros.
        /// </summary>
        /// <param name="spec">Interfaz de tipo IQueryableSpecification que contiene los parámetros de búsqueda.</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        IEnumerable<TEntity> GetByParam(IQueryableSpecification<TEntity> spec);
    }
}

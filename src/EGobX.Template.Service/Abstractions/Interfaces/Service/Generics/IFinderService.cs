using System;
using System.Collections.Generic;
using EGobX.Core.Repositories;
using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.NTemplate.Service.Implements.Catalog.Response;

namespace EGobX.NTemplate.Service.Interfaces.Service.Generics
{
    /// <summary>
    /// Interfaz de la clase genérica que contiene los métodos para la busqueda de una entidad o una lista de entidades.
    /// </summary>
    /// <typeparam name="TEntity">TEntity : ICatalogEntity</typeparam>
    public interface IFinderService<TEntity> where TEntity : class
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
        List<TEntity> GetAll();

        /// <summary>
        /// Método para la busqueda de una lista de entidades por medio del nombre.
        /// </summary>
        /// <param name="_name">Representa el nombre de una entidad</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        List<TEntity> GetByName(string _name);


        /// <summary>
        /// Método para la busqueda de una lista de entidades.
        /// </summary>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        List<TEntity> GetByParam(IQueryableSpecification<TEntity> spec);

        /// <summary>
        /// Método para la busqueda de entidades por medio de parametros.
        /// </summary>
        /// <param name="paginationCatalog">Parámetro que contiene los valores de filtro y los parámtros de paginación.</param>
        /// <returns>Objeto que contiene los registros consultados y la información de paginación</returns>
        GetResponse<TEntity> GetByParam<TDto>(TDto paginationCatalog) where TDto : PaginationCatalog;

    }
}

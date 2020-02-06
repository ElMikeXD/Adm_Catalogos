using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using EGobX.Core.Repositories.EFCore;
using EGobX.Core.Repositories;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions
{
    /// <summary>
    /// Clase abstracta que contiene métodos genéricos para establecer comunicación con la base de datos y para buscar una entidad o una lista de entidades.
    /// </summary>
    /// <typeparam name="TEntity">TEntity : BaseEntity</typeparam>
    public abstract class FinderRepository<TEntity> : EFRepository<TEntity>, IFinderRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Atributo para el objeto que consulta o guarda instancias entre la entidad y la base de datos.
        /// </summary>
        private readonly DbSet<TEntity> entities;

        /// <summary>
        /// Método de tipo constructor que recibe un parámetro de tipo TemplateContext. Asigna el contexto a una Entidad.
        /// </summary>
        /// <param name="_context">Parámetro de tipo TemplateContext</param>
        protected FinderRepository(TemplateContext _context) : base(_context)
        {
            if (_context == null)
            {
                throw new ArgumentNullException(nameof(_context));
            }
            entities = _context.Set<TEntity>();
        }

        /// <summary>
        /// Método genérico para obtener una entidad de la base de datos.
        /// </summary>
        /// <param name="_id">Parámetro de tipo identificador correspondiente a una entidad.</param>
        /// <returns> Retorna una entidad.</returns>
        public TEntity Get(Guid _id)
        {
            return entities.SingleOrDefault(x => x.Id == _id);
        }

        /// <summary>
        /// Método genérico para obtener una lista de entidades de la base de datos.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return entities.AsEnumerable();
        }

        /// <summary>
        /// Método para la busqueda de una lista de entidades por medio del nombre.
        /// </summary>
        /// <param name="_name">Representa el nombre de una entidad</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        public IEnumerable<TEntity> GetByName(string _name)
        {
            return entities.Where(x => x.Name == _name).ToList();
        }

        /// <summary>
        /// Método para la busqueda de entidades por medio de parametros.
        /// </summary>
        /// <param name="spec">Interfaz de tipo IQueryableSpecification que contiene los parámetros de búsqueda.</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        public IEnumerable<TEntity> GetByParam(IQueryableSpecification<TEntity> specification)
        {
            return FindManyByAsync(specification).Result.ToList();
        }
    }
}

using System;
using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using System.Collections.Generic;
using EGobX.NTemplate.Service.Exceptions;
using System.Linq;
using EGobX.Core.Repositories;
using System.Linq.Expressions;
using EGobX.NTemplate.Service.Implements.Catalog.Response;
using Recursos;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;

namespace EGobX.NTemplate.Service.Abstractions.AbstractClasses
{
    /// <summary>
    /// Clase abstracta que se encarga de realizar la busqueda de un registro o una lista de registros.
    /// </summary>
    public abstract class FinderService<TEntity> : IFinderService<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Atributo para el objeto de tipo IFinderTemplateRepository que se recibe como dependencia en el constructor.
        /// </summary>
        private readonly IFinderRepository<TEntity> _finderRepository;

        /// <summary>
        /// Atributo para el objeto de tipo ValidatorPaginate que se recibe como dependencia en el constructor.
        /// </summary>
        private readonly IValidatorPaginate<PaginationCatalog> _validatorPaginates;

        /// <summary>
        /// Atributo para definir la expresión de búsqueda.
        /// </summary>
        public Expression<Func<TEntity, bool>> expression = x => true;

        /// <summary>
        /// Método constructor de la clase que recibe como dependencia una interfaz de tipo IFinderTemplateRepository
        /// </summary>
        /// <param name="_finderTemplateRepository">Parámetro de tipo IFinderTemplateRepository</param>
        protected FinderService(IFinderRepository<TEntity> finderRepository, IValidatorPaginate<PaginationCatalog> validatorPaginate)
        {
            this._finderRepository = finderRepository ?? throw new ArgumentNullException(nameof(finderRepository));
            this._validatorPaginates = validatorPaginate ?? throw new ArgumentNullException(nameof(validatorPaginate));
        }

        /// <summary>
        /// Método que realiza la busqueda de un registro y retorna una entidad de tipo TEntity.
        /// </summary>
        /// <param name="id">Parámetro correspondiente a un identificador de una entidad</param>
        /// <returns>Una entidad de tipo TEntity</returns>
        public TEntity Get(Guid _id)
        {
            TEntity Entity = _finderRepository.Get(_id);
            if (Entity == null)
            {
                throw new GettingException(ADMCAT.L000005I);
            }
            return Entity;
        }

        /// <summary>
        /// Método que realiza la busqueda de registros y retorna una lista de tipo TEntity.
        /// </summary>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        public List<TEntity> GetAll()
        {
            List<TEntity> lstEntity = _finderRepository.GetAll().ToList();
            if (lstEntity == null)
            {
                throw new GettingException(ADMCAT.L000006I);
            }
            return lstEntity;
        }

        /// <summary>
        /// Método para la busqueda de una lista de entidades por medio del nombre.
        /// </summary>
        /// <param name="_name">Representa el nombre de una entidad</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        public List<TEntity> GetByName(string _name)
        {
            List<TEntity> lstEntity = _finderRepository.GetByName(_name).ToList();
            if (!lstEntity.Any())
            {
                throw new GettingException(ADMCAT.L000005I);
            }
            return lstEntity;
        }


        /// <summary>
        /// Método que realiza la busqueda de registros aplicando parámtros de búsqueda y paginación.
        /// </summary>
        /// <param name="specification">Parámtros de búsqueda y parámetros de paginación</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        public List<TEntity> GetByParam(IQueryableSpecification<TEntity> specification)
        {
            List<TEntity> lstEntity = _finderRepository.GetByParam(specification).ToList();
            if (lstEntity == null)
            {
                throw new GettingException(ADMCAT.L000006I);
            }
            return lstEntity;
        }

        /// <summary>
        /// Método para asignar criterios de fitros y criterios de paginación.
        /// </summary>
        /// <param name="paginationCatalog">Especificación de paginación.</param>
        /// <param name="criteriaExpression">Especificación de filtros para la expresión de búsqueda.</param>
        /// <returns>Especificación de búsqueda.</returns>
        private QuerySpecification<TEntity> GetQuerySpecification(PaginationCatalog paginationCatalog, Expression<Func<TEntity, bool>> criteriaExpression)
        {
            QuerySpecification<TEntity> spec = new QuerySpecification<TEntity>(criteriaExpression);

            spec.Paginate(SetPagination(paginationCatalog));

            return spec;
        }

        /// <summary>
        /// Método para especificar los valores de paginación.
        /// </summary>
        /// <param name="paginationCatalog"> Contiene la especificación de los parametros de paginación </param>
        /// <returns> Especificación de paginación. </returns>
        private PaginateSpecification SetPagination(PaginationCatalog paginationCatalog)
        {
            _validatorPaginates.Validate(paginationCatalog);
            PaginateSpecification paginableSpecification = new PaginateSpecification(paginationCatalog.page, paginationCatalog.pageSize);

            return paginableSpecification;
        }

        /// <summary>
        /// Método que realiza la busqueda de registros aplicando parámtros de búsqueda y paginación. 
        /// </summary>
        /// <param name="paginationCatalog">Parámetros de paginación</param>
        /// <returns>Objeto que contiene los registros consultados y la información de paginación</returns>
        public GetResponse<TEntity> GetByParam<T>(T paginationCatalog) where T : PaginationCatalog
        {
            var spec = GetQuerySpecification(paginationCatalog, expression);
            var templates = GetByParam(spec);

            GetResponse<TEntity> Result = new GetResponse<TEntity>(templates, spec.Pagination, paginationCatalog);

            return Result;
        }
    }
}

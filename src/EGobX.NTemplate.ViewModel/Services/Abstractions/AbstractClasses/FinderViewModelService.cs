using System;
using AutoMapper;
using System.Collections.Generic;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;
using EGobX.NTemplate.Domain.Entities;

namespace EGobX.NTemplate.ViewModel
{
    /// <summary>
    /// Clase que mapea la información en la busqueda de un registro o una lista de registros.
    /// </summary>
    /// <typeparam name="TEntity">TEntity : ICatalogEntity</typeparam>
    /// <typeparam name="TViewModel">TViewModel</typeparam>
    public abstract class FinderViewModelService<TEntity, TViewModel> : IFinderViewModelService<TEntity, TViewModel> 
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Atributo privado para el objeto de tipo IMapper que recibe como dependencia el constructor.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Atributo privado para el objeto de tipo IFinderService que recibe el constructor.
        /// </summary>
        private readonly IFinderService<TEntity> finderService;

        /// <summary>
        /// Método constructor de la clase que recibe dos interfaces cómo dependencias, inicializa las dependencias recibidas.
        /// </summary>
        /// <param name="_mapper">Parámetro de tipo IMapper.</param>
        /// <param name="_finderService">Parámetro de tipo IFinderService.</param>
        protected FinderViewModelService(IMapper _mapper, IFinderService<TEntity> _finderService)
        {
            this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this.finderService = _finderService ?? throw new ArgumentNullException(nameof(_finderService));
        }

        /// <summary>
        /// Método que mapea una entidad de tipo TEntity y retorna un TViewModel al buscar un registro.
        /// </summary>
        /// <param name="_id">Parámetro de tipo identificador de una entidad.</param>
        /// <returns>ViewModel de tipo template.</returns>
        public TViewModel Get(Guid _id)
        {
            TEntity template = finderService.Get(_id);
            return mapper.Map<TViewModel>(template);
        }

        /// <summary>
        /// Método que mapea una lista de entidades de tipo TEntity y retorna una lista de TViewModel.
        /// </summary>
        /// <returns>Devuelve una lista de entidades de tipo TViewModel</returns>
        public List<TViewModel> GetAll()
        {
            List<TEntity> lstTemplates = finderService.GetAll();
            return  mapper.Map<List<TViewModel>>(lstTemplates);
        }

        /// <summary>
        /// Método para la busqueda de una lista de entidades por medio del nombre.
        /// </summary>
        /// <param name="_name">Representa el nombre de una entidad</param>
        /// <returns>Lista de entidades de tipo genérico.</returns>
        public List<TViewModel> GetByName(string _name)
        {
            List<TEntity> lstTemplates = finderService.GetByName(_name);
            return mapper.Map<List<TViewModel>>(lstTemplates);
        }
    }
}

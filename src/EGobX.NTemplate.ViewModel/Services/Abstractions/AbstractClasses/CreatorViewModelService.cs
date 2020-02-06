using AutoMapper;
using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;
using System;

namespace EGobX.NTemplate.ViewModel.Services.Abstractions.AbstractClasses
{
    /// <summary>
    /// Clase abstracta que tiene como función de provee los métodos para el registro de un nuevo dato de cualquier catálogo,siempre y cuando se cumplan con las condiciones de herencia.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica. </typeparam>
    /// <typeparam name="TViewModel"> ViewModel genérico. </typeparam>
    public abstract class CreatorViewModelService<TEntity, TViewModel> : ICreatorViewModelService<TEntity, TViewModel>
        where TEntity : ICatalogEntity
    {
        /// <summary>
        /// Atributo privado que tiene como función resguardar la dependencia de la implementación de IMapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Atributo privado que tiene como función resguardar la dependencia ICreatorService inyectado en el constructor.
        /// </summary>
        private readonly ICreatorService<TEntity> creatorService;

        /// <summary>
        /// Constructor de la clase que inicializa y asigna datos por defecto.
        /// </summary>
        /// <param name="_mapper"> Encargado de Proveer los métodos para la transformación de Datos. </param>
        /// <param name="_creatorService"> Encargado de proveer el método que realiza el registro de un nuevo dato del catálogo. </param>
        protected CreatorViewModelService(IMapper _mapper, ICreatorService<TEntity> _creatorService)
        {
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            creatorService = _creatorService ?? throw new ArgumentNullException(nameof(_creatorService));
        }

        /// <summary>
        /// Método que se encarga de invocar el servicio de creación de registro de un catálogo,
        /// realiza la transformación del la "vista modelo" a la "entidad" del catálogo a guardar,
        /// posteriormente invoca el servicio de guardado del catálogo
        /// </summary>
        /// <param name="_viewModel"> Representa la información nueva a guardar del catálogo. </param>
        /// <returns>Retorna el Guid del registro creado.</returns>
        public Guid Create(TViewModel _viewModel)
        {
            TEntity entity = mapper.Map<TEntity>(_viewModel);
            Guid id = creatorService.Create(entity);

            return id;
        }
    }
}

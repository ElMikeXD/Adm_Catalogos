using System;
using AutoMapper;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;

namespace EGobX.NTemplate.ViewModel.Services.Abstractions.AbstractClasses
{
    /// <summary>
    /// Clase abstracta que tiene como función proveer métodos para actualizar el registro de cualquier catálogo siempre y cuando se cumplan con las condiciones de herencia.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad de tipo genérica </typeparam>
    /// <typeparam name="TViewModel"> ViewModel de tipo genérico </typeparam>
    public abstract class UpdaterViewModelService<TEntity, TViewModel> : IUpdaterViewModelService<TEntity, TViewModel>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Atributo para el objeto de tipo IMapper que recibe como dependencia el constructor de la clase
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Atributo para el objeto de tipo IUpdaterService que recibe como dependencia el constructor de la clase.
        /// </summary>
        private readonly IUpdaterService<TEntity> updateService;

        /// <summary>
        /// Atributo para el objeto de tipo IFinderService que recibe como dependencia el constructor de la clase.
        /// </summary>
        private readonly IFinderService<TEntity> finderService;

        /// <summary>
        /// Constructor de la clase que inicializa y asigna datos por defecto
        /// </summary>
        /// <param name="_mapper"> Dependencia correspondiente a la biblioteca que se encarga de mapear tipos diferentes de objetos. </param>
        /// <param name="_updaterService"> Dependencia correspondiente al servicio de actualización de una entidad genérica. </param>
        /// <param name="_finderService"> Dependencia correspondiente al servicio de busqueda de una entidad genérica. </param>
        protected UpdaterViewModelService(IMapper _mapper, IUpdaterService<TEntity> _updaterService, IFinderService<TEntity> _finderService)
        {
            this.mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this.updateService = _updaterService ?? throw new ArgumentNullException(nameof(_updaterService));
            this.finderService = _finderService ?? throw new ArgumentNullException(nameof(_finderService));
        }

        /// <summary>
        /// Método que se encarga de invocar el servicio de actualización de registro de un catálogo, realiza la transformación del la "vista modelo" a la "entidad" del catálogo a actualizar.
        /// </summary>
        /// <param name="_id"> Representa el identificador de una entidad a actualizar del catálogo </param>
        /// <param name="_viewModel"> Representa la información nueva a actualizar del catálogo </param>
        public void Update(Guid _id, TViewModel _viewModel)
        {
            TEntity entity = finderService.Get(_id);
            mapper.Map(_viewModel, entity);
            updateService.Update(_id, entity);
        }

        /// <summary>
        /// Método que se encarga de invocar el servicio de actualización del estado lógico de un registro de un catálogo, realiza la transformación del la "vista modelo" a la "entidad".
        /// </summary>
        /// <param name="_id"> Representa el identificador de una entidad a actualizar del catálogo. </param>
        /// <param name="_isActive"> Parámetro de tipo booleano para el cambio de estado lógico de una entidad.</param>
        public void UpdateState(Guid _id, bool _isActive)
        {
            updateService.UpdateState(_id, _isActive);
        }
    }
}

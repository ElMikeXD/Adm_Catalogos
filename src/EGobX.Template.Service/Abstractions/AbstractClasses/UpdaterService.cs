using System;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;

namespace EGobX.NTemplate.Service.Abstractions.AbstractClasses
{
    /// <summary>
    /// Clase abstracta correspondiente al servicio que realiza la actualización de información y el cambio lógico de una entidad.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad de tipo genérica</typeparam>
    public abstract class UpdaterService<TEntity> : IUpdaterService<TEntity>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Atributo para el objeto de tipo IUpdaterRepository que se recibe como dependencia en el constructor.
        /// </summary>
        private readonly IUpdaterRepository<TEntity> updaterRepository;

        /// <summary>
        /// Atributo para el objeto de tipo IFInderService que se recibe como dependencia en el constructor.
        /// </summary>
        private readonly IFinderService<TEntity> finderService;

        /// <summary>
        /// Atributo para el objeto de tipo IValidatorService que se recibe como dependencia en el constructor.
        /// </summary>
        private readonly IValidatorService<TEntity> validatorService;

        /// <summary>
        /// Atributo para resguardar el repositorio de obtención de fecha al guardar.
        /// </summary>
        private readonly IGetterDateRepository getterDateRepository;

        /// <summary>
        /// Constructor que recibe como dependencias las interfaces que contienen las definiciones de los métodos para actualizar una entidad
        /// </summary>
        /// <param name="_updaterRepository"> Servicio que proporciona los métodos para la actualización en el repositorio </param>
        /// <param name="_finderService"> Servicio que proporciona los métodos para de busqueda de una entidad. </param>
        /// <param name="_validatorService"> Servicio que proporciona los métodos para la validación de la entidad a actualizar. </param>
        /// <param name="_getterDateRepository"> Servicio que provee la asignación de la fecha a la entidad. </param>
        protected UpdaterService(IUpdaterRepository<TEntity> _updaterRepository, IFinderService<TEntity> _finderService, IValidatorService<TEntity> _validatorService, IGetterDateRepository _getterDateRepository)
        {
            this.updaterRepository = _updaterRepository ?? throw new ArgumentNullException(nameof(_updaterRepository));
            this.finderService = _finderService ?? throw new ArgumentNullException(nameof(_finderService));
            this.validatorService = _validatorService ?? throw new ArgumentNullException(nameof(_validatorService));
            this.getterDateRepository = _getterDateRepository ?? throw new ArgumentNullException(nameof(_getterDateRepository));
        }

        /// <summary>
        /// Método encargado de actualizar una entidad en el repositorio del catálogo que lo usa. Invoca a la validación correspondiente antes de actualizar.
        /// </summary>
        /// <param name="_id"> Identificador de la entidad que será actualizada. </param>
        /// <param name="_entity"> Entidad que será actualizada en el repositorio </param>
        public void Update(Guid _id, TEntity _entity)
        {
            var DateServer = getterDateRepository.GetDateTime();
            validatorService.Validate(_entity);
            _entity.ModifiedDate = DateServer;
            updaterRepository.Update(_entity);
        }

        /// <summary>
        /// Método encargado de cambiar el estado lógico de una entidad en el repositorio del catálogo que lo usa. Invoca a la validación correspondiente antes de la acción.
        /// </summary>
        /// <param name="_id"> Identificador de la entidad que cambiara de estado lógico </param>
        /// <param name="_isActive"> Estado lógico de la entidad en el repositorio. </param>
        public void UpdateState(Guid _id, bool _isActive)
        {
            TEntity entity = finderService.Get(_id);
            var DateServer = getterDateRepository.GetDateTime();
            entity.IsActive = _isActive;
            entity.ModifiedDate = DateServer;
            updaterRepository.Update(entity);
        }
    }
}

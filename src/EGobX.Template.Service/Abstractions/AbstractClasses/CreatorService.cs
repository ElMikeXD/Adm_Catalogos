using System;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using EGobX.NTemplate.Domain.Entities;

namespace EGobX.NTemplate.Service.Abstractions.AbstractClasses
{
    /// <summary>
    /// Clase abstracta que se encarga de crear un nuevo registro.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica de tipo TEntity. </typeparam>
    public abstract class CreatorService<TEntity> : ICreatorService<TEntity>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Atributo para resguardar el servicio del repositorio de almacenamiento.
        /// </summary>
        private readonly ICreatorRepository<TEntity> creatorRepository;

        /// <summary>
        /// Atributo para resguardar el servicio de validación de guardado.
        /// </summary>
        private readonly IValidatorService<TEntity> validatorService;

        /// <summary>
        /// Atributo para resguardar el repositorio de obtención de fecha al guardar.
        /// </summary>
        private readonly IGetterDateRepository getterDateRepository;

        /// <summary>
        /// Contructor que inicializa y asigna datos por defecto
        /// </summary>
        /// <param name="_creatorRepository"> Servicio que provee los métodos para el almacenamiento en el repositorio. </param>
        /// <param name="_validatorService"> Servicio que provee la validación de la lógica de almacenamiento de la entidad. </param>
        /// <param name="_getterDateRepository"> Servicio que provee la asignación de la fecha a la entidad. </param>
        protected CreatorService(ICreatorRepository<TEntity> _creatorRepository, IValidatorService<TEntity> _validatorService, IGetterDateRepository _getterDateRepository)
        {
            this.creatorRepository = _creatorRepository ?? throw new ArgumentNullException(nameof(_creatorRepository));
            this.validatorService = _validatorService ?? throw new ArgumentNullException(nameof(_validatorService));
            this.getterDateRepository = _getterDateRepository ?? throw new ArgumentNullException(nameof(_getterDateRepository));
        }

        /// <summary>
        /// Método que que se encarga de registrar una entidad en el repositorio del catálogo que lo usa, antes de invocar al guardado del repositorio se ejecuta la validación correspondiente.
        /// </summary>
        /// <param name="_entity">Entidad que se va a registrar en el repositorio</param>
        /// <returns>Retorna el Guid del registro creado.</returns>
        public Guid Create(TEntity _entity)
        {
            var DateServer = getterDateRepository.GetDateTime();
            validatorService.Validate(_entity);
            _entity.AddedDate = DateServer;
            _entity.ModifiedDate = DateServer;
            _entity.IsActive = true;
            Guid id = creatorRepository.Create(_entity);

            return id;
        }
    }
}

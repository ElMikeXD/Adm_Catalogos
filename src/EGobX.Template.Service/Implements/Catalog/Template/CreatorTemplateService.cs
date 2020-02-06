using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Service;
using EGobX.NTemplate.Service.Interfaces.Validator;
using EGobX.NTemplate.Service.Interfaces.Repository;
using EGobX.NTemplate.Service.Abstractions.AbstractClasses;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;

namespace EGobX.NTemplate.Service.Implements
{
    /// <summary>
    /// Servicio que valida la correcta comunicación y persistencia con el repositorio al crear un registro.
    /// </summary>
    public class CreatorTemplateService : CreatorService<Template>, ICreatorTemplateService
    {
        /// <summary>
        /// Constructor de la clase. Implementa un validador y un Repository
        /// </summary>
        /// <param name="_creatorRepository"> Parámetro de tipo ICreatorRepository </param>
        /// <param name="_validatorService"> Parámetro de tipo IValidatorService</param>
        /// <param name="_getterDateRepository"> Parámetro de tipo IgetterDateRepository</param>
        public CreatorTemplateService(ICreatorTemplateRepository _creatorRepository, IValidatorTemplateService _validatorService, IGetterDateRepository _getterDateRepository)
            : base(_creatorRepository, _validatorService, _getterDateRepository)
        {
        }
    }
}

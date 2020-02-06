using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Service;
using EGobX.NTemplate.Service.Interfaces.Repository;
using EGobX.NTemplate.Service.Interfaces.Validator;
using EGobX.NTemplate.Service.Abstractions.AbstractClasses;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;

namespace EGobX.NTemplate.Service.Implementss
{
    /// <summary>
    /// Servicio que valida la correcta comunicación y persistencia con el repositorio al actualizar un registro.
    /// </summary>
    public class UpdaterTemplateService : UpdaterService<Template>, IUpdaterTemplateService
    {
        /// <summary>
        /// Constructor que inicializa las dependencias que recibe la clase.
        /// </summary>
        /// <param name="_updaterRepository"> Representa el repositorio de actualización de una entidad. </param>
        /// <param name="_finderService"> Representa el servicio de busqueda de una entidad. </param>
        /// <param name="_validatorService"> Representa el servicio de validación de una entidad al actualizar. </param>
        public UpdaterTemplateService(IUpdaterTemplateRepository _updaterRepository, IFinderTemplateService _finderService, IValidatorTemplateService _validatorService, IGetterDateRepository _getterDateRepository)
            : base(_updaterRepository, _finderService, _validatorService, _getterDateRepository)
        {
        }
    }
}
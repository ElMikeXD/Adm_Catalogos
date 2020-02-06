using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Service;
using EGobX.NTemplate.Service.Abstractions.AbstractClasses;
using EGobX.NTemplate.Service.Interfaces.Repository;
using EGobX.NTemplate.Domain.DTO;
using EGobX.Core.Linq.Expressions;
using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;

namespace EGobX.NTemplate.Service.Implements
{
    /// <summary>
    /// Clase abstracta que se encarga de realizar la busqueda de un registro o una lista de registros.
    /// </summary>
    public class FinderTemplateService : FinderService<Template>, IFinderTemplateService
    {
        /// <summary>
        /// Atributo con los parámetros de búsqueda y los parámetros de paginación.
        /// </summary>
        public FinderTemplateDTO finderTemplateDTO { get; set; }

        /// <summary>
        /// Método constructor de la clase que recibe cómo dependencia un objeto de tipo Interfaz.
        /// </summary>
        /// <param name="_finderTemplateRepository"> Paramétros que recibe cómo dependencia la clase. </param>
        public FinderTemplateService(IFinderTemplateRepository finderTemplateRepository, IValidatorPaginate<PaginationCatalog> validatorFinderTemplate)
        : base(finderTemplateRepository, validatorFinderTemplate)
        {
        }

        /// <summary>
        /// Método que asigna los parámetros de búsqueda.
        /// </summary>
        public void SetExpression()
        {
            if (!finderTemplateDTO.viewAll)
                expression = expression.And(z => z.IsActive);

            if (!string.IsNullOrEmpty(finderTemplateDTO.name))
                expression = expression.And(z => z.Name.Contains(finderTemplateDTO.name));
        }
    }
}

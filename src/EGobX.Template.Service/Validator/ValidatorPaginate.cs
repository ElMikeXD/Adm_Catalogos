using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;
using Microsoft.Extensions.Configuration;

namespace EGobX.NTemplate.Service.Validator
{
    /// <summary>
    /// Clase encargada de la validación de los valores de paginación.
    /// </summary>
    public class ValidatorPaginate : IValidatorPaginate<PaginationCatalog>
    {
        /// <summary>
        /// Atributo para asignar la configuración del appsettings.json
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor de la clase para iniciarlizar los atributos declarados.
        /// </summary>
        /// <param name="configuration"> Atributo para la manejar la configuracion del proyecto </param>
        public ValidatorPaginate(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Método encargado de validar la especificación de paginación.
        /// </summary>
        /// <param name="pagination"> Parámetro que recibe una instancia de tipo plantilla </param>
        public void Validate(in PaginationCatalog pagination)
        {
            var pageResult = int.TryParse(_configuration.GetValue<string>("Paginate:Page"), out int pageconfig);
            var pageSizeResult = int.TryParse(_configuration.GetValue<string>("Paginate:PageSize"), out int pageSizeconfig);

            if (pagination.page == 0)
            {
                if (!pageResult)
                    pagination.page = 1;
                else
                    pagination.page = pageconfig;
            }

            if (pagination.pageSize == 0)
            {
                if (!pageSizeResult)
                    pagination.pageSize = 100;
                else
                    pagination.pageSize = pageSizeconfig;
            }
        }
    }
}

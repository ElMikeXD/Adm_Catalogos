using EGobX.Core.Repositories;
using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.Requests.Commons;
using System.Collections.Generic;

namespace EGobX.NTemplate.Service.Implements.Catalog.Response
{
    /// <summary>
    /// Clase que contiene información de la consulta realizada.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica. </typeparam>
    public class GetResponse<TEntity> : PagedResponse<TEntity> where TEntity : class
    {
        /// <summary>
        /// Constructor para instanciar la clase.
        /// </summary>
        /// <param name="result">Resultado.</param>
        /// <param name="pagination">Paginación de la consulta realizada.</param>
        public GetResponse(IEnumerable<TEntity> result, IPagination pagination, PaginationCatalog paginationCatalog) : base(result, pagination, paginationCatalog)
        {
        }
    }
}

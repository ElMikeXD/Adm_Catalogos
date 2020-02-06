using EGobX.Core.Repositories;
using EGobX.NTemplate.Domain.Entities.Base;
using System.Collections.Generic;

namespace EGobX.Requests.Commons
{
    /// <summary>
    /// Clase abstracta que implementa el resultado de la consulta de forma paginada.
    /// </summary>
    public class PagedResponse<TResult> : IPagedResponse<TResult> where TResult : class
    {
        /// <summary>
        /// Constructor para instanciar la clase.
        /// </summary>
        /// <param name="result">Resultado de la consulta realizada.</param>
        /// <param name="pagination">Paginación.</param>
        protected PagedResponse(IEnumerable<TResult> result, IPagination pagination, PaginationCatalog paginationCatalog)
        {
            Result = result;
            Pagination = pagination;
            PaginationCatalog = paginationCatalog;
        }

        /// <summary>
        /// Resultado de la paginación.
        /// </summary>
        public IPagination Pagination { get; }

        /// <summary>
        /// Resultado de la respuesta.
        /// </summary>
        public IEnumerable<TResult> Result { get; }

        /// <summary>
        /// Especificación de la paginación.
        /// </summary>
        public PaginationCatalog PaginationCatalog { get; }

    }
}

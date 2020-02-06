using EGobX.Core.Repositories;
using System.Collections.Generic;

namespace EGobX.Requests.Commons
{
    /// <summary>
    /// Interfaz que expone los métodos del resultado de la consulta realizada de forma paginada.
    /// </summary>
    public interface IPagedResponse<TResult> where TResult : class
    {
        /// <summary>
        /// Resultado de la paginación.
        /// </summary>
        IPagination Pagination { get; }

        /// <summary>
        /// Resultado de la respuesta.
        /// </summary>
        IEnumerable<TResult> Result { get; }
    }
}

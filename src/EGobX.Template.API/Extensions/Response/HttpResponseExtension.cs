using EGobX.Core.Repositories;
using EGobX.NTemplate.API.Extensions.Enumerators;
using EGobX.NTemplate.Domain.Entities.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace EGobX.NTemplate.API.Extensions.Response
{
    /// <summary>
    /// Extensión para HttpResponse.
    /// </summary>
    public static class HttpResponseExtension
    {
        /// <summary>
        /// Agrega la paginación.
        /// </summary>
        /// <param name="response">Respuesta Http.</param>
        /// <param name="Pagination">Paginación de la consulta realizada</param>
        /// <param name="paginationCatalog"> Especificación de la paginación.</param>
        public static void AddPagination(this HttpResponse response, IPagination Pagination, PaginationCatalog paginationCatalog)
        {
            var paginationHeader = new
            {
                Pagination.TotalRows,
                Pagination.TotalPage,
                PageSize = paginationCatalog.pageSize,
                CurrenPage = paginationCatalog.page,
            };

            response.Headers.Add("egobx-pagination", JsonConvert.SerializeObject(paginationHeader));
            response.Headers.Add("Access-Control-Expose-Headers", "egobx-pagination");
        }

        /// <summary>
        /// Agrega el mensaje al cabecero del headers
        /// </summary>
        /// <param name="response">Respuesta Http</param>
        /// <param name="type">Tipo de mensaje</param>
        /// <param name="message">Mensaje que se mostrará</param>
        /// <param name="args">Argumentos que se incluirán en el mensaje</param>
        public static void AddHeadersMessage(this HttpResponse response, MessageType type, string message, params string[] args)
        {
            if (args.Any())
                message = String.Format(message, args.ToArray());

            var paginationHeader = new
            {
                type,
                message
            };

            response.Headers.Add("egobx-message", JsonConvert.SerializeObject(paginationHeader));
            response.Headers.Add("Access-Control-Expose-Headers", "egobx-message");
        }
    }
}

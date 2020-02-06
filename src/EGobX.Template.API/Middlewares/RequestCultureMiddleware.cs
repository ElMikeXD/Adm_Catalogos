using Microsoft.AspNetCore.Http;
using Recursos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EGobX.NTemplate.API.Middlewares
{
    /// <summary>
    /// Clase encargada de recepcionar las peticiones y obtener el idioma que se envia en el encabezado para cambiar el CultureInfo.
    /// </summary>
    public class RequestCultureMiddleware
    {
        /// <summary>
        /// Dependencia de tipo RequestDelegate.
        /// </summary>
        private readonly RequestDelegate RequestDelegate;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="_requestDelegate">Dependencia de tipo RequestDelegate.</param>
        public RequestCultureMiddleware(RequestDelegate _requestDelegate)
        {
            RequestDelegate = _requestDelegate ?? throw new ArgumentNullException(nameof(_requestDelegate));
        }

        /// <summary>
        /// Toma el valor de la propiedad culture enviado en el encabezado de la solicitud y cambia CultureInfo de la aplicación.
        /// </summary>
        /// <param name="_context">Contexto de la petición.</param>
        /// <returns>Retorna el hilo de ejecución</returns>
        public async Task InvokeAsync(HttpContext _context)
        {
            var CultureQuery = _context.Request.Headers["culture"];
            if (!string.IsNullOrWhiteSpace(CultureQuery))
            {
                var Culture = new CultureInfo(CultureQuery);
                CultureInfo.CurrentCulture = Culture;
                CultureInfo.CurrentUICulture = Culture;
            }
            await RequestDelegate(_context);
        }
    }
}

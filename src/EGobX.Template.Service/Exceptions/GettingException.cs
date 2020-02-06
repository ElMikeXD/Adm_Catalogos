using System;

namespace EGobX.NTemplate.Service.Exceptions
{
    /// <summary>
    /// Clase para la obtención de una excepción.
    /// </summary>
    public class GettingException : Exception
    {
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public GettingException()
        {

        }

        /// <summary>
        /// Método para obtener un mensaje de tipo string.
        /// </summary>
        /// <param name="message"> Representa un mensaje de excepción de tipo string</param>
        public GettingException(string message) : base(message)
        {
        }
    }
}

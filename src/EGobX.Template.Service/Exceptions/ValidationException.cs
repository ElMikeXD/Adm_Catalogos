using System;

namespace EGobX.NTemplate.Service.Exceptions
{
    /// <summary>
    /// Clase encargada de la obtención de una excepción de validación.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ValidationException()
        {

        }

        /// <summary>
        /// Método de validación que recibe un mensaje de tipo string.
        /// </summary>
        /// <param name="message"> representación de un mensaje de excepción</param>
        public ValidationException(string message) : base(message)
        {

        }
    }
}

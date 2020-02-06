using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EGobX.NTemplate.Service.Common
{
    /// <summary>
    /// Clase que valida el resultado al obtener o no una excepción
    /// </summary>
    public abstract class ValidationResult
    {
        /// <summary>
        /// Mensajes de error
        /// </summary>
        public List<string> ErrorMessage { get; set; } = new List<string>();
        
        /// <summary>
        /// Definición de un método que valida si existe un mensaje de error.
        /// </summary>
        public bool IsValid { get { return !ErrorMessage.Any(); } }

        /// <summary>
        /// Método que inicializa una nueva instancia de una excepción.
        /// </summary>
        public void Valid() {
            if (!this.IsValid)
                throw new ValidationException(string.Join(Environment.NewLine, ErrorMessage));
        }
    }
}

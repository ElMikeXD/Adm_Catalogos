using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EGobX.NTemplate.Service.Abstractions.AbstractClasses
{
    /// <summary>
    /// Servicio que realiza la validación de la información perteneciente a una entidad.
    /// </summary>
    public abstract class ValidatorResult
    {
        /// <summary>
        /// Atributo que representa el mensaje de error que se obtiene.
        /// </summary>
        public List<string> ErrorMessage { get; set; } = new List<string>();

        /// <summary>
        /// Está propiedad se la asigna el resultado de la negación de la cuestión si la lista del mensaje tiene algún valor.
        /// </summary>
        public bool IsValid { get { return !ErrorMessage.Any(); } }

        /// <summary>
        /// Método que valida la entidad, en caso de no ser valida se lanza una excepción.
        /// </summary>
        public void Valid() {
            if (!this.IsValid)
                throw new ValidationException(string.Join(Environment.NewLine, ErrorMessage));
        }
    }
}

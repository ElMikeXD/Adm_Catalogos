using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Validator;
using EGobX.NTemplate.Service.Abstractions.AbstractClasses;
using Recursos;

namespace EGobX.NTemplate.Service.Validator
{
    /// <summary>
    /// Servicio para las validaciones del catálogo plantilla
    /// </summary>
    public class ValidatorTemplateService : ValidatorResult, IValidatorTemplateService
    {
        /// <summary>
        /// Método encargado de validar que la entidad recibida cumpla con los siguientes reglas
        /// </summary>
        /// <param name="_entity"> Entidad de tipo catalogo.</param>
        public void Validate(Template _entity)
        {
            if (_entity.Name == null)
                this.ErrorMessage.Add(ADMCAT.L000011E);
            else
            {
                if (string.IsNullOrEmpty(_entity.Name))
                    this.ErrorMessage.Add(ADMCAT.L000007A);

                if (_entity.Name.Length > 250)
                    this.ErrorMessage.Add(ADMCAT.L000008A);
            }

            if (_entity.Description == null)
                this.ErrorMessage.Add(ADMCAT.L000012E);
            else
            {
                if (_entity.Description.Length > 500)
                    this.ErrorMessage.Add(ADMCAT.L000009A);
            }

            this.Valid();
        }
    }
}

using EGobX.NTemplate.Domain.Entities.Base;
using System;

namespace EGobX.NTemplate.Domain.Entities
{
    /// <summary>
    /// Clase base para el dominio de datos de template con atributos genericos.
    /// </summary>
    public class BaseEntity : ICatalogEntity
    {
        /// <summary>
        /// Atributo de tipo Guid para asignar un identificador a una entidad.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Atributo correspondiente al nombre del template.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Atributo correspondiente a la fecha de agregación.
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// Atributo de tipo fecha para asignar la fecha de modificación de una entidad.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Atributo para el cambio de estado lógico de una entidad.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Atributo correspondiente al fólio.
        /// </summary>
        public int Folio { get; set; }
    }
}

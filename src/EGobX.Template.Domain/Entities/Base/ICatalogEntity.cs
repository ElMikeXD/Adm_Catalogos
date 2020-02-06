using System;

namespace EGobX.NTemplate.Domain.Entities.Base
{
    /// <summary>
    /// Interfaz genérica que contiene los atributos genéricos de una entidad.
    /// </summary>
    public interface ICatalogEntity
    {
        /// <summary>
        /// Atributo correspondiente a el identificador de un registro.
        /// </summary>
        Guid Id { get;}

        /// <summary>
        /// Atributo correspondiente al nombre del template.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Atributo correspondiente a la fecha de agregación de un registro.
        /// </summary>
        DateTime AddedDate { get; set; }

        /// <summary>
        /// Atributo correspondiente a la fecha de modificación de un registro.
        /// </summary>
        DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Atributo correspondiente al estado lógico de un registro.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Atributo correspondiente al fólio.
        /// </summary>
        int Folio { get; set; }
    }
}

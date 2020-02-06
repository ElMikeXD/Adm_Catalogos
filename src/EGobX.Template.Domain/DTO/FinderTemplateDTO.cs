using EGobX.NTemplate.Domain.Entities;

namespace EGobX.NTemplate.Domain.DTO
{
    /// <summary>
    /// Clase DTO para la entidad FinderTemplateDTO
    /// </summary>
    public class FinderTemplateDTO : FinderDTO
    {
        /// <summary>
        /// Nombre del template.
        /// </summary>
        public string name { get; set; }

    }
}

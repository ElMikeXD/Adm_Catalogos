using EGobX.NTemplate.Domain.Entities.Base;

namespace EGobX.NTemplate.Domain.Entities
{
    /// <summary>
    /// Clase DTO para la entidad que se buscará.
    /// </summary>
    public class FinderDTO : PaginationCatalog
    {
        /// <summary>
        /// Buscar todos.
        /// </summary>
        public bool viewAll { get; set; }

    }
}

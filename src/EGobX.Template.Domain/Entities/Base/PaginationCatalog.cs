namespace EGobX.NTemplate.Domain.Entities.Base
{
    /// <summary>
    /// Clase base para los entidad PaginationCatalog
    /// </summary>
    public class PaginationCatalog
    {
        /// <summary>
        /// Página.
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Tamaño de página.
        /// </summary>
        public int pageSize { get; set; }
    }
}

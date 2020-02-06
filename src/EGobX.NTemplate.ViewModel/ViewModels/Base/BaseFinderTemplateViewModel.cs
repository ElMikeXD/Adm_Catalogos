
namespace EGobX.NTemplate.ViewModel.ViewModels.Base
{
    /// <summary>
    /// Clase generica para los parámetros de paginación y estado lógico de los registros a filtrar.
    /// </summary>
    public class BaseFinderTemplateViewModel
    {
        /// <summary>
        /// Página.
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Tamaño de página.
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// Buscar todos.
        /// </summary>
        public bool viewAll { get; set; }
    }
}

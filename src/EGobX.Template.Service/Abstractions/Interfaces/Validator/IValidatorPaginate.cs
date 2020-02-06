namespace EGobX.NTemplate.Service.Abstractions.Interfaces.Validator
{
    /// <summary>
    /// Clase que contiene las definiciones de los métodos para validar la especificación de paginación.
    /// </summary>
    /// <typeparam name="PaginationCatalog"> Especificación de la paginación. </typeparam>
    public interface IValidatorPaginate<PaginationCatalog> where PaginationCatalog : class
    {
        /// <summary>
        /// Método encargado de validar una entidad genérica.
        /// </summary>
        /// <param name="_entity"> Parámetro que recibe una instancia de tipo plantilla.</param>
        void Validate(in PaginationCatalog pagination);
    }
}

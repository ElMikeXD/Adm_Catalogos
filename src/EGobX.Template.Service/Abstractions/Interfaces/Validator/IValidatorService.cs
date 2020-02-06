namespace EGobX.NTemplate.Service.Abstractions.Interfaces.Validator
{
    /// <summary>
    /// Interfaz correspondiente al servicio de validación de una entidad.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica. </typeparam>
    public interface IValidatorService<TEntity> where TEntity: class
    {
        /// <summary>
        /// Método encargado de validar una entidad genérica.
        /// </summary>
        /// <param name="_entity"> Parámetro que recibe una instancia de tipo plantilla.</param>
        void Validate(TEntity _entity);
    }
}

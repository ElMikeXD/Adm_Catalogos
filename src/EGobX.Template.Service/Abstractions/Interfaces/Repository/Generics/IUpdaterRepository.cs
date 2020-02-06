using EGobX.NTemplate.Domain.Entities.Base;

namespace EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics
{
    /// <summary>
    /// Interfaz que define el método genérico para actualizar una entidad en base de datos.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica </typeparam>
    public interface IUpdaterRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Definición del método genérico para crear una entidad en base de datos.
        /// </summary>
        /// <param name="_entity"> Representa la entidad genérica que será actualizada. </param>
        /// <returns> Retorna un entero que indica si es 1 se actualizo el registro si es 0 no se actualizo</returns>
        int Update(TEntity _entity);
    }
}

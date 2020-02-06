using EGobX.NTemplate.Domain.Entities.Base;
using System;

namespace EGobX.NTemplate.Service.Interfaces.Service.Generics
{
    /// <summary>
    /// Interfaz que contiene el método para crear una entidad.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica. </typeparam>
    public interface ICreatorService<TEntity> where TEntity: ICatalogEntity
    {
        /// <summary>
        /// Método que recibe una entidad de tipo ICatalogEntity al crear.
        /// </summary>
        /// <param name="_entity"> Entidad que se va registrar en el repositorio. </param>
        /// <returns>Retorna el Guid del registro creado.</returns>
        Guid Create(TEntity _entity);
    }
}

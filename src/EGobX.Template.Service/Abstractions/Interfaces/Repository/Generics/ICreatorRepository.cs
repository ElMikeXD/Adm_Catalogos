using EGobX.NTemplate.Domain.Entities.Base;
using System;

namespace EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics
{
    /// <summary>
    /// Interfaz que contiene el método genérico para crear una entidad en base de datos.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica. </typeparam>
    public interface ICreatorRepository<TEntity> where TEntity : ICatalogEntity
    {
        /// <summary>
        /// Definición del método genérico para crear una entidad en base de datos.
        /// </summary>
        /// <param name="_entity"> Representa la entidad de tipo Catálogo. </param>
        /// <returns>Retorna el Guid del registro creado.</returns>
        Guid Create(TEntity _entity);
    }
}

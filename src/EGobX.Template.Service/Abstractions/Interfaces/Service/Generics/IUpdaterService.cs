using System;

namespace EGobX.NTemplate.Service.Interfaces.Service.Generics
{
    /// <summary>
    /// Interfaz que contiene las definiciones de los métodos correspondiente al servicio de actualización de las entidades.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica </typeparam>
    public interface IUpdaterService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Firma del método correspondiente a la actualización de las entidades.
        /// </summary>
        /// <param name="_id"> Representa el identificador de una entidad a actualizar del catálogo. </param>
        /// <param name="_entity"> Parámetro que recibe una entidad genérica. </param>
        void Update(Guid _id, TEntity _entity);

        /// <summary>
        /// Firma del método correspondiente al cambio de estado lógico de las entidades.
        /// </summary>
        /// <param name="_id"> Representa el identificador de una entidad a actualizar del catálogo. </param>
        /// <param name="_isActive"> Parámetro de tipo booleano para el cambio de estado lógico de una entidad. </param>
        void UpdateState(Guid _id, bool _isActive);
    }
}

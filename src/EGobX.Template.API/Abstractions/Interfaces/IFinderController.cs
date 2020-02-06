using System;
using Microsoft.AspNetCore.Mvc;

namespace EGobX.NTemplate.API.Abstractions.Interfaces
{
    /// <summary>
    /// Interfaz que contiene métodos para la busqueda de una entidad o una lista de entidades.
    /// </summary>
    public interface IFinderController
    {
        /// <summary>
        /// Este método devuelve una lista de modelo-vista que se encuentren registrados en la base de datos.
        /// </summary>
        /// <returns> Retorna un action result (BadRequest si no se obtiene una lista u Ok si se obtiene la lista)</returns>
        ActionResult GetAll();

        /// <summary>
        /// Este método devuelve un registro de modelo-vista por medio de un identificador.
        /// </summary>
        /// <param name="id">Parámetro para el identificador de una entidad.</param>
        /// <returns> Retorna un action result (BadRequest si no se obtiene el registro u Ok si se obtiene el registro) </returns>
        ActionResult Get(Guid id);

        /// <summary>
        /// Este método devuelve un registro de modelo-vista por medio de un identificador.
        /// </summary>
        /// <param name="name">Parámetro para el nombre de una entidad.</param>
        /// <returns> Retorna un action result (BadRequest si no se obtiene el registro u Ok si se obtiene el registro) </returns>
        ActionResult GetByName(string name);
    }
}

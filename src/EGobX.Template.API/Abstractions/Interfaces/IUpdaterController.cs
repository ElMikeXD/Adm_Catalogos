using System;
using Microsoft.AspNetCore.Mvc;

namespace EGobX.NTemplate.API.Abstractions.Interfaces
{
    /// <summary>
    /// Clase que contiene la definición de los métodos correspondientes a actualizar o cambiar el estado lógico de una entidad. 
    /// </summary>
    /// <typeparam name="TViewModel"> ViewModel genérico </typeparam>
    public interface IUpdaterController<TViewModel>
    {
        /// <summary>
        /// Firma del método para la comunicación del backEnd con el FrontEnd Al actualizar un "Vista-Model"
        /// </summary>
        /// <param name="id"> Parámetro de tipo identificador de una entidad. </param>
        /// <param name="viewModel"> Parámetro que permite la lectura de una entidad de tipo ViewModel. </param>
        /// <returns> un action result que indica si se obtuvo un request 200 o un 400 </returns>
        ActionResult Update(Guid id, [FromBody] TViewModel viewModel);

        /// <summary>
        /// Método abstracto para el cambio de estado lógico de una entidad.
        /// </summary>
        /// <param name="id"> Representa el identificador de una entidad a actualizar del catálogo. </param>
        /// <param name="isActive"> Parámetro de tipo booleano para el cambio de estado lógico de una entidad.</param>
        /// <returns> un action result que indica si se obtuvo un request 200 o un 400</returns>
        ActionResult UpdateState(Guid id, [FromBody] bool isActive);
    }
}
using System;

namespace EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics
{
    /// <summary>
    /// Interfaz que contiene la firma del método para devolver una fecha.
    /// </summary>
    public interface IGetterDateRepository
    {
        /// <summary>
        /// Método encargado de obtener la fecha del día en curso.
        /// </summary>
        /// <returns> Retorna la fecha del día en curso </returns>
        DateTime GetDateTime();
    }
}
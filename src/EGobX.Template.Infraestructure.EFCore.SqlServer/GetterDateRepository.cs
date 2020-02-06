using System;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions
{
    /// <summary>
    /// Clase genérica que permite la interacción del servidor para obtener la fecha del día en curso.
    /// </summary>
    public class GetterDateRepository : IGetterDateRepository
    {
        /// <summary>
        /// Metodo que asigna la fecha del día en curso
        /// </summary>
        /// <returns> Retorna la fecha del día en curso que obtiene del servidor. </returns>
        public DateTime GetDateTime()
        {
            TimeZoneInfo setTimeZoneInfo;
            setTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");

            DateTime DateServer = TimeZoneInfo.ConvertTime(DateTime.UtcNow, setTimeZoneInfo);

            return DateServer;
        }
    }
}

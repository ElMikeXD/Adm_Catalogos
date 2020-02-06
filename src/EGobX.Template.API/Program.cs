using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace EGobX.Template.API
{
    /// <summary>
    /// Clase que es el punto de entrada de la aplicación en donde se configura el host de la misma.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método cuya funcion es ser el punto de entrada de la aplicación 
        /// </summary>
        /// <param name="args"> </param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Método al que puedan llamar en tiempo de diseño para configurar el host sin ejecutar la aplicación. 
        /// </summary>
        /// <param name="args"> </param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

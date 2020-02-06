using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Repository;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer
{
    /// <summary>
    /// Clase que hereda métodos genéricos para la comunicación con la base de datos  al actualizar.
    /// </summary>
    public class UpdaterTemplateRepository : UpdaterRepository<Template>, IUpdaterTemplateRepository
    {
        /// <summary>
        /// Constructor de la clase. Recibe como dependencia un TemplateContext
        /// </summary>
        /// <param name="_context"> Representa el contexto de tipo Catálogo. </param>
        public UpdaterTemplateRepository(TemplateContext _context) :
            base(_context)
        {
        }
    }
}
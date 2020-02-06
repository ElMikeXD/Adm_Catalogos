using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Repository;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer
{
    /// <summary>
    /// Clase que hereda de una clase genérica métodos para comunicar las entidades con la base de datos  al buscar una entidad o una lista de entidades.
    /// </summary>
    public class FinderTemplateRepository : FinderRepository<Template>, IFinderTemplateRepository
    {
        /// <summary>
        /// Constructor de la clase, se encarga de inicialiar atributos.
        /// </summary>
        /// <param name="_context"> Parámetro de tipo TemplateContext </param>
        public FinderTemplateRepository(TemplateContext _context) :
            base(_context)
        {
        }
    }
}

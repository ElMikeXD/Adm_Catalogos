using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Repository;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer
{
    /// <summary>
    /// Clase que hereda de una clase genérica métodos para comunicar las entidades con la base de datos al crear.
    /// </summary>
    public class CreatorTemplateRepository : CreatorRepository<Template>, ICreatorTemplateRepository
    {
        /// <summary>
        /// Constructor de la clase que se encarga de inicializar y asignar datos por defecto
        /// </summary>
        /// <param name="_context"> Contexto del Repositorio en la cual se va almacenar la información. </param>
        public CreatorTemplateRepository(TemplateContext _context)
            : base(_context)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Infraestructure.EFCore.Mappings;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer
{
    /// <summary>
    /// Clase que permite aplicar la configuración definida en el contexto. 
    /// </summary>
    public class TemplateContext: DbContext
    {
        /// <summary>
        /// Método constructor de la clase que recibe un parámetro de tipo DbContextOptions
        /// </summary>
        /// <param name="options"> Parámetro de tipo DbContextOptions </param>
        public TemplateContext(DbContextOptions options) :
            base(options)
        { }

        /// <summary>
        /// Método que permite la configuración del modelo con la base de datos.
        /// </summary>
        /// <param name="modelBuilder"> Parámetro de tipo ModelBuilder. </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TemplateMapping());
        }

        /// <summary>
        /// Atributo para consultar y guardar instancias de TEntity.
        /// </summary>
        public DbSet<Template> Templates { get; set; }
    }
}

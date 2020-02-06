using System;
using Microsoft.EntityFrameworkCore;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions
{
    /// <summary>
    /// Clase genérica que permite la interacción entre entidades y base de datos para la actualización o cambio de estado lógico de un registro.
    /// </summary>
    /// <typeparam name="TEntity">Entidad genérica</typeparam>
    public abstract class UpdaterRepository<TEntity> : IUpdaterRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Atributo para el objeto de tipo TemplateContext
        /// </summary>
        private readonly TemplateContext context;

        /// <summary>
        /// Atributo para el objeto que permite consultar y guardar instancias de tipo TEntity.
        /// </summary>
        private readonly DbSet<TEntity> entities;

        /// <summary>
        /// Constructor de la clase que inicializa el contexto.
        /// </summary>
        /// <param name="_context"> Dependencia para el contexto de tipo catálogo. </param>
        protected UpdaterRepository(TemplateContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
            entities = _context.Set<TEntity>();
        }

        /// <summary>
        /// Método que mantiene la persistencia con la base de datos para actualizar.
        /// </summary>
        /// <param name="_entity"> Representa una entidad genérica que será actualizada en base de datos. </param>
        /// <returns> Retorna un valor entero (1 o 0) que indica si la entidad fue actualizada o no. </returns>
        public int Update(TEntity _entity)
        {
            entities.Update(_entity);
            return context.SaveChanges();
        }
    }
}

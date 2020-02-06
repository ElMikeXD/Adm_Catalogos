using System;
using Microsoft.EntityFrameworkCore;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using EGobX.NTemplate.Service.Exceptions;
using Recursos;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions
{
    /// <summary>
    /// Clase abstracta genérica que provee los métodos necesarios para el registro de un nuevo dato en su repositorio correspondiente
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica </typeparam>
    public abstract class CreatorRepository<TEntity> : ICreatorRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Atributo que tiene como función resguardar el Contexto de la Base de Datos
        /// </summary>
        private readonly TemplateContext context;

        /// <summary>
        /// Atributo que resguarda la entidad a realizar las operaciones de inserción.
        /// </summary>
        private readonly DbSet<TEntity> entities;

        /// <summary>
        /// Constructor de la clase que inicializa y asigna datos por defecto
        /// </summary>
        /// <param name="_context"> Contexto de la Base de Datos en la cual se va almacenar la información. </param>
        protected CreatorRepository(TemplateContext _context)
        {
            context = _context ?? throw new ArgumentNullException(nameof(_context));
            entities = _context.Set<TEntity>();
        }

        /// <summary>
        /// Método que  realiza el guardado del registro de la entidad que lo implementa.
        /// </summary>
        /// <param name="_entity"> Entidad que se desea registrar en el Repositorio. </param>
        /// <returns>Retorna el Guid del registro creado.</returns>
        public Guid Create(TEntity _entity)
        {
            try
            {
                entities.Add(_entity);
                context.SaveChanges();

                return _entity.Id;
            }
            catch 
            {
                throw new GettingException(ADMCAT.L000010E);
            }
        }
    }
}

using System;
using Recursos;
using Microsoft.AspNetCore.Mvc;
using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.NTemplate.API.Abstractions.Interfaces;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;

namespace EGobX.NTemplate.API.Abstractions.AbstractClasses
{
    /// <summary>
    /// Clase abstracta que tiene como proposito proveer los métodos para crear nuevos datos
    /// del catálogo que lo herede, estos nuevos método son orientados al uso de API REST.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica. </typeparam>
    /// <typeparam name="TViewModel"> ViewModel genérico. </typeparam>
    public abstract class CreatorController<TEntity, TViewModel> : ControllerBase, ICreatorController<TViewModel>
        where TEntity : ICatalogEntity
    {
        /// <summary>
        /// Atributo de tipo ICreatorViewModelService.
        /// </summary>
        private readonly ICreatorViewModelService<TEntity, TViewModel> creatorViewModelService;

        /// <summary>
        /// Constructor de la clase que asigna e inicializa datos por defecto.
        /// </summary>
        /// <param name="_creatorViewModelService"> Servicio que proporciona el método de creación de un registro del catálogo en particular.</param>
        protected CreatorController(ICreatorViewModelService<TEntity, TViewModel> _creatorViewModelService)
        {
            creatorViewModelService = _creatorViewModelService ?? throw new ArgumentNullException(nameof(_creatorViewModelService));
        }

        /// <summary>
        /// Crea nuevo template.
        /// </summary>
        /// <param name="viewModel">Template a crear.</param>
        /// <returns> Información del registro y la URL donde se puede consultar dicha información, en caso que error, se generar un BadRequest con el mensaje de error correspondiente. </returns>
        [HttpPost]
        public ActionResult Create([FromBody] TViewModel viewModel)
        {
            Guid idTemplate;
            try
            {
                idTemplate = creatorViewModelService.Create(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return new JsonResult(new { id = idTemplate, message = ADMCAT.L000001I });
        }
    }
}

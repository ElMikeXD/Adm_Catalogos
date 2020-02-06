using System;
using Recursos;
using Microsoft.AspNetCore.Mvc;
using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.NTemplate.API.Abstractions.Interfaces;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;

namespace EGobX.NTemplate.API.Abstractions.AbstractClasses
{
    /// <summary>
    /// Clase abstracta que tiene como proposito proveer los métodos para actualizar registros del catálogo que lo herede. Los métodos son orientados al uso de API REST.
    /// </summary>
    /// <typeparam name="TEntity"> Entidad genérica</typeparam>
    /// <typeparam name="TViewModel"> ViewModel genérico </typeparam>
    public abstract class UpdaterController<TEntity, TViewModel> : ControllerBase, IUpdaterController<TViewModel>
        where TEntity : ICatalogEntity
    {
        /// <summary>
        /// Atributo de tipo IUpdaterViewModelService que recibe un tipo TEntity y un tipo TViewModel
        /// </summary>
        private readonly IUpdaterViewModelService<TEntity, TViewModel> updaterViewModelService;

        /// <summary>
        /// Constructor de la clase que inicializa las dependencias.
        /// </summary>
        /// <param name="_updaterViewModelService"> Dependencia correspondiente a recibir el método para actualizar una entidad genérica. </param>
        protected UpdaterController(IUpdaterViewModelService<TEntity, TViewModel> _updaterViewModelService)
        {
            updaterViewModelService = _updaterViewModelService ?? throw new ArgumentNullException(nameof(_updaterViewModelService));
        }

        /// <summary>
        /// Actualiza la información de un template. 
        /// </summary>
        /// <param name="id">Identificador del template a modificar.</param>
        /// <param name="viewModel">Información actualizada del template.</param>
        /// <returns> Retorna un viewModel actualizado. En caso de error envía un BadRequest con el mensaje de error correspondiente. </returns>
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] TViewModel viewModel)
        {
            try
            {
                updaterViewModelService.Update(id, viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(ADMCAT.L000002I);
        }

        /// <summary>
        /// Actualiza el estado lógico de un template. 
        /// </summary>
        /// <param name="id">Identificador del template a modificar</param>
        /// <param name="isActive">Estado lógico para el template.</param>
        /// <returns> Un viewModel actualizado. En caso de error envía un BadRequest con el mensaje de error correspondiente.</returns>
        [HttpPatch("{id}")]
        public ActionResult UpdateState(Guid id, [FromBody] bool isActive)
        {
            try
            {
                updaterViewModelService.UpdateState(id, isActive);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(isActive ? ADMCAT.L000003I : ADMCAT.L000004I);
        }
    }
}

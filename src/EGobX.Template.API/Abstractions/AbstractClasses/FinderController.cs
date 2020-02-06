using System;
using Microsoft.AspNetCore.Mvc;
using EGobX.NTemplate.API.Abstractions.Interfaces;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;
using System.Collections.Generic;

namespace EGobX.NTemplate.API.Abstractions.AbstractClasses
{
    /// <summary>
    ///Clase abstracta generica que contiene los métodos para la comunicación entre el frontend y backend para la consulta de un registro o una lista de registros.
    /// </summary>
    public abstract class FinderController<TEntity, TViewModel> : ControllerBase, IFinderController
        where TEntity : class
        where TViewModel : class
    {
        /// <summary>
        /// Atributo de tipo IFinderViewModelService que recibe una entidad de tipo TEntity y un TViewModel.
        /// </summary>
        private readonly IFinderViewModelService<TEntity, TViewModel> finderViewModelService;

        /// <summary>
        /// Constructor de la clase que recibe como dependencias una interfaz de tipo IFinderViewModelService.
        /// </summary>
        /// <param name="_finderViewModelService">Parámetro de tipo IFinderViewModelService</param>
        protected FinderController(IFinderViewModelService<TEntity, TViewModel> _finderViewModelService)
        {
            finderViewModelService = _finderViewModelService ?? throw new ArgumentNullException(nameof(_finderViewModelService));
        }

        /// <summary>
        /// Obtiene template por Guid.
        /// </summary>
        /// <param name="id">Identificador del template a encontrar.</param>
        /// <returns>Se devuele un registro modelo-vista.</returns>
        [Route("{id}", Name = "Get")]
        [HttpGet]
        public ActionResult Get(Guid id)
        {
            TViewModel result;
            try
            {
                result = finderViewModelService.Get(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(result);
        }

        /// <summary>
        /// Obtiene templates.
        /// </summary>
        /// <returns>Se devuele una lista de registros modelo-vista.</returns>
        [HttpGet]
        public ActionResult GetAll()
        {
            List<TViewModel> result;
            try
            {
                result = finderViewModelService.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        /// <summary>
        /// Obtiene templates por nombre de template.
        /// </summary>
        /// <param name="name">Nombre del template a encontrar.</param>
        /// <returns>Se devuele un registro modelo-vista.</returns>
        [Route("[action]/{name}", Name = "GetByName")]
        [HttpGet]
        public ActionResult GetByName(string name)
        {
            List<TViewModel> result;
            try
            {
                result = finderViewModelService.GetByName(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
    }
}

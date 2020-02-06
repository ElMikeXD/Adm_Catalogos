using Microsoft.AspNetCore.Mvc;
using EGobX.NTemplate.ViewModel;
using EGobX.NTemplate.ViewModel.Services;
using EGobX.NTemplate.API.Abstractions.AbstractClasses;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;
using System;
using EGobX.NTemplate.API.Extensions.Response;
using EGobX.NTemplate.Service.Implements.Catalog.Response;


namespace EGobX.NTemplate.API.Controllers.Catalog.Template
{
    /// <summary>
    /// Controlador para las las apis búsqueda de templates.
    /// </summary>
    [Route("api/Template")]
    [ApiController]
    public class FinderTemplateController : FinderController<Domain.Entities.Template, TemplateViewModel>
    {
        private readonly IFinderTemplateViewModelService _finderTemplateViewModel;

        /// <summary>
        /// Constructor de la clase, implementa la clase FinderTemplateViewModelService.
        /// </summary>
        /// <param name="finderTemplateViewModel">Parámetro de tipo IFinderTemplateViewModelService</param>
        public FinderTemplateController(IFinderTemplateViewModelService finderTemplateViewModel) :
            base(finderTemplateViewModel)
        {
            _finderTemplateViewModel = finderTemplateViewModel;
        }

        /// <summary>
        /// Obtiene templates paginados, filtra por estado lógico y por nombre.
        /// </summary>
        /// <param name="finderTemplateViewModel">Filtros de búsqueda</param>
        /// <returns>Se devuele una lista de registros modelo-vista.</returns>
        [Route("[action]", Name = "GetByParam")]
        [HttpGet]
        public ActionResult GetByParam([FromQuery]FinderTemplateViewModel finderTemplateViewModel)
        {
            GetResponse<TemplateViewModel> result;
            try
            {
                result = _finderTemplateViewModel.GetByParam(finderTemplateViewModel);

                Response.AddPagination(result.Pagination, result.PaginationCatalog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result.Result);
        }
    }
}
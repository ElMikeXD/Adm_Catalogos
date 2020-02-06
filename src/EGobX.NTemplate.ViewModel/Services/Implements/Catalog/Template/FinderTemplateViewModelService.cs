using AutoMapper;
using EGobX.NTemplate.Domain.DTO;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Implements.Catalog.Response;
using EGobX.NTemplate.Service.Interfaces.Service;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;
using System.Collections.Generic;

namespace EGobX.NTemplate.ViewModel.Services
{
    /// <summary>
    /// Clase que hereda de la clase genérica para la busqueda de una entidad o una lista de entidades.
    /// </summary>
    public class FinderTemplateViewModelService : FinderViewModelService<Template, TemplateViewModel>, IFinderTemplateViewModelService
    {
        /// <summary>
        /// Atributo privada que contiene las acciones de búsqueda de templates
        /// </summary>
        private readonly IFinderTemplateService _finderTemplateService;

        /// <summary>
        /// Atributo privado para el objeto de tipo IMapper que recibe como dependencia el constructor.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase que inicializa e asigna datos por defecto
        /// </summary>
        /// <param name="_mapper">Parámetro de tipo IMapper.</param>
        /// <param name="_finderTemplateService">Dependencia correspondiente al servicio de busqueda de una entidad.</param>
        public FinderTemplateViewModelService(IMapper mapper, IFinderTemplateService finderTemplateService) :
            base(mapper, finderTemplateService)
        {
            _finderTemplateService = finderTemplateService;
            _mapper = mapper;
        }

        /// <summary>
        /// Método para la busqueda de entidades por medio de parametros.
        /// </summary>
        /// <param name="finderTemplateViewModel">Parámetro que contiene los valores de filtro y los parámtros de paginación.</param>
        /// <returns>Objeto que contiene los registros consultados y la información de paginación</returns>
        public GetResponse<TemplateViewModel> GetByParam(FinderTemplateViewModel finderTemplateViewModel)
        {
            _finderTemplateService.finderTemplateDTO = _mapper.Map<FinderTemplateDTO>(finderTemplateViewModel);
            this._finderTemplateService.SetExpression();
            var getResponseTemplate = _finderTemplateService.GetByParam<FinderTemplateDTO>(_finderTemplateService.finderTemplateDTO);
            IEnumerable<TemplateViewModel> templateViewModels = _mapper.Map<List<TemplateViewModel>>(getResponseTemplate.Result);

            GetResponse<TemplateViewModel> Result = new GetResponse<TemplateViewModel>(templateViewModels, getResponseTemplate.Pagination, getResponseTemplate.PaginationCatalog);

            return Result;
        }
    }
}

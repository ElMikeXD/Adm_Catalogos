using AutoMapper;
using EGobX.NTemplate.Domain.DTO;
using EGobX.NTemplate.ViewModel;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;

namespace EGobX.NTemplate.API.Mapping
{
    /// <summary>
    /// Clase para la configuración del map
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Configuración del map
        /// </summary>
        public MappingProfile()
        {
            //map_post_put
            CreateMap<Domain.Entities.Template, TemplateViewModel>();
            CreateMap<TemplateViewModel, Domain.Entities.Template>();

            //map_get
            CreateMap<Domain.Entities.Template, CreatorTemplateViewModel>();
            CreateMap<CreatorTemplateViewModel, Domain.Entities.Template>();

            //map_getbyparam
            CreateMap<FinderTemplateViewModel, FinderTemplateDTO>();
        }
    }
}

using EGobX.NTemplate.API.Extensions;
using EGobX.NTemplate.Service.Validator;
using EGobX.NTemplate.Service.Implements;
using EGobX.NTemplate.ViewModel.Services;
using EGobX.NTemplate.Service.Implementss;
using Microsoft.Extensions.DependencyInjection;
using EGobX.NTemplate.Service.Interfaces.Service;
using EGobX.NTemplate.Service.Interfaces.Validator;
using EGobX.NTemplate.Service.Interfaces.Repository;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions;
using EGobX.NTemplate.Domain.Entities.Base;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;

namespace EGobX.NTemplate.API.Containers
{
    /// <summary>
    /// Clase que tiene como proposito contener las configuraciones correspondientes a las inyecciones de dependencias.
    /// </summary>
    public class TemplateDependecy : IConfigurationDI
    {
        /// <summary>
        /// Método para agregar las dependencias de las clases
        /// </summary>
        /// <param name="services"> Especifica una colección de descripciones de servicios.</param>
        public void AddDependecy(IServiceCollection services)
        {
            services.AddTransient<IGetterDateRepository, GetterDateRepository>();

            services.AddTransient<ICreatorTemplateViewModelService, CreatorTemplateViewModelService>();
            services.AddTransient<ICreatorTemplateService, CreatorTemplateService>();
            services.AddTransient<ICreatorTemplateRepository, CreatorTemplateRepository>();
            services.AddTransient<IValidatorTemplateService, ValidatorTemplateService>();

            services.AddTransient<IFinderTemplateViewModelService, FinderTemplateViewModelService>();
            services.AddTransient<IFinderTemplateService, FinderTemplateService>();
            services.AddTransient<IFinderTemplateRepository, FinderTemplateRepository>();
            services.AddTransient<IValidatorPaginate<PaginationCatalog>, ValidatorPaginate> ();


            services.AddTransient<IUpdaterTemplateViewModelService, UpdaterTemplateViewModelService>();
            services.AddTransient<IUpdaterTemplateService, UpdaterTemplateService>();
            services.AddTransient<IUpdaterTemplateRepository, UpdaterTemplateRepository>();

        }
    }
}

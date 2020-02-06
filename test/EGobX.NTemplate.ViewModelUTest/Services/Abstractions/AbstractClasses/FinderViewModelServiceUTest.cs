using System;
using Xunit;
using Moq;
using AutoMapper;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.ViewModel;
using System.Collections.Generic;
using System.Linq;
using EGobX.NTemplate.Service.Exceptions;

namespace EGobX.NTemplate.ViewModelUTest.Services.Abstractions.AbstractClasses
{
    /// <summary>
    /// Las clases que se agregan en esta sección sirven para representar
    /// la herencia de la clase abstracta FinderViewModelService con sus clases hijas
    /// </summary>
    #region [Clases Hijas] 
    public class ClassFinderViewModelService : FinderViewModelService<Template, TemplateViewModel>
    {
        public ClassFinderViewModelService(IMapper _mapper, IFinderService<Template> _finderService)
            : base(_mapper, _finderService)
        {
        }
    }
    #endregion

    public class FinderViewModelServiceUTest
    {
        #region[Method: Get]
        /// <summary>
        /// La ejecución de la prueba deberá retornar un template tras invocar al servicio de busqueda.
        /// </summary>
        [Fact]
        public void Get_InvokeService_ReturnTemplate()
        {
            //Arrange
            Template template = new Template();
            template.Id = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
            template.Name = "Test";
            template.Description = "Test Description";

            //Moq
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            MapperConfiguration mapperconfig = new MapperConfiguration(_mapper =>
            {
                _mapper.CreateMap<Template, TemplateViewModel>();
            });

            IMapper mapper = mapperconfig.CreateMapper();
            finderService.Setup((_finderService) => _finderService.Get(template.Id)).Returns(template);

            //SUT
            var SUT = new ClassFinderViewModelService(mapper, finderService.Object);
            var result = SUT.Get(template.Id);

            //Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// La ejecución de la prueba deberá retornar un template nulo tras invocar al servicio de busqueda.
        /// </summary>
        [Fact]
        public void Get_InvokeService_ReturnTemplateEmpty()
        {
            //Arrange
            var id = new Guid("00000000-0000-0000-0000-000000000000");

            //Mock
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            MapperConfiguration mapperconfig = new MapperConfiguration(_mapper =>
            {
                _mapper.CreateMap<Template, TemplateViewModel>();
            });
            IMapper mapper = mapperconfig.CreateMapper();

            finderService.Setup((_finderService) => _finderService.Get(id));

            //SUT
            var SUT = new ClassFinderViewModelService(mapper, finderService.Object);

            //Act
            var templateFound = SUT.Get(id);

            //Assert
            Assert.Null(templateFound);
        }

        /// <summary>
        /// La ejecución de la prueba unitaria valida que se realice la conversión de una entidad a un viewModel.
        /// </summary>
        [Fact]
        public void Get_ConvertEntity_ConvertSuccessful()
        {
            //Arrange
            Template template = new Template();
            template.Id = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
            TemplateViewModel templateViewModel = new TemplateViewModel();

            //Mock
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            finderService.Setup((service) => service.Get(template.Id)).Returns(template);
            mapper.Setup((map) => map.Map<TemplateViewModel>(template)).Returns(templateViewModel);

            //Act
            var SUT = new ClassFinderViewModelService(mapper.Object, finderService.Object);
            var result = SUT.Get(template.Id);

            //Assert
            Assert.IsType<TemplateViewModel>(result);
        }
        #endregion

        #region[Method: GetAll]

        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar una lista de Templates.
        /// </summary>
        [Fact]
        public void GetAll_InvokeService_ReturnsListTemplate()
        {
            //Arrange
            List<Template> lstTemplate = new List<Template>() { new Template()
            {   Id = new Guid("4EC575AB-1649-4F0F-43BF-08D78D888A4C"),
                Name = "prueba",
                Description = "prueba",
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            } };

            //Mock
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            MapperConfiguration mapperconfig = new MapperConfiguration(_mapper =>
            {
                _mapper.CreateMap<Template, TemplateViewModel>();
            });

            IMapper mapper = mapperconfig.CreateMapper();

            finderService.Setup((_finderService) => _finderService.GetAll()).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderViewModelService(mapper, finderService.Object);

            //Assert
            Assert.True(SUT.GetAll().Any());
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debería de retornar una lista de Templates vacía.
        /// </summary>
        [Fact]
        public void GetAll_InvokeService_ReturnsListTemplateEmpty()
        {
            //Arrange
            List<Template> lstTemplate = new List<Template>();

            //Mock
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            MapperConfiguration mapperconfig = new MapperConfiguration(_mapper =>
            {
                _mapper.CreateMap<Template, TemplateViewModel>();
            });

            IMapper mapper = mapperconfig.CreateMapper();

            finderService.Setup((_finderService) => _finderService.GetAll()).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderViewModelService(mapper, finderService.Object);

            //Assert
            Assert.True(!SUT.GetAll().Any());
        }
        #endregion

        #region [Method: GetByName]
        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver un mensaje de error cuando no exista el template con el nombre solicitado.
        /// </summary>
        [Fact]
        public void GetByName_InvokeServiceNotExistsName_ReturnsGettingException()
        {
            //Mock
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            MapperConfiguration mapperconfig = new MapperConfiguration(_mapper =>
            {
                _mapper.CreateMap<Template, TemplateViewModel>();
            });

            IMapper mapper = mapperconfig.CreateMapper();
            finderService.Setup((_finderService) => _finderService.GetByName("Prueba_1")).Throws(new GettingException("Registro no encontrado."));

            //SUT
            var SUT = new ClassFinderViewModelService(mapper, finderService.Object);

            //Assert
            Assert.Throws<GettingException>(() => SUT.GetByName("Prueba_1"));
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver una lista de templates
        /// </summary>
        [Fact]
        public void GetByName_InvokeServiceExistsName_ReturnsListTemplate()
        {
            //Arrange
            List<Template> lstTemplate = new List<Template>() { new Template {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Name = "Prueba",
                    Description = "Prueba",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                },
                new Template {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Name = "Prueba",
                    Description = "Prueba",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                }};

            //Mock
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            MapperConfiguration mapperconfig = new MapperConfiguration(_mapper =>
            {
                _mapper.CreateMap<Template, TemplateViewModel>();
            });

            IMapper mapper = mapperconfig.CreateMapper();
            finderService.Setup((_finderService) => _finderService.GetByName("Prueba")).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderViewModelService(mapper, finderService.Object);

            //Assert
            Assert.NotEmpty(SUT.GetByName("Prueba"));
        }

        #endregion
    }
}

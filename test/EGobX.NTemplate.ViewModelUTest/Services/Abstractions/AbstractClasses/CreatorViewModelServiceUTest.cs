using AutoMapper;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Exceptions;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using EGobX.NTemplate.ViewModel.Services.Abstractions.AbstractClasses;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;
using Moq;
using System;
using Xunit;

namespace EGobX.NTemplate.ViewModelUTest.Services.Abstractions.AbstractClasses
{
    #region [Clases heredadas]
    /// <summary>
    /// La clase perteneciente a esta sección representa la clase abstracta
    /// </summary>
    public class ClassCreatorViewModelService : CreatorViewModelService<Template, CreatorTemplateViewModel>
    {
        public ClassCreatorViewModelService(IMapper _mapper, ICreatorService<Template> _creatorService) : base(_mapper, _creatorService)
        {
        }
    }
    #endregion
    public class CreatorViewModelServiceUTest
    {
        #region[method: CreatorViewModelService]
        /// <summary>
        /// La ejecución de la prueba obtiene una excepción al recibir nula la dependencia correspondiente al servicio de crear.
        /// </summary>
        [Fact]
        public void CreatorViewModelService_ICreatorServiceIsNull_GenerateException()
        {
            //Mock
            Mock<IMapper> mapper = new Mock<IMapper>();
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ClassCreatorViewModelService(mapper.Object, null));
        }

        /// <summary>
        /// La prueba valida que se reciba nula la dependencia a la clase Mapper y obtiene una excepción.
        /// </summary>
        [Fact]
        public void CreatorViewModelService_IMapperIsNull_GenerateException()
        {
            //Mock
            Mock<ICreatorService<Template>> creatorService = new Mock<ICreatorService<Template>>();
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ClassCreatorViewModelService(null, creatorService.Object));
        }
        #endregion

        #region[method: Create]
        /// <summary>
        /// La prueba unitaria valida que se cree un registro.
        /// </summary>
        [Fact]
        public void create_RegistroCreadoExitosamente_Create()
        {
            //Arrange
            Template template = new Template();
            CreatorTemplateViewModel templateViewModel = new CreatorTemplateViewModel();

            //Mock
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<ICreatorService<Template>> creatorService = new Mock<ICreatorService<Template>>();
            mapper.Setup((map) => map.Map<Template>(templateViewModel)).Returns(template);
            creatorService.Setup((create) => create.Create(template));
            //SUT
            var SUT = new ClassCreatorViewModelService(mapper.Object, creatorService.Object);
            SUT.Create(templateViewModel);
            //Assert
            Assert.True(true);
        }

        /// <summary>
        /// La prueba unitaria valida que se envie una excepción y no se cree un registro.
        /// </summary>
        [Fact]
        public void create_RegistroCreadoExitosamente_NotCreate()
        {
            //Arrange
            Template template = new Template();
            CreatorTemplateViewModel templateViewModel = new CreatorTemplateViewModel();

            //Mock
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<ICreatorService<Template>> creatorService = new Mock<ICreatorService<Template>>();
            mapper.Setup((map) => map.Map<Template>(templateViewModel)).Returns(template);
            creatorService.Setup((create) => create.Create(template)).Throws(new GettingException());
            //SUT
            var SUT = new ClassCreatorViewModelService(mapper.Object, creatorService.Object);
            //Assert
            Assert.Throws<GettingException>(() => SUT.Create(templateViewModel));
        }

        /// <summary>
        /// Prueba unitaria para la evaluar que se retorne un Guid
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void Create_RecordCreated_ReturnGuid()
        {
            //Arrange
            Template template = new Template();
            CreatorTemplateViewModel templateViewModel = new CreatorTemplateViewModel();

            //Mock
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<ICreatorService<Template>> creatorService = new Mock<ICreatorService<Template>>();
            mapper.Setup((map) => map.Map<Template>(templateViewModel)).Returns(template);
            creatorService.Setup((create) => create.Create(template)).Returns(new Guid("23CD9099-DCC2-4CD5-CEB5-08D7961EA229"));
            //SUT
            var SUT = new ClassCreatorViewModelService(mapper.Object, creatorService.Object);
            Guid id = SUT.Create(templateViewModel);

            //Assert
            Assert.IsType<Guid>(id);
        }
        #endregion
    }
}

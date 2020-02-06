using EGobX.NTemplate.API.Abstractions.AbstractClasses;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;
using EGobX.NTemplate.ViewModel.ViewModels.Catalog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace EGobX.NTemplate.APIUTest.Abstractions.AbstractClasses
{
    #region [Class]
    /// <summary>
    /// Las clases que se agregan en esta sección sirven para representar
    /// la herencia de la clase abstracta CreatorController con sus clases hijas
    /// </summary>
    public class ClassCreatorController : CreatorController<Domain.Entities.Template, CreatorTemplateViewModel /*TemplateViewModel*/>
    {
        public ClassCreatorController(ICreatorViewModelService<Domain.Entities.Template, CreatorTemplateViewModel/*TemplateViewModel*/> _creatorViewModelService) : base(_creatorViewModelService)
        {
        }
    }
    #endregion

    public class CreatorControllerUTest
    {
        /// <summary>
        /// La ejecución de la prueba valida que se obtenga una excepción al recibir dependencias nulas.
        /// </summary>
        [Fact]
        public void CreatorController_DependencyNull_NullExcepción()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassCreatorController(null));
        }

        /// <summary>
        /// Prueba unitaria que evalúa la respuesta cuando se generó de forma exitosa el registro
        /// </summary>
        [Fact]
        public void Create_CreacionExitosa_Respuesta200Http()
        {
            //Arrange
            CreatorTemplateViewModel templateViewModel = new CreatorTemplateViewModel();

            //Mock
            Mock<ICreatorViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>> creatorViewModelService = new Mock<ICreatorViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>>();
            creatorViewModelService.Setup((viewModelService) => viewModelService.Create(templateViewModel));

            //SUT
            var SUT = new ClassCreatorController(creatorViewModelService.Object);
            var result = SUT.Create(templateViewModel) as ObjectResult;

            //Assert
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
        }

        /// <summary>
        /// Prueba unitaria que evalúa la respuesta cuando se no se generó bien el registro.
        /// </summary>
        [Fact]
        public void Create_CreacionFallida_BadRequest()
        {
            //Arrange
            CreatorTemplateViewModel templateViewModel = new CreatorTemplateViewModel();
            Exception ex = new Exception();
            //Mock
            Mock<ICreatorViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>> creatorViewModelService = new Mock<ICreatorViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>>();
            creatorViewModelService.Setup((viewModelService) => viewModelService.Create(templateViewModel)).Throws(new Exception(ex.Message));
            //SUT
            var SUT = new ClassCreatorController(creatorViewModelService.Object);
            var result = SUT.Create(templateViewModel) as ObjectResult;
            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }
    }
}

using EGobX.NTemplate.API.Abstractions.AbstractClasses;
using EGobX.NTemplate.Service.Exceptions;
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
    /// Las clases que se agregan en esta sección sirven para representar la herencia de la clase abstracta UpdaterController con sus clases hijas
    /// </summary>
    public class ClassUpdaterController : UpdaterController<Domain.Entities.Template, CreatorTemplateViewModel>
    {
        public ClassUpdaterController(IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel> _updaterViewModelService)
       : base(_updaterViewModelService)
        {
        }
    }
    #endregion
    public class UpdaterControllerUTest
    {
        /// <summary>
        /// Prueba unitaria que valida que se obtenga una excepción al enviar parámetros nulos como dependencias.
        /// </summary>
        [Fact]
        public void UpdaterController_ParamsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassUpdaterController(null));
        }

        #region [method: Update]
        /// <summary>
        ///  La ejecución de la prueba unitaria debe invocar exitosamente al método update de la capa viewModelService.
        /// </summary>
        [Fact]
        public void Update_InvokeViewModelService_MethodInvokedSuccessfully()
        {
            //Arrange
            CreatorTemplateViewModel templateViewModel = new CreatorTemplateViewModel();
            Guid id = new Guid("00000000-0000-0000-0000-000000000000");

            //Moq
            Mock<IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>> updaterViewModelService = new Mock<IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>>();
            updaterViewModelService.Setup((viewModelService) => viewModelService.Update(id, templateViewModel));

            //SUT
            var SUT = new ClassUpdaterController(updaterViewModelService.Object);
            SUT.Update(id, templateViewModel);

            //Assert
            updaterViewModelService.Verify((v) => v.Update(id, templateViewModel), Times.Once);
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar un estatus 400 al momento de invocar el método update de la dependencia IUpdaterViewModelService.
        /// </summary>
        [Fact]
        public void Update_ParamsNull_FailedResponse()
        {
            //Arrange
            Guid id = new Guid("00000000-0000-0000-0000-000000000000");
            var templateViewModel = new CreatorTemplateViewModel();

            //Mock
            Mock<IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>> updaterViewModelService = new Mock<IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>>();
            updaterViewModelService.Setup((viewModelService) => viewModelService.Update(id, templateViewModel)).Throws(new GettingException("Record not found."));

            //SUT
            var SUT = new ClassUpdaterController(updaterViewModelService.Object);
            var result = SUT.Update(id, templateViewModel) as ObjectResult;

            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar un estatus 200 al momento de invocar el método Update de la dependencia IUpdaterViewModelService.
        /// </summary>
        [Fact]
        public void Update_ValidParams_ResponseStatus200()
        {
            //Arrange
            CreatorTemplateViewModel templateViewModel = new CreatorTemplateViewModel();
            Guid id = new Guid("00000000-0000-0000-0000-000000000000");

            //Mock
            Mock<IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>> updaterViewModelService = new Mock<IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>>();
            updaterViewModelService.Setup((viewModelService) => viewModelService.Update(id, templateViewModel));

            //SUT
            var SUT = new ClassUpdaterController(updaterViewModelService.Object);
            var result = SUT.Update(id, templateViewModel) as ObjectResult;

            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
        #endregion

        #region[method: updateState]
        /// <summary>
        /// Prueba para validar que se devuelva una excepción de tipo BadRequest
        /// </summary>
        [Fact]
        public void UpdateState_ParamsGuidAndBoolNull_BadRequest()
        {
            //Arrange
            Guid id = new Guid("00000000-0000-0000-0000-000000000000");

            //Mock
            Mock<IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>> updaterViewModelService = new Mock<IUpdaterViewModelService<Domain.Entities.Template, CreatorTemplateViewModel>>();
            updaterViewModelService.Setup((_finderService) => _finderService.UpdateState(id, true)).Throws(new GettingException("Records no found."));

            //SUT
            var SUT = new ClassUpdaterController(updaterViewModelService.Object);

            //Assert
            Assert.IsType<BadRequestObjectResult>(SUT.UpdateState(id, true));
        }
        #endregion

    }
}

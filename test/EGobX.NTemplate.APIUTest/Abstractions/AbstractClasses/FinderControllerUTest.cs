using System;
using Xunit;
using Moq;
using EGobX.NTemplate.API.Abstractions.AbstractClasses;
using EGobX.NTemplate.ViewModel;
using EGobX.NTemplate.ViewModel.Services.Abstractions.Interfaces.Generics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using EGobX.NTemplate.Service.Exceptions;

namespace EGobX.NTemplate.APIUTest.Abstractions.AbstractClasses
{
    /// <summary>
    /// Las clases que se agregan en esta sección sirven para representar
    /// la herencia de la clase abstracta FinderController con sus clases hijas
    /// </summary>
    #region [Clase]
    public class ClassFinderController : FinderController<Domain.Entities.Template, TemplateViewModel>
    {
        public ClassFinderController(IFinderViewModelService<Domain.Entities.Template, TemplateViewModel> _finderViewModelService)
            : base(_finderViewModelService)
        {
        }
    }

    #endregion
    public class FinderControllerUTest
    {
        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar una excepción de argumento nulo al recibir null como dependencia.
        /// </summary>
        [Fact]
        public void FinderController_NullInstances_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassFinderController(null));
        }

        #region[Method: Get]
        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar un estatus 200 al momento de invocar el método Get de la dependencia IFinderViewModelService.
        /// </summary>
        [Fact]
        public void Get_InvokeViewModelService_Status200()
        {
            //Arrange
            TemplateViewModel templateViewModel = new TemplateViewModel();
            templateViewModel.Id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1");
            //Mock
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((viewModelService) => viewModelService.Get(templateViewModel.Id));
            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);
            var result = SUT.Get(templateViewModel.Id) as ObjectResult;
            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar un estatus 400 al momento de invocar el método Get de la dependencia IFinderViewModelService.
        /// </summary>
        [Fact]
        public void Get_InvokeViewModelService_BadRequest()
        {
            //Arrange
            var id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1");
            //Mock
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((viewModelService) => viewModelService.Get(id)).Throws(new GettingException("Records not found"));
            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);
            var result = SUT.Get(id) as ObjectResult;
            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe invocar exitosamente al método get de la capa viewModel.
        /// </summary>
        [Fact]
        public void Get_InvokeViewModelService_InvokeSuccessful()
        {
            //Arrange
            TemplateViewModel templateViewModel = new TemplateViewModel();
            templateViewModel.Id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1");
            //Moq
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((viewModelService) => viewModelService.Get(templateViewModel.Id));
            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);
            SUT.Get(templateViewModel.Id);
            //Assert
            finderViewModelService.Verify((v) => v.Get(templateViewModel.Id), Times.Once);
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe invocar al viewModel y retornar un templateViewModel.
        /// </summary>
        [Fact]
        public void Get_InvokeViewModelService_ReturnTemplateViewModel()
        {
            //Arrange
            TemplateViewModel templateViewModel = new TemplateViewModel();
            templateViewModel.Id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1");

            //Mock
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((viewModelService) => viewModelService.Get(templateViewModel.Id)).Returns(templateViewModel);

            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);

            //Act
            var result = SUT.Get(templateViewModel.Id) as ObjectResult;

            //Assert
            Assert.NotNull(result);
        }
        #endregion

        #region[Method: GetAll]

        /// <summary>
        /// La ejecución de la prueba unitaria debeía de retornar una lista de TemplateViewModel vacía.
        /// </summary>
        [Fact]
        public void GetAll_InvokeViewModelService_ReturnsListTemplateViewModelEmpty()
        {
            //Arrange
            List<TemplateViewModel> lstTemplate = new List<TemplateViewModel>();

            //Mock
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((_finderService) => _finderService.GetAll()).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);
            var result = SUT.GetAll() as ObjectResult;
            var viewResult = Assert.IsType<List<TemplateViewModel>>(result.Value);
            var model = Assert.IsAssignableFrom<IEnumerable<TemplateViewModel>>(viewResult);

            //Assert
            Assert.True(!model.Any());
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar una lista de TemplateViewModel.
        /// </summary>
        [Fact]
        public void GetAll_InvokeViewModelService_ReturnsListTemplateViewModel()
        {
            //Arrange
            List<TemplateViewModel> lstTemplate = new List<TemplateViewModel>() { new TemplateViewModel()
            {   Id = new Guid("4EC575AB-1649-4F0F-43BF-08D78D888A4C"),
                Name = "prueba",
                Description = "prueba",
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            } };

            //Mock
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((_finderService) => _finderService.GetAll()).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);
            var result = SUT.GetAll() as ObjectResult;
            var viewResult = Assert.IsType<List<TemplateViewModel>>(result.Value);
            var listViewModel = Assert.IsAssignableFrom<IEnumerable<TemplateViewModel>>(viewResult);

            //Assert
            Assert.True(listViewModel.Any());
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar una exception al momento de invocar el método GetAll del la dependencia IFinderViewModelService.
        /// </summary>
        [Fact]
        public void GetAll_InvokeViewModelService_Exception()
        {
            //Mock
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((_finderService) => _finderService.GetAll()).Throws(new GettingException("Records no found."));

            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);

            //Assert
            Assert.IsType<BadRequestObjectResult>(SUT.GetAll());
        }
        #endregion

        #region [Method: GetByName]

        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver un mensaje de error cuando no exista el template con el nombre solicitado.
        /// </summary>
        [Fact]
        public void GetByName_InvokeViewModelServiceNotExistsName_ReturnsGettingException()
        {
            //Mock
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((viewModelService) => viewModelService.GetByName("Prueba")).Throws(new GettingException("Records not found"));
            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);
            var result = SUT.GetByName("Prueba") as ObjectResult;
            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe invocar exitosamente al método GetByName de la capa viewModel.
        /// </summary>
        [Fact]
        public void GetByName_InvokeViewModelServiceExistsName_ReturnsListTemplate()
        {
            //Mock
            Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>> finderViewModelService = new Mock<IFinderViewModelService<Domain.Entities.Template, TemplateViewModel>>();
            finderViewModelService.Setup((viewModelService) => viewModelService.GetByName("Prueba"));
            //SUT
            var SUT = new ClassFinderController(finderViewModelService.Object);
            var result = SUT.GetByName("Prueba") as ObjectResult;
            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        #endregion
    }
}

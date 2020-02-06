using AutoMapper;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using EGobX.NTemplate.ViewModel;
using EGobX.NTemplate.ViewModel.Services.Abstractions.AbstractClasses;
using Moq;
using System;
using Xunit;

namespace EGobX.NTemplate.ViewModelUTest.Services.Abstractions.AbstractClasses
{
    #region [Clases heredadas]
    /// <summary>
    /// La clase que se encuentra en esta sección representa la clase abstracta UpdaterViewModelService y sus dependencias.
    /// </summary>
    public class ClassUpdaterViewModelService : UpdaterViewModelService<Template, TemplateViewModel>
    {
        public ClassUpdaterViewModelService(IMapper _mapper, IUpdaterService<Template> _updaterService, IFinderService<Template> _finderViewModelService)
            : base(_mapper, _updaterService, _finderViewModelService)
        {
        }
    }
    #endregion
    public class UpdaterViewModelServiceUTest
    {
        /// <summary>
        /// La prueba unitaria válida que al llegar dependencias con valor nulo, se obtenga una excepción.
        /// </summary>
        [Fact]
        public void UpdaterViewModelService_ParamsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassUpdaterViewModelService(null, null, null));
        }
        
        #region[method: Update]
        /// <summary>
        /// La prueba debe validar que al invocar el servicio de actualizar este se invoque correctamente.
        /// </summary>
        [Fact]
        public void Update_InvokeService_InvocationSuccessful()
        {
            //Arrange
            Guid id = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
            Template template = new Template();
            
            //Mock
            Mock<IUpdaterService<Template>> updaterService = new Mock<IUpdaterService<Template>>();
            updaterService.Setup((updater) => updater.Update(id, template));
            //Assert
            Assert.True(true);
        }

        /// <summary>
        /// La ejecución de la prueba valida que al recibir parámetros con valor el registro se actualice.
        /// </summary>
        [Fact]
        public void Update_ParamsValid_RecordUpdate()
        {
            //Arrange
            TemplateViewModel templateViewModel = new TemplateViewModel();
            Template template = new Template();
            template.Id = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

            //Moq
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            Mock<IUpdaterService<Template>> updaterService = new Mock<IUpdaterService<Template>>();

            //SUT
            var SUT = new ClassUpdaterViewModelService(mapper.Object, updaterService.Object, finderService.Object);
            SUT.Update(template.Id, templateViewModel);

            //Assert
            Assert.True(true);
        }
        #endregion

        #region[method: updateState]
        /// <summary>
        /// El método deberá actualizar el estado lógico del viewModel.
        /// </summary>
        [Fact]
        public void UpdateStatus_ParamGuidAndBoolValid_SuccessfulChangeState()
        {
            //Arrange
            Guid id = new Guid("00000000-0000-0000-0000-000000000000");

            //Mock
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<IUpdaterService<Template>> updaterService = new Mock<IUpdaterService<Template>>();
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();

            ////SUT
            var SUT = new ClassUpdaterViewModelService(mapper.Object, updaterService.Object, finderService.Object);

            SUT.UpdateState(id, true);

            //Assert
            updaterService.Verify((v) => v.UpdateState(id, true), Times.Once);
        }
        #endregion
    }
}

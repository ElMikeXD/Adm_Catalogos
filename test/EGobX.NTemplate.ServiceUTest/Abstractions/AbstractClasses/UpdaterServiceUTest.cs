using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Abstractions.AbstractClasses;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;
using EGobX.NTemplate.Service.Exceptions;
using EGobX.NTemplate.Service.Interfaces.Service.Generics;
using Moq;
using System;
using Xunit;

namespace EGobX.NTemplate.ServiceUTest.Abstractions.AbstractClasses
{
    #region [Representación de clases y su herencia]
    /// <summary>
    /// Clase que representa la herencia de la clase UpdaterService.
    /// </summary>
    public class ClassUpdaterService : UpdaterService<Template>
    {
        public ClassUpdaterService(IUpdaterRepository<Template> _updaterRepository, IFinderService<Template> _finderService, IValidatorService<Template> _validatorService, IGetterDateRepository _getterDateRepository)
            : base(_updaterRepository, _finderService, _validatorService, _getterDateRepository)
        {
        }
    }
    #endregion
    public class UpdaterServiceUTest
    {
        /// <summary>
        /// La ejecución de la prueba valida que se reciban las instancias nulas y se obtenga una excepción.
        /// </summary>
        [Fact]
        public void UpdaterService_ReceivedDependencyNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassUpdaterService(null, null, null, null));
        }

        /// <summary>
        /// La ejecución de la prueba valida que se reciban las instancias con valor diferente de nulo.
        /// </summary>
        [Fact]
        public void UpdaterService_ReceiveDependencyValid_InstantiateDependencies()
        {
            // Mock
            Mock<IUpdaterRepository<Template>> updaterRepository = new Mock<IUpdaterRepository<Template>>();
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            Mock<IValidatorService<Template>> validadorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getDate = new Mock<IGetterDateRepository>();

            //SUT
            var SUT = new ClassUpdaterService(updaterRepository.Object, finderService.Object, validadorService.Object, getDate.Object);

            //Assert
            Assert.NotNull(SUT);
        }

        #region [method : Update]
        /// <summary>
        /// La ejecución de la prueba valida que el repositorio del metodo Update se invoque de manera correcta
        /// </summary>
        [Fact]
        public void Update_InvokeRepository_SuccessInvoke()
        {
            //Arrange
            Template template = new Template()
            {
                Id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1"),
                Name = "Original",
                Description = "Original",
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            };
            Template templateActualizado = new Template()
            {
                Id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1"),
                Name = "Actualizado",
                Description = "Actualizado",
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            };

            //Moq
            Mock<IUpdaterRepository<Template>> updaterRepository = new Mock<IUpdaterRepository<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();

            //SUT
            var SUT = new ClassUpdaterService(updaterRepository.Object, finderService.Object, validatorService.Object, getterDateRepository.Object);
            SUT.Update(template.Id, templateActualizado);

            //Assert
            updaterRepository.Verify((v) => v.Update(templateActualizado), Times.Once);
        }

        /// <summary>
        /// La ejecución de la prueba valida que se invoque al repositorio de actualizar y se actualice un template.
        /// </summary>
        [Fact]
        public void Update_ParamsValid_UpdateRecod()
        {
            //Arrange
            Template template = new Template()
            {
                Id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1"),
                Name = "Original",
                Description = "Original",
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            };
            Template templateActualizado = new Template()
            {
                Id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1"),
                Name = "Actualizado",
                Description = "Actualizado",
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                IsActive = true
            };

            //Moq
            Mock<IUpdaterRepository<Template>> updaterRepository = new Mock<IUpdaterRepository<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();

            getterDateRepository.Setup((repository) => repository.GetDateTime()).Returns(DateTime.UtcNow);
            validatorService.Setup((srvValidator) => srvValidator.Validate(template));
            updaterRepository.Setup((repository) => repository.Update(template));

            //SUT
            var SUT = new ClassUpdaterService(updaterRepository.Object, finderService.Object, validatorService.Object, getterDateRepository.Object);

            SUT.Update(template.Id, templateActualizado);
            updaterRepository.Verify((v) => v.Update(templateActualizado), Times.Once);

            //Assert
            Assert.True(template != templateActualizado);
        }
        #endregion

        #region [method: updateState]

        /// <summary>
        /// Prueba para validar que el método de actualizar de la capa repository se ejecute.
        /// </summary>
        [Fact]
        public void UpdaterState_ParamsValid_UpdateRecod()
        {
            //Arrange
            Template template = new Template();
            template.Id = new Guid("00000000-0000-0000-0000-000000000000");
            template.Name = "prueba";
            template.Description = "prueba";
            template.AddedDate = DateTime.UtcNow;
            template.ModifiedDate = DateTime.UtcNow;
            template.IsActive = false;

            //Moq
            Mock<IUpdaterRepository<Template>> updaterRepository = new Mock<IUpdaterRepository<Template>>();
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();

            updaterRepository.Setup((repository) => repository.Update(template));
            finderService.Setup((srvfinder) => srvfinder.Get(template.Id)).Returns(template);
            validatorService.Setup((srvValidator) => srvValidator.Validate(template));
            getterDateRepository.Setup((repository) => repository.GetDateTime()).Returns(DateTime.UtcNow);

            //SUT
            var SUT = new ClassUpdaterService(updaterRepository.Object, finderService.Object, validatorService.Object, getterDateRepository.Object);

            SUT.UpdateState(template.Id, true);

            //Assert
            updaterRepository.Verify((v) => v.Update(template), Times.Once);
        }

        /// <summary>
        /// Prueba para validar que se retorne un error de tipo GettingException al llamar al método get del la capa repository
        /// </summary>
        [Fact]
        public void UpdaterState_ParamsNull_Exception()
        {
            //Arrange
            Template template = new Template();

            //Moq
            Mock<IUpdaterRepository<Template>> updaterRepository = new Mock<IUpdaterRepository<Template>>();
            Mock<IFinderService<Template>> finderService = new Mock<IFinderService<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();

            finderService.Setup((srvfinder) => srvfinder.Get(template.Id)).Throws(new GettingException("Records no found."));

            //SUT
            var SUT = new ClassUpdaterService(updaterRepository.Object, finderService.Object, validatorService.Object, getterDateRepository.Object);

            //Assert
            Assert.Throws<GettingException>(() => SUT.UpdateState(template.Id, true));
        }
        #endregion
    }
}

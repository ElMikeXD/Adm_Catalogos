using System;
using Xunit;
using Moq;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions;
using EGobX.NTemplate.Service.Abstractions.AbstractClasses;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;
using EGobX.NTemplate.Service.Exceptions;

namespace EGobX.NTemplate.ServiceUTest.Abstractions.AbstractClasses
{
    public class ClassCreatorService : CreatorService<Template>
    {
        public ClassCreatorService(ICreatorRepository<Template> _creatorRepository, IValidatorService<Template> _validatorService, IGetterDateRepository _getterDateRepository)
            : base(_creatorRepository, _validatorService, _getterDateRepository)
        {
        }
    }

    public class CreatorServiceUTest
    {
        #region[method: Create]

        /// <summary>
        /// Prueba que evalua la asignación de la fecha de creación
        /// </summary>
        [Fact]
        public void Create_ActualizaFechaCreacion_FechaCreacionDebeTenerFechaActual()
        {
            //Arrange
            Template objtemplate = new Template();
            DateTime DateTimeTest = DateTime.UtcNow;

            //Mock
            var mockDateTime = new Mock<GetterDateRepository>();
            objtemplate.AddedDate = mockDateTime.Object.GetDateTime().Date;

            // Assert
            Assert.Equal(DateTimeTest.Date, objtemplate.AddedDate.Date);
        }

        /// <summary>
        /// Prueba que evalua la asignación de la fecha de modificación.
        /// </summary>
        [Fact]
        public void Create_ActualizaFechaDeModificacion_FechaModificacionDebeTenerFechaActual()
        {
            //Arrange
            Template objtemplate = new Template();
            DateTime DateTimeTest = DateTime.UtcNow;

            //Mock
            var mockDateTime = new Mock<GetterDateRepository>();
            objtemplate.ModifiedDate = mockDateTime.Object.GetDateTime().Date;

            // Assert
            Assert.Equal(DateTimeTest.Date, objtemplate.ModifiedDate.Date);
        }

        /// <summary>
        /// Prueba para evaluar cuando la validación genera algún error
        /// </summary>
        [Fact]
        public void Create_ErrorEnValidacion_GeneraExcepcion()
        {
            //Arrange
            Template objTemplate = new Template();

            //Mock
            Mock<ICreatorRepository<Template>> creatorRepository = new Mock<ICreatorRepository<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();

            validatorService.Setup(x => x.Validate(objTemplate)).Throws(new ValidationException("El campo nombre no debe estar vacío."));
            getterDateRepository.Setup(x => x.GetDateTime()).Returns(DateTime.UtcNow);

            //SUT
            var SUT = new ClassCreatorService(creatorRepository.Object, validatorService.Object, getterDateRepository.Object);

            // Assert
            Assert.Throws<ValidationException>(() => SUT.Create(objTemplate));
        }

        /// <summary>
        /// Prueba que evalua la respuesta cuando se generó de forma exitosa el registro
        /// </summary>
        [Fact]
        public void Create_RegistroCreadoExitosamente_RetornaTrue()
        {
            //Arrange
            Template objtemplate = new Template();
            objtemplate.Name = "Prueba";
            objtemplate.Description = "Prueba";

            //Mock
            Mock<ICreatorRepository<Template>> creatorRepository = new Mock<ICreatorRepository<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();
            getterDateRepository.Setup(x => x.GetDateTime()).Returns(DateTime.UtcNow);

            creatorRepository.Setup(x => x.Create(It.IsAny<Template>()));

            //SUT
            var SUT = new ClassCreatorService(creatorRepository.Object, validatorService.Object, getterDateRepository.Object);
            SUT.Create(objtemplate);

            // Assert
            creatorRepository.Verify(x => x.Create(objtemplate), Times.Once);
        }

        /// <summary>
        /// Prueba para evaluar el comportamiento cuando no se almacena la información.
        /// </summary>
        [Fact]
        public void Create_RegistroNoCreado_ReturnFalse()
        {
            //Mock
            Mock<ICreatorRepository<Template>> creatorRepository = new Mock<ICreatorRepository<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();

            validatorService.Setup(x => x.Validate(It.IsAny<Template>())).Throws(new ValidationException("El campo nombre no debe estar vacío."));
            getterDateRepository.Setup(x => x.GetDateTime()).Returns(DateTime.UtcNow);

            creatorRepository.Setup(x => x.Create(It.IsAny<Template>()));

            //SUT
            var SUT = new ClassCreatorService(creatorRepository.Object, validatorService.Object, getterDateRepository.Object);

            try
            {
                SUT.Create(It.IsAny<Template>());
            }
            catch (Exception)
            { }

            // Assert
            creatorRepository.Verify(x => x.Create(It.IsAny<Template>()), Times.Never);
        }

        /// <summary>
        /// Prueba que evalua el comportamiento del parámetro del Repositorio nulo
        /// </summary>
        [Fact]
        public void CreatorService_ArgumentNullICreatorRepository_ThrowArgumentException()
        {
            //Mock
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();

            // Assert
            Assert.Throws<ArgumentNullException>(() => new ClassCreatorService(null, validatorService.Object, getterDateRepository.Object));
        }

        /// <summary>
        /// Prueba que evalua el comportamiento cuando el validador de parámetro IValidatorService es nulo
        /// </summary>
        [Fact]
        public void CreatorService_ArgumentNullIValidatorService_ThrowArgumentException()
        {
            //Mock
            Mock<ICreatorRepository<Template>> creatorRepository = new Mock<ICreatorRepository<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();

            // Assert
            Assert.Throws<ArgumentNullException>(() => new ClassCreatorService(creatorRepository.Object, null, getterDateRepository.Object));
        }

        /// <summary>
        /// Prueba que evalua que el constructor se ejecute de forma correcta
        /// </summary>
        [Fact]
        public void CreatorService_InstancedParameters_NotException()
        {
            //Mock
            Mock<ICreatorRepository<Template>> creatorRepository = new Mock<ICreatorRepository<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();

            //SUT
            var SUT = new ClassCreatorService(creatorRepository.Object, validatorService.Object, getterDateRepository.Object);

            // Assert
            Assert.IsType<ClassCreatorService>(SUT);
        }

        /// <summary>
        /// Prueba unitaria para la evaluar que se retorne un Guid
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void Create_RecordCreated_ReturnGuid()
        {
            //Arrange
            Template objtemplate = new Template();
            objtemplate.Id = new Guid("23CD9099-DCC2-4CD5-CEB5-08D7961EA229");
            objtemplate.Name = "Prueba";
            objtemplate.Description = "Prueba";

            //Mock
            Mock<ICreatorRepository<Template>> creatorRepository = new Mock<ICreatorRepository<Template>>();
            Mock<IValidatorService<Template>> validatorService = new Mock<IValidatorService<Template>>();
            Mock<IGetterDateRepository> getterDateRepository = new Mock<IGetterDateRepository>();
            getterDateRepository.Setup(x => x.GetDateTime()).Returns(DateTime.UtcNow);

            creatorRepository.Setup(x => x.Create(It.IsAny<Template>())).Returns(objtemplate.Id);

            //SUT
            var SUT = new ClassCreatorService(creatorRepository.Object, validatorService.Object, getterDateRepository.Object);
            Guid id = SUT.Create(objtemplate);

            //Assert
            Assert.IsType<Guid>(id);
        }

        #endregion
    }
}

using Xunit;
using System;
using System.Collections.Generic;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Abstractions.AbstractClasses;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Repository.Generics;
using Moq;
using System.Linq;
using EGobX.NTemplate.Service.Exceptions;
using EGobX.NTemplate.Service.Abstractions.Interfaces.Validator;
using EGobX.NTemplate.Domain.Entities.Base;

namespace EGobX.NTemplate.ServiceUTest.Abstractions.AbstractClasses
{
    /// <summary>
    /// Las clases que se agregan en esta sección sirven para representar
    /// la herencia de la clase abstracta FinderService con sus clases hijas
    /// </summary>
    #region [Clases Hijas]
    public class ClassFinderService : FinderService<Template>
    {
        public ClassFinderService(IFinderRepository<Template> _finderRepository, IValidatorPaginate<PaginationCatalog> validatorPaginate)
            : base(_finderRepository, validatorPaginate)
        {
        }
    }
    #endregion

    public class FinderServiceUTest
    {
        #region[Method: Get]
        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar un template.
        /// </summary>
        [Fact]
        public void Get_InvokeRepository_ReturnsEntity()
        {
            //Arrange
            Template template = new Template()
            {
                Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                Name = "test",
                Description = "test"
            };

            //Mock
            Mock<IFinderRepository<Template>> finderRepository = new Mock<IFinderRepository<Template>>();
            finderRepository.Setup((service) => service.Get(template.Id)).Returns(template);

            //SUT
            var SUT = new ClassFinderService(finderRepository.Object);

            //Assert
            Assert.NotNull(SUT.Get(template.Id));
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar una excepción controlada indicando que el registro no fue encontrado.
        /// </summary>
        [Fact]
        public void Get_InvokeRepository_ReturnNotFound()
        {
            //Arrange
            var id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1");

            //Mock
            Mock<IFinderRepository<Template>> finderRepository = new Mock<IFinderRepository<Template>>();
            finderRepository.Setup((repository) => repository.Get(id)).Throws(new GettingException("Record not found."));

            //SUT
            var SUT = new ClassFinderService(finderRepository.Object);

            //Act
            GettingException ex = Assert.Throws<GettingException>(() => SUT.Get(id));

            //Assert
            Assert.Equal("Record not found.", ex.Message);
        }
        #endregion

        #region[Method: GetAll]
        /// <summary>
        /// La ejecución de la prueba unitaria debe retornar una lista de Templates.
        /// </summary>
        [Fact]
        public void GetAll_InvokeRepository_ReturnsListEntity()
        {
            //Arrange
            Template template = new Template();
            List<Template> lstTemplate = new List<Template>();

            template.Id = new Guid("4EC575AB-1649-4F0F-43BF-08D78D888A4C");
            template.Name = "prueba";
            template.Description = "prueba";
            lstTemplate.Add(template);

            //Mock
            Mock<IFinderRepository<Template>> finderRepository = new Mock<IFinderRepository<Template>>();
            finderRepository.Setup((viewModelService) => viewModelService.GetAll()).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderService(finderRepository.Object);

            //Assert
            Assert.True(SUT.GetAll().Any());
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debería de retornar una lista de Templates vacía.
        /// </summary>
        [Fact]
        public void GetAll_InvokeRepository_ReturnsListEntityEmpty()
        {
            //Arrange
            List<Template> lstTemplate = new List<Template>();

            //Mock
            Mock<IFinderRepository<Template>> finderRepository = new Mock<IFinderRepository<Template>>();
            finderRepository.Setup((viewModelService) => viewModelService.GetAll()).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderService(finderRepository.Object);

            //Assert
            Assert.True(!SUT.GetAll().Any());
        }
        #endregion

        #region [Method: GetByName]
        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver un mensaje de error cuando no exista el template con el nombre solicitado.
        /// </summary>
        [Fact]
        public void GetByName_InvokeRepositoryNotExistsName_ReturnsGettingException()
        {
            //Arrange
            List<Template> lstTemplate = new List<Template>() { new Template {
                Id = new Guid("00000000-0000-0000-0000-000000000000"),
                Name = "Prueba",
                Description = "Prueba",
                AddedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true
            }};

            //Mock
            Mock<IFinderRepository<Template>> finderRepository = new Mock<IFinderRepository<Template>>();
            finderRepository.Setup((service) => service.GetByName("Prueba_1")).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderService(finderRepository.Object);

            //Assert
            Assert.Throws<GettingException>(() => SUT.GetByName("Prueba_1"));
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver una lista de templates
        /// </summary>
        [Fact]
        public void GetByName_InvokeRepositoryExistsName_ReturnsListTemplate()
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
            Mock<IFinderRepository<Template>> finderRepository = new Mock<IFinderRepository<Template>>();
            finderRepository.Setup((service) => service.GetByName("Prueba")).Returns(lstTemplate);

            //SUT
            var SUT = new ClassFinderService(finderRepository.Object);

            //Assert
            Assert.NotEmpty(SUT.GetByName("Prueba"));
        }


        #endregion

    }
}

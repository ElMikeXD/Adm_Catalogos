using Xunit;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServerUTest
{
    /// <summary>
    /// Las clases que se agregan en esta sección sirven para representar
    /// la herencia de la clase abstracta FinderRepository con sus clases hijas
    /// </summary>
    #region [Clases heredadas] 
    public class ClassFinderRepository : FinderRepository<Template>
    {
        public ClassFinderRepository(TemplateContext _context) : base(_context)
        {
        }
    }
    #endregion
    public class FinderRepositoryUTest
    {
        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver una excepción.
        /// </summary>
        [Fact]
        public void FinderRepository_ContextNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassFinderRepository(null));
        }

        #region [Method: Get]
        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver una entidad de tipo template
        /// </summary>
        [Fact]
        public void Get_GuidExists_ReturnsTemplate()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(databaseName: "Get_GuidExists_ReturnTemplate")
            .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                //Act
                Template _template = new Template()
                {
                    Id = new Guid("05D5FD46-263E-E211-BFBA-1040F3A7A3B1"),
                    Name = "Prueba",
                    Description = "Descripción de la entidad de prueba",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                context.Add(_template);
                context.SaveChanges();

                //SUT
                var SUT = new ClassFinderRepository(context);

                //Assert
                Assert.NotNull(SUT.Get(_template.Id));
            }
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver un objeto nulo.
        /// </summary>
        [Fact]
        public void Get_NotFoundGuid_ReturnNullObjectTemplate()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "Get_NotFoundGuid_ReturnNullObjectTemplate")
                .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                Template _template = new Template()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000")
                };

                //SUT
                var SUT = new ClassFinderRepository(context);

                //Assert
                Assert.Null(SUT.Get(_template.Id));
            }
        }
        #endregion

        #region [Method: GetAll]
        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver una lista de templates.
        /// </summary>
        [Fact]
        public void GetAll_ExecuteAsEnumerable_ReturnsIEnumerableTemplate()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "GetAll_ExecuteAsEnumerable_ReturnsIEnumerableTemplate")
                .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                //Act
                List<Template> lstTemplates = new List<Template>();

                lstTemplates.Add(new Template()
                {
                    Name = "Jorge",
                    Description = "Ingeniero de Software",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                });

                context.AddRange(lstTemplates);
                context.SaveChanges();
            }

            using (TemplateContext context = new TemplateContext(options))
            {
                //SUT
                var SUT = new ClassFinderRepository(context);

                //Assert
                Assert.NotEmpty(SUT.GetAll());
            }
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver una lista vacia de templates.
        /// </summary>
        [Fact]
        public void GetAll_ExecuteAsEnummerable_ReturnsIEnumerableTemplateEmpty()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "GetAll_ExecuteAsEnummerable_ReturnsIEnumerableTemplateEmpty")
                .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                //SUT
                var SUT = new ClassFinderRepository(context);

                //Assert
                Assert.Empty(SUT.GetAll());
            }
        }
        #endregion

        #region [Method: GetByName]
        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver una lista de entidades de tipo template.
        /// </summary>
        [Fact]
        public void GetByName_NameExists_ReturnsListTemplate()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(databaseName: "Get_NameExists_ReturnsListTemplate")
            .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                //Act
                Template _template = new Template()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Name = "Prueba",
                    Description = "Descripción de la entidad de prueba",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                context.Add(_template);
                context.SaveChanges();

                //SUT
                var SUT = new ClassFinderRepository(context);

                //Assert
                Assert.NotEmpty(SUT.GetByName("Prueba"));
            }
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debera devolver una lista vacía de entidades de tipo template.
        /// </summary>
        [Fact]
        public void GetByName_NameNotExists_ReturnEmptyListTemplate()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "Get_NameNotExists_ReturnEmptyListTemplate")
                .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                //Act
                Template _template = new Template()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000000"),
                    Name = "Prueba",
                    Description = "Descripción de la entidad de prueba",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };
                context.Add(_template);
                context.SaveChanges();

                //SUT
                var SUT = new ClassFinderRepository(context);

                //Assert
                Assert.Empty(SUT.GetByName("Prueba_1"));
            }
        }
        #endregion

    }
}

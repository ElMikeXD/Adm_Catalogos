using Xunit;
using System;
using Microsoft.EntityFrameworkCore;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServerUTest
{
    /// <summary>
    /// Las clases que se agregan en esta sección sirven para representar
    /// la herencia de la clase abstracta UpdaterRepository con sus clases hijas
    /// </summary>
    #region [Representación de la clase] 
    public class ClassUpdaterRepository : UpdaterRepository<Template>
    {
        public ClassUpdaterRepository(TemplateContext _context)
            : base(_context)
        {
        }
    }
    #endregion

    public class UpdaterRepositoryUTest
    {
        /// <summary>
        /// La ejecución de la prueba unitaria deberá retornar una excepción al recibir las instancias con valor nulo.
        /// </summary>
        [Fact]
        public void UpdaterRepository_ContextNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassUpdaterRepository(null));
        }

        /// <summary>
        /// La ejecución de la prueba unitaria deberá devolver una instancia del contexto.
        /// </summary>
        [Fact]
        public void UpdaterRepository_ContextWithValue_ContextInstance()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "UpdaterRepository_ContextWithValue_ContextInstance")
                .Options;
            using (TemplateContext context = new TemplateContext(options))
            {
                //SUT
                var SUT = new ClassUpdaterRepository(context);

                // Assert
                Assert.NotNull(SUT);
            }
        }

        #region[method : Update]
        /// <summary>
        /// La ejecución de la prueba deberá validar que no se actualice una entidad.
        /// </summary>
        [Fact]
        public void Update_SaveChangeFailed_Exception()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "Update_SaveChangeFailed_Exception")
                .Options;
            using (TemplateContext context = new TemplateContext(options))
            {
                //SUT
                var SUT = new ClassUpdaterRepository(context);
                Template template = new Template();

                SUT.Update(template);
            }

            using (TemplateContext context = new TemplateContext(options))
            {
                int registro_No_actualizado = context.SaveChanges();

                // Assert
                Assert.Equal(0, registro_No_actualizado);
            }
        }

        /// <summary>
        /// La ejecución de la prueba unitaria debe validar la actualización de una entidad.
        /// </summary>
        [Fact]
        public void Update_SaveChangesSuccess_UpdatedEntity()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "UpdateSuccess")
                .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                //Act
                Template templateExistente = new Template()
                {
                    Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Name = "Catalogo",
                    Description = "Catalogo de prueba",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true
                };

                context.Add(templateExistente);
                context.SaveChanges();

                //SUT
                ClassUpdaterRepository SUT = new ClassUpdaterRepository(context);

                var templateActualizado = SUT.Update(templateExistente);

                // Assert
                Assert.Equal(1, templateActualizado);
            }
        }
        #endregion
    }
}

using System;
using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServerUTest.Abstractions
{
    public class CreatorRepositoryUTest
    {
        /// <summary>
        /// Prueba que evalua cuando se genera una error en el contexto de almacenamiento
        /// </summary>
        [Fact]
        public void CreatorRepository_ParameterContextIsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new CreatorTemplateRepository(null));
        }

        /// <summary>
        /// Prueba unitaria para la evaluación de guardado de repositorio 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Create_RecordCreated_ReturnTrue()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "Create_EntityValid_RecordSaved")
                .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                //Act
                var SUT = new CreatorTemplateRepository(context);
                Template template = new Template();
                template.Name = "Test";

                //SUT
                SUT.Create(template);
            }

            using (TemplateContext context = new TemplateContext(options))
            {
                //Assert
                int registros_existentes = await context.Templates.CountAsync();
                Assert.Equal(1, registros_existentes);
            }
        }

        /// <summary>
        /// Prueba unitaria para la evaluar que se retorne un Guid
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void Create_RecordCreated_ReturnGuid()
        {
            //Arrange
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "Create_EntityValid_RecordSaved")
                .Options;

            using (TemplateContext context = new TemplateContext(options))
            {
                //Act
                var SUT = new CreatorTemplateRepository(context);
                Template template = new Template();
                template.Name = "Test";

                //SUT
                Guid id = SUT.Create(template);

                //Assert
                Assert.True(id != null);
            }
        }
    }
}

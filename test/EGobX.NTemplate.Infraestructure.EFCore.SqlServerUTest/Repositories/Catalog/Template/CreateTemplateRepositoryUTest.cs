using Xunit;
using System;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServerUTest
{
    public class CreateTemplateRepositoryUTest
    {
        /// <summary>
        /// La ejecución de la prueba unitaria deberá devolver una excepción de tipo argumento nulo.
        /// </summary>
        [Fact]
        public void CreatorTemplateRepository_ContextNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new CreatorTemplateRepository(null));
        }
    }
}

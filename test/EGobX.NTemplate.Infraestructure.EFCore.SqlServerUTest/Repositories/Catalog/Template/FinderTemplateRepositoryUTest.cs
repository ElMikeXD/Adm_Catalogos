using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;
using System;
using Xunit;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServerUTest.Repositories.Catalog.Template
{
    public class FinderTemplateRepositoryUTest
    {
        /// <summary>
        /// La ejecución de la prueba unitaria deberá devolver una excepción de tipo argumento nulo.
        /// </summary>
        [Fact]
        public void FinderTemplateRepository_ContextNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new FinderTemplateRepository(null));
        }
    }
}

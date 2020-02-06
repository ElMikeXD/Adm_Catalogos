using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;
using System;
using Xunit;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServerUTest.Repositories.Catalog.Template
{
    public class UpdaterTemplateRepositoryUTest
    {
        /// <summary>
        /// La prueba unitaria recibe instancias con valor nulo(El contexto) y devuelve una excepción.
        /// </summary>
        [Fact]
        public void UpdaterTemplateRepository_ContextNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdaterTemplateRepository(null));
        }
    }
}

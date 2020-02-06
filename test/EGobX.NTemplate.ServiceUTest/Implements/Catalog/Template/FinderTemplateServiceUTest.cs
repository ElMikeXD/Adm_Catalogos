using EGobX.NTemplate.Service.Implements;
using System;
using Xunit;

namespace EGobX.NTemplate.ServiceUTest.Implements.Catalog.Template
{
    public class FinderTemplateServiceUTest
    {
        /// <summary>
        /// La ejecución de la prueba válida que se obtenga una excepción de tipo Argumentos Nulos cuando las instancias sean nulas.
        /// </summary>
        [Fact]
        public void FinderTemplateService_RepositoryNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new FinderTemplateService(null));
        }
    }
}

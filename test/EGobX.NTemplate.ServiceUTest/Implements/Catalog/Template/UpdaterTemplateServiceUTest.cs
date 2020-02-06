using EGobX.NTemplate.Service.Implementss;
using System;
using Xunit;

namespace EGobX.NTemplate.ServiceUTest.Implements.Catalog.Template
{
    public class UpdaterTemplateServiceUTest
    {
        /// <summary>
        /// La ejecución de la prueba válida que se obtenga una excepción de tipo Argumentos Nulos cuando las instancias sean nulas.
        /// </summary>
        [Fact]
        public void UpdaterTemplateService_RepositoryNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdaterTemplateService(null, null, null, null));
        }
    }
}

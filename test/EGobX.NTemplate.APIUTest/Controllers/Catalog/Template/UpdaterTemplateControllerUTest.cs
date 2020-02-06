using EGobX.NTemplate.API.Controllers.Catalog.Template;
using System;
using Xunit;

namespace EGobX.NTemplate.APIUTest.Controllers.Catalog.Template
{
    public class UpdaterTemplateControllerUTest
    {
        /// <summary>
        /// La ejecución de la prueba debe retornar una excepcion de tipo argumento nulo, al recibir nulas las instancias.
        /// </summary>
        [Fact]
        public void UpdaterTemplateController_ParamsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdaterTemplateController(null));
        }
    }
}

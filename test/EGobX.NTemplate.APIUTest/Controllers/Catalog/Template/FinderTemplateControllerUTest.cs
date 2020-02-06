using EGobX.NTemplate.API.Controllers.Catalog.Template;
using System;
using Xunit;

namespace EGobX.NTemplate.APIUTest.Controllers.Catalog.Template
{
    public class FinderTemplateControllerUTest
    {
        /// <summary>
        /// La ejecución de la prueba debe retornar una excepcion de tipo argumento nulo, al recibir nulas las instancias.
        /// </summary>
        [Fact]
        public void FinderTemplateController_ParamsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new FinderTemplateController(null));
        }
    }
}

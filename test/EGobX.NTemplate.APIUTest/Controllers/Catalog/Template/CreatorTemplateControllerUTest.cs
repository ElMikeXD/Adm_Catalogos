using EGobX.NTemplate.API.Controllers;
using System;
using Xunit;

namespace EGobX.NTemplate.APIUTest.Controllers.Catalog.Template
{
    public class CreatorTemplateControllerUTest
    {
        /// <summary>
        /// La ejecución de la prueba debe retornar una excepcion de tipo argumento nulo, al recibir nulas las instancias.
        /// </summary>
        [Fact]
        public void CreatorTemplateController_ParamsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new CreatorTemplateController(null));
        }
    }
}

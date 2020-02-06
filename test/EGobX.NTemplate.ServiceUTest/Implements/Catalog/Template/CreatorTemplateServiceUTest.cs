using System;
using Xunit;
using EGobX.NTemplate.Service.Implements;

namespace EGobX.NTemplate.ServiceUTest
{
    public class CreatorTemplateServiceUTest
    {
        /// <summary>
        /// La prueba unitaria verifica que se obtenga una excepción al recibir parametros nulos.
        /// </summary>
        [Fact]
        public void CreatorTemplateService_DependencyNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new CreatorTemplateService(null, null, null));
        }
    }
}

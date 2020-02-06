using EGobX.NTemplate.ViewModel.Services;
using System;
using Xunit;

namespace EGobX.NTemplate.ViewModelUTest.Services.Implements.Catalog.Template
{
    public class CreatorTemplateViewModelServiceUTest
    {
        /// <summary>
        /// La ejecución de la prueba valida que se obtenga una excepción de tipo Argumentos nulos.
        /// </summary>
        [Fact]
        public void CreatorTemplateViewModelService_ArgumentsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new CreatorTemplateViewModelService(null, null));
        }
    }
}

using EGobX.NTemplate.ViewModel.Services;
using System;
using Xunit;

namespace EGobX.NTemplate.ViewModelUTest.Implements.Catalog.Template
{
    public class UpdaterTemplateViewModelServiceUTest
    {
        /// <summary>
        /// La ejecución de la prueba valida que se obtenga una excepción de tipo Argumentos nulos.
        /// </summary>
        [Fact]
        public void UpdaterTemplateViewModelServiceUTest_ParamsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new UpdaterTemplateViewModelService(null, null, null));
        }
    }
}

using EGobX.NTemplate.ViewModel.Services;
using System;
using Xunit;

namespace EGobX.NTemplate.ViewModelUTest.Implements.Catalog.Template
{
    public class FinderTemplateViewModelServiceUTest
    {
        /// <summary>
        /// La ejecución de la prueba valida que se obtenga una excepción de tipo Argumentos nulos.
        /// </summary>
        [Fact]
        public void FinderTemplateViewModelService_ParamsNull_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new FinderTemplateViewModelService(null, null));
        }
    }
}

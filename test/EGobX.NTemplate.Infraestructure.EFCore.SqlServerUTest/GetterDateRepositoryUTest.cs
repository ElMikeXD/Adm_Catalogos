using System;
using Moq;
using Xunit;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Abstractions;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServerUTest.Abstractions
{
    public class GetterDateRepositoryUTest
    {
        /// <summary>
        /// Metodo para validar que se regrese una fecha al llamar al método GetDateTime
        /// </summary>
        [Fact]
        public void GetAll_ExecuteAsEnummerable_ReturnsIEnumerableTemplateEmpty()
        {
            //Mock
            var mockDateTime = new Mock<GetterDateRepository>();
            DateTime DateTimeTest = DateTime.UtcNow;
            //Assert
            Assert.Equal(DateTimeTest.Date, mockDateTime.Object.GetDateTime().Date);
        }
    }
}

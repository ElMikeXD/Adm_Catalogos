using EGobX.NTemplate.Domain.Entities;
using EGobX.NTemplate.Service.Validator;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace EGobX.NTemplate.ServiceUTest.Validator
{
    public class ValidatorTemplateServiceUTest
    {
        /// <summary>
        /// La prueba unitará debe asegurar que al momento de validar una entidad no válida lanze una excepción.
        /// </summary>
        [Fact]
        public void Create_ErrorEnValidacion_GeneraExcepcion()
        {
            //Arrange
            Template objTemplate = new Template();
            objTemplate.Name = "";
            objTemplate.Description = "";

            //SUT
            var SUT = new ValidatorTemplateService();

            //Assert
            Assert.Throws<ValidationException>(() => SUT.Validate(objTemplate));
        }

        /// <summary>
        /// La prueba unitaria debe  asegurar que la entidad de tipo Template sea válida.
        /// </summary>
        [Fact]
        public void Validate_SuccessValidate_Void()
        {
            //Arrange
            Template objTemplate = new Template();
            objTemplate.Name = "prueba";
            objTemplate.Description = "prueba";

            //SUT
            var SUT = new ValidatorTemplateService();
            SUT.Validate(objTemplate);

            //Assert
            Assert.True(true);
        }

        /// <summary>
        /// La prueba unitaria debe  asegurar que el campo nombre no sea mayor a 250 caracteres.
        /// </summary>
        [Fact]
        public void Validate_ErrorEnValidacionNombreExtenso_GeneraExcepcion()
        {
            //Arrange
            Template objTemplate = new Template();
            objTemplate.Name = "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_";
            objTemplate.Description = "prueba";

            //SUT
            var SUT = new ValidatorTemplateService();

            //Assert
            Assert.Throws<ValidationException>(() => SUT.Validate(objTemplate));

        }

        /// <summary>
        /// La prueba unitaria debe  asegurar que el campo nombre no sea vacio.
        /// </summary>
        [Fact]
        public void Validate_ErrorEnValidacionNombreVacio_GeneraExcepcion()
        {
            //Arrange
            Template objTemplate = new Template();
            objTemplate.Name = "";
            objTemplate.Description = "prueba";

            //SUT
            var SUT = new ValidatorTemplateService();

            //Assert
            Assert.Throws<ValidationException>(() => SUT.Validate(objTemplate));
        }

        /// <summary>
        /// La prueba unitaria debe  asegurar que el campo descripción no supere los 500 caracteres.
        /// </summary>
        [Fact]
        public void Validate_ErrorEnValidacionDescripcionExtenso_GeneraExcepcion()
        {
            //Arrange
            Template objTemplate = new Template();
            objTemplate.Name = "prueba";
            objTemplate.Description = "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_" +
                "Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_Prueba_";

            //SUT
            var SUT = new ValidatorTemplateService();

            //Assert
            Assert.Throws<ValidationException>(() => SUT.Validate(objTemplate));
        }
    }
}

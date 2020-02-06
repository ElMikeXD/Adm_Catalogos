using System;


namespace EGobX.NTemplate.ViewModel.ViewModels.Base
{
    /// <summary>
    /// Interfaz genérica para la clase que contiene atributos de un viewModel.
    /// </summary>
    public interface ICatalogViewModel
    {
        /// <summary>
        /// Atributo de tipo Guid para asignar un identificador a un viewModel
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Atributo correspondiente a la fecha de agregación.
        /// </summary>
        DateTime AddedDate { get; set; }

        /// <summary>
        /// Atributo de tipo fecha para asignar la fecha de modificación de un viewModel.
        /// </summary>
        DateTime ModifiedDate { get; set; }

        /// <summary>
        ///Atributo para el cambio de estado lógico de un viewModel.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Atributo correspondiente al fólio.
        /// </summary>
        int Folio { get; set; }
    }
}

using System;
using EGobX.NTemplate.ViewModel.ViewModels.Base;


namespace EGobX.NTemplate.ViewModel
{
    /// <summary>
    /// Clase base que contiene los atributos genéricos de un viewModel.
    /// </summary>
    public class BaseViewModel: ICatalogViewModel
    {
        /// <summary>
        /// Atributo de tipo Guid para asignar un identificador a un viewModel
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Atributo correspondiente a la fecha de agregación.
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// Atributo de tipo fecha para asignar la fecha de modificación de un viewModel.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Atributo para el cambio de estado lógico de un viewModel.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Atributo correspondiente al fólio.
        /// </summary>
        public int Folio { get; set; }
    }
}

namespace EGobX.NTemplate.API.Extensions.Enumerators 
{
    /// <summary>
    /// Enumeradores que definen el tipo de mensaje.
    /// </summary>
	public enum MessageType 
	{
		/// <summary>
		/// Mensaje de un evento exitoso
		/// </summary>
		Sucess = 1,

		/// <summary>
		/// Mensaje informativo
		/// </summary>
		Information = 2,

		/// <summary>
		/// Mensaje de advertencia
		/// </summary>
		Warning = 3,

		/// <summary>
		/// Mensaje de tipo confirmación
		/// </summary>
		Confirm = 4,

		/// <summary>
		/// Mensaje de error
		/// </summary>
		Error = 5
	}
}
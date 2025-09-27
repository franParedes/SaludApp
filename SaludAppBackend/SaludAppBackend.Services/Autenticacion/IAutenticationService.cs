using SaludAppBackend.Models.DTOs.AutenticacionDTOs;

namespace SaludAppBackend.Services.Autenticacion
{
    public interface IAutenticationService
    {
        Task<AutenticacionResponse> VerificarCredencialesAsync(string correo, string password);
    }
}

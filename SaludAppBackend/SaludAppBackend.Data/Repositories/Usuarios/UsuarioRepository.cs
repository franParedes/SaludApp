using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Usuarios
{
    public class UsuarioRepository : GenericRepository, IUsuarioRepository
    {
        private readonly ILogger<UsuarioRepository> _logger;

        // Solo necesita el AppDbContext para pasarlo a la clase base
        public UsuarioRepository(AppDbContext context, ILogger<UsuarioRepository> logger) : base(context) 
        {
            _logger = logger;
        }

        public async Task AddUsuarioAsync(TbUsuario usuario)
        {
            await _appDbContext.TbUsuarios.AddAsync(usuario);
        }

        public async Task<int> BuscarUsuarioPorCorreo(string email)
        {
            try
            {
                var sql = "SELECT f_buscar_usuario_por_correo(@EmailParam)";
                var parameters = new { EmailParam = email };

                return await ExecuteScalarAsync<int>(sql, parameters);

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar comprobar la existencia de un usuario");
                throw;
            }
        }

        public async Task<IEnumerable<TbUsuario>> GetAllUsuariosSPAsync()
        {
            try
            {
                return await QuerySPAsync<TbUsuario>("sp_GetAllUsuarios");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar obtener todos los usuarios");
                throw;
            }
        }

        public async Task<string> GetPasswordHashPorCorreo(string correo)
        {
            try
            {
                string? hash = "";
                hash = await ExecuteScalarAsync<string>("SELECT fn_obtener_has_password(@Correo)", 
                    new { Correo = correo });

                return hash!;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error en la base de datos al intentar obtener el hash de la contraseña");
                throw;
            }
        }

        public async Task<TbUsuario?> GetUsuarioByIdSPAsync(int idUsuario)
        {
            try
            {
                var usuario = await _appDbContext.TbUsuarios
                                .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);

                if (usuario == null)
                {
                    _logger.LogWarning("No se encontró un usuario con el ID: {UsuarioID}", idUsuario);
                }
                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Error en la base de datos al intentar obtener el usuario con ID {idUsuario}");
                throw;
            }

        }
    }
}

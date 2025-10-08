using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUnitOfWork unitOfWork, ILogger<UsuarioService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<int> BuscarUsuarioPorCorreo(string correo)
        {
            _logger.LogInformation($"Consultando si el usuario con correo {correo} existe");
            var usuarioExiste = await _unitOfWork.Usuarios.BuscarUsuarioPorCorreo(correo);

            return usuarioExiste;
        }

        public async Task<TbPasswd> CrearPasswd(string passwd, TbUsuario usuario)
        {
            string passwrodHsh = BCrypt.Net.BCrypt.HashPassword(passwd);
            var nuevaContrasenya = new TbPasswd
            {
                HashPasswd = passwrodHsh,
                IdUsuarioNavigation = usuario
            };

            return await Task.FromResult(nuevaContrasenya);
        }

        public async Task<TbUsuario> CrearUsuario(UsuarioModel usuario)
        {
            var usuarioExiste = await _unitOfWork.Usuarios.BuscarUsuarioPorCorreo(usuario.Correo);

            if (usuarioExiste > 0)
                throw new InvalidOperationException($"Ya existe un usuario asociado al correo {usuario.Correo}");

            string userName = $"@{usuario.PrimerNombre!.Substring(0, 1)}{usuario.PrimerApellido}";
            var nuevoUsuario = new TbUsuario
            {
                Username = userName,
                Cedula = usuario.Cedula,
                PrimerNombre = usuario.PrimerNombre,
                SegundoNombre = usuario.SegundoNombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Correo = usuario.Correo,
                Genero = usuario.Genero,
                FechaNacimiento = usuario.FechaNacimiento,
                TipoUsuario = usuario.TipoUsuario,
                FechaCreacion = DateOnly.FromDateTime(DateTime.Now),
                FechaActualizacion = DateOnly.FromDateTime(DateTime.Now),
                Activo = 7 //Esto es que está activo
            };

            foreach (var tel in usuario.Telefonos)
            {
                nuevoUsuario.TbTelefonos.Add(
                    new TbTelefono { Telefono = tel.Telefono, Compania = tel.Compania }
                );
            }

            foreach (var dir in usuario.Direcciones)
            {
                nuevoUsuario.TbDirecciones.Add(
                    new TbDireccione
                    {
                        Departamento = dir.Departamento,
                        Municipio = dir.Municipio,
                        Barrio = dir.Barrio,
                        Direccion = dir.Direccion
                    }
                );
            }

            return nuevoUsuario;
        }
    }
}

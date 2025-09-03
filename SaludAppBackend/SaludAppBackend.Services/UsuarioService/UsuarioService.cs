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

        //public async Task<bool> RegistrarUsuarioAsync(UsuarioModel usuario)
        //{
        //    _logger.LogInformation("Intentando agregar nuevo paciente");
        //    var usuarioExiste = await _unitOfWork.Usuarios.BuscarUsuarioPorCorreo(usuario.Correo);

        //    if (usuarioExiste > 0)
        //    {
        //        throw new InvalidOperationException($"El paciente con correo {usuario.Correo} ya existe");
        //    }

        //    string userName = $"@{usuario.PrimerNombre.Substring(0, 1)}{usuario.PrimerApellido}";
        //    var nuevoUsuario = new TbUsuario
        //    {
        //        Username = userName,
        //        Cedula = usuario.Cedula,
        //        PrimerNombre = usuario.PrimerNombre,
        //        SegundoNombre = usuario.SegundoNombre,
        //        PrimerApellido = usuario.PrimerApellido,
        //        SegundoApellido = usuario.SegundoApellido,
        //        Correo = usuario.Correo,
        //        Genero = usuario.Genero,
        //        FechaNacimiento = usuario.FechaNacimiento,
        //        TipoUsuario = usuario.TipoUsuario,
        //        FechaCreacion = DateOnly.FromDateTime(DateTime.Now),
        //        FechaActualizacion = DateOnly.FromDateTime(DateTime.Now),
        //        Activo = true
        //    };

        //    await _unitOfWork.Usuarios.AddUsuarioAsync(nuevoUsuario);
        //    await _unitOfWork.CompleteAsync();

        //    _logger.LogInformation("Usuario creado");

        //    //var idUsuario = await _unitOfWork.Usuarios.BuscarUsuarioPorCorreo(usuario.Correo);

        //    //var nuevoPaciente = new TbPaciente
        //    //{
        //    //    IdUsuario = idUsuario,
        //    //    NumeroInss = paciente.NumeroInss,
        //    //    Ocupacion = paciente.Ocupacion,
        //    //    Escolaridad = paciente.Escolaridad,
        //    //    Religion = paciente.Religion,
        //    //    Edad = paciente.Edad,
        //    //    EstadoCivil = paciente.EstadoCivil,
        //    //    CantidadHermanos = paciente.CantidadHermanos
        //    //};

        //    //await _unitOfWork.Usuarios.AddPacienteAsync(nuevoPaciente);
        //    //await _unitOfWork.CompleteAsync();

        //    return true;
        //}
    }
}

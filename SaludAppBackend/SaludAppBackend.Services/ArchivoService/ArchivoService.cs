using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.UnitOfWork;
using SaludAppBackend.Models.Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Services.ArchivoService
{
    public class ArchivoService : IArchivoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ArchivoService> _logger;

        public ArchivoService(IUnitOfWork unitOfWork, ILogger<ArchivoService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<TbArchivo> CrearEntidadArchivoAsync(ArchivoBaseModel adjunto)
        {
            var base64 = Convert.ToBase64String(adjunto.BytesArchivo);
            var nuevoArchivo = new TbArchivo
            {
                NombreArchivo = adjunto.NombreArchivo,
                TipoArchivo = Path.GetExtension(adjunto.NombreArchivo).TrimStart('.'),
                TipoMime = adjunto.TipoMime,
                Base64 = base64,
                FechaSubida = DateTime.Now,
            };

            await _unitOfWork.Archivos.AddArchivoAsync(nuevoArchivo);

            return nuevoArchivo;
        }
    }
}

using Dapper;
using Microsoft.EntityFrameworkCore;
using SaludAppBackend.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Generic
{
    public abstract class GenericRepository
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly IDbConnection _connection;

        protected GenericRepository(AppDbContext context)
        {
            _appDbContext = context;

            //Obtenemos la conexión de EntityFramework para Dapper
            _connection = context.Database.GetDbConnection();
        }

        /// <summary>
        /// Ejecuta un Stored Procedure que devuelve una lista de resultados.
        /// </summary>
        protected async Task<IEnumerable<T>> QuerySPAsync<T>(string spName, object? param = null)
        {
            return await _connection.QueryAsync<T>(spName, param, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Ejecuta un Stored Procedure que devuelve un único resultado.
        /// </summary>
        protected async Task<T?> QuerySingleSPAsync<T>(string spName, object? param = null)
        {
            return await _connection.QuerySingleOrDefaultAsync<T>(spName, param, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Ejecuta un Stored Procedure que no devuelve resultados (INSERT, UPDATE, DELETE).
        /// </summary>
        protected async Task<int> ExecuteSPAsync(string spName, object? param = null)
        {
            return await _connection.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Ejecuta una función o SP que devuelve un único valor (escalar), como un conteo, un booleano o un ID.
        /// </summary>
        protected async Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, CommandType commandType = CommandType.Text)
        {
            return await _connection.ExecuteScalarAsync<T>(sql, param, commandType: commandType);
        }

        /// <summary>
        /// Ejecuta una consulta SQL directa (útil para VISTAS).
        /// </summary>
        protected async Task<IEnumerable<T>> QuerySqlAsync<T>(string sql, object? param = null)
        {
            return await _connection.QueryAsync<T>(sql, param, commandType: CommandType.Text);
        }

        /// <summary>
        /// Trae todos los datos de la tabla consultada
        /// </summary>
        protected async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            // 1. _context.Set<T>() -> Le pides a EF Core el "cajón" para el tipo T.
            // 2. .ToListAsync() -> Ejecutas la consulta "SELECT * FROM ..." de forma asíncrona.
            return await _appDbContext.Set<T>().ToListAsync();
        }
    }
}

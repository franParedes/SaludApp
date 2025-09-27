using Microsoft.Extensions.Logging;
using SaludAppBackend.Data.Models;
using SaludAppBackend.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAppBackend.Data.Repositories.Passwd
{
    public class PasswdRepository : GenericRepository, IPasswdRepository
    {
        private readonly ILogger<PasswdRepository> _logger;

        public PasswdRepository(AppDbContext context, ILogger<PasswdRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task AddPasswdAsync(TbPasswd passwd)
        {
            await _appDbContext.TbPasswds.AddAsync(passwd);
        }
    }
}

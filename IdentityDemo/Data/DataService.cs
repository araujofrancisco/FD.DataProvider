using IdentityDemo.Data;
using FD.SampleData.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityDemo
{
    public interface IDataService
    {
        Task<IEnumerable<DbContextEntity>> GetAllQueries();
    }

    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly ApplicationDbContext _context;

        public DataService(ILogger<DataService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<DbContextEntity>> GetAllQueries()
        {
            return await Task.Run(() => _context.GetAllEntityQueries());
        }
    }
}

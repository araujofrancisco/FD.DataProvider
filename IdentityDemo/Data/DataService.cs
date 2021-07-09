using IdentityDemo.Data;
using FD.SampleData.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

namespace IdentityDemo
{
    public interface IDataService
    {
        Task<IEnumerable<DbContextEntity>> GetAllQueries();
        Task<DataTable> Command(string query);
    }

    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly DbConnectionRestricted _connectionRestricted;

        public DataService(ILogger<DataService> logger, ApplicationDbContext context, DbConnectionRestricted connectionRestricted)
        {
            _logger = logger;
            _context = context;
            _connectionRestricted = connectionRestricted;
        }

        public async Task<IEnumerable<DbContextEntity>> GetAllQueries()
        {
            return await Task.Run(() => _context.GetAllEntityQueries());
        }

        public async Task<DataTable> Command(string query)
        {
            var cmd = _connectionRestricted.CreateCommand();
            cmd.CommandText = query;
            var result = await cmd.ExecuteReaderAsync();
            var dt = new DataTable();
            dt.Load(result);

            return dt;
        }
    }
}

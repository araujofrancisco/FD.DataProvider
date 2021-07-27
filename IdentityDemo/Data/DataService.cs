using IdentityDemo.Data;
using FD.SampleData.Data;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using FD.SampleData.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo
{
    public interface IDataService
    {
        Task<Dictionary<DbContext, IEnumerable<DbContextEntity>>> GetAllQueries();
        Task<DataTable> Command(string query);
    }

    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly WeatherForecastDbContext _weather_context;
        private readonly DbConnectionRestricted _connectionRestricted;

        public DataService(ILogger<DataService> logger, 
            ApplicationDbContext context, DbConnectionRestricted connectionRestricted, 
            WeatherForecastDbContext weather_context)
        {
            _logger = logger;
            _context = context;
            _connectionRestricted = connectionRestricted;
            _weather_context = weather_context;
        }

        public async Task<Dictionary<DbContext, IEnumerable<DbContextEntity>>> GetAllQueries()
        {
            return new Dictionary<DbContext, IEnumerable<DbContextEntity>>
            {
                { _context, await Task.Run(() => _context.GetAllEntityQueries()) },
                { _weather_context, await Task.Run(() => _weather_context.GetAllEntityQueries()) }
            };
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

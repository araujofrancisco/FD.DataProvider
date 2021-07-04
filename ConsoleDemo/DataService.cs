using FD.Blazor.Core;
using FD.SampleData.Contexts;
using FD.SampleData.Data;
using FD.SampleData.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using FD.SampleData.Models.Users;

namespace ConsoleDemo
{
    public interface IDataService
    {
        Task<IEnumerable<DbContextEntity>> GetAllQueries();
        Task<List<User>> GetUsersAsync();
        Task<List<Role>> GetRolesAsync();
    }

    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly UserDbContext _context;
        private const int seedSize = 1000;

        public DataService(ILogger<DataService> logger, UserDbContext context)
        {
            _logger = logger;
            _context = context;

            DbInitializer<UserDbContext>.Initialize(context, seedSize);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await new UserService(_context).GetUsersAsync(null, "UserName", SortDirection.Ascending, 0, 100);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await new UserService(_context).GetRolesAsync(null, "Name", SortDirection.Ascending, 0, 10);
        }

        public Task<IEnumerable<DbContextEntity>> GetAllQueries() =>
            Task.FromResult(_context.GetAllEntityQueries());
    }
}

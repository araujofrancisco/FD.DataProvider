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
        Task<IEnumerable<MultiContext>> GetAllQueries();
        Task<List<User>> GetUsersAsync();
        Task<List<Role>> GetRolesAsync();
    }

    public class MultiContext
    {
        public BaseDbContext Context { get; set; }
        public IEnumerable<DbContextEntity> Entities { get; set; }
    }

    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly UserDbContext _contextUser;
        private readonly WeatherForecastDbContext _contextForecast;
        private const int seedSize = 1000;

        public DataService(ILogger<DataService> logger, UserDbContext contextUser, WeatherForecastDbContext contextForecast)
        {
            _logger = logger;
            _contextUser = contextUser;
            _contextForecast = contextForecast;

            DbInitializer<UserDbContext>.Initialize(contextUser, seedSize);
            DbInitializer<WeatherForecastDbContext>.Initialize(contextForecast, seedSize);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await new UserService(_contextUser).GetUsersAsync(null, "UserName", SortDirection.Ascending, 0, 100);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await new UserService(_contextUser).GetRolesAsync(null, "Name", SortDirection.Ascending, 0, 10);
        }

        public async Task<IEnumerable<MultiContext>> GetAllQueries() =>
            await Task.Run(() => new List<MultiContext>()
            {
                new MultiContext { Context = _contextUser, Entities = _contextUser.GetAllEntityQueries() },
                new MultiContext { Context = _contextForecast, Entities = _contextForecast.GetAllEntityQueries() }
            });

    }
}

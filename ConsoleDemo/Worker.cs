using FD.SampleData.Contexts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDataService _dataService;
        private readonly IHostApplicationLifetime _applicationLifetime;

        private static bool _execute = true;

        private readonly EasyConsole.Menu menu = new();
        private UserDbContext _contextUser;
        private WeatherForecastDbContext _contextForecast;

        public Worker(ILogger<Worker> logger, 
            UserDbContext contextUser, WeatherForecastDbContext contextForecast,
            IDataService dataService, IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;

            _contextUser = contextUser;
            _contextForecast = contextForecast;

            _dataService = dataService;
            _applicationLifetime = applicationLifetime;

            Initialize();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // display's menu the first time and wait for user action
                // menu options will run an action and reset the flag to redisplay the menu
                if (_execute)
                {
                    _execute = false;
                    menu.Display();
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        private void Initialize()
        {
            var _superset = Task.Run(async () => await _dataService.GetAllQueries()).Result;

            // list while add a menu item for each model in every dbcontext we got in registers and setup in dataservice
            foreach (var _set in _superset)
                foreach (var _item in _set.Entities)
                    menu.Add(_item.Name, () => { _item.Entity.ToList().PrintTable(_item.Name); _execute = true; });
            menu.Add("Exit", () => _applicationLifetime.StopApplication());
        }
    }
}

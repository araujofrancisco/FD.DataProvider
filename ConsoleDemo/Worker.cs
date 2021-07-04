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
        private UserDbContext _context;

        public Worker(ILogger<Worker> logger, UserDbContext context, IDataService dataService, IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;
            _context = context;
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
            var entities = Task.Run(async () => await _dataService.GetAllQueries()).Result;

            foreach (var item in entities)
                menu.Add(item.Name, () => { item.Entity.ToList().PrintTable(item.Name); _execute = true; });
            menu.Add("Exit", () => _applicationLifetime.StopApplication());
        }
    }
}

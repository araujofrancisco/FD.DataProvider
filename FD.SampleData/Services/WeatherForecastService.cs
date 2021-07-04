using FD.Blazor.Core;
using FD.SampleData.Contexts;
using FD.SampleData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FD.SampleData.Services
{
    public class WeatherForecastService
    {

        private WeatherForecastDbContext _context;

        // Instantiate a Singleton of the Semaphore with a value of 1. This means that only 1 thread can be granted access at a time
        private static SemaphoreSlim semForecast = new(1, 1);

        public WeatherForecastService(WeatherForecastDbContext context)
        {
            _context = context;
        }

        public async Task<List<WeatherForecast>> GetForecastAsync(Expression<Func<WeatherForecast, bool>>? filters,
            string sortColumn, SortDirection sortDirection, int startIndex, int numberOfRecords)
        {
            List<WeatherForecast> weatherForecasts = null;

            // Asynchronously wait to enter the Semaphore. If no-one has been granted access to the Semaphore, code execution will proceed,
            // otherwise this thread waits here until the semaphore is released
            await semForecast.WaitAsync();
            try
            {
                // does the join with tables referrenced and apply filters
                weatherForecasts = await _context.WeatherForecasts
                .AsNoTracking()
                .IfThenElse(
                    () => (filters == null),
                    e => e,
                    e => e.Where(filters)
                )
                .IfThenElse(
                    () => (sortDirection == SortDirection.Ascending),
                    e => (sortColumn == null) ? e : e.OrderBy(sortColumn),
                    e => (sortColumn == null) ? e : e.OrderByDescending(sortColumn)
                )
                .Skip(startIndex)
                .Take(numberOfRecords)
                .ToListAsync();
            }
            finally
            {
                // When the task is ready, release the semaphore.It is vital to ALWAYS release the semaphore when we are ready, or else we will end up
                // with a Semaphore that is forever locked. This is why it is important to do the Release within a try...finally clause; program execution
                // may crash or take a different path, this way you are guaranteed execution   
                semForecast.Release();
            }
            return weatherForecasts;
        }
    }
}

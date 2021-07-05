using FD.Blazor.Core;
using FD.SampleData.Contexts;
using FD.SampleData.Models.Weather;
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

        /// <summary>
        /// Returns report types that match filters and sorted by column and direction indicated. This method is compatible with virtualize component
        /// so allows to fetch only a portion of total records.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortDirection"></param>
        /// <param name="startIndex"></param>
        /// <param name="numberOfRecords"></param>
        /// <returns></returns>
        public async Task<List<ReportType>> GetReportTypes(Expression<Func<ReportType, bool>>? filters,
            string sortColumn, SortDirection sortDirection, int startIndex, int numberOfRecords)
        {
            return await _context.ReportTypes
                .AsNoTracking()
                .Include(w => w.WeatherForecasts)
                .Include(f => f.ForecastReportTypes)
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

        /// <summary>
        /// Returns forecast count for records that match filters. This method can be used to determine the total number
        /// of forecasts for virtualize.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<int> GetForecastCountAsync(Expression<Func<WeatherForecast, bool>>? filters)
        {
            int retVal;

            await semForecast.WaitAsync();
            try
            {
                retVal = await _context.WeatherForecasts
                    .AsNoTracking()
                    .Include(r => r.ReportTypes)
                    .Include(f => f.ForecastReportTypes)
                    .IfThenElse(
                        () => (filters == null),
                        e => e,
                        e => e.Where(filters)
                    )
                    .CountAsync();
            }
            finally
            {
                semForecast.Release();
            }

            return retVal;
        }

        /// <summary>
        /// Returns user count for users that match filters. This method can be used to determine the total number
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortDirection"></param>
        /// <param name="startIndex"></param>
        /// <param name="numberOfRecords"></param>
        /// <returns></returns>
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
                .Include(r => r.ReportTypes)
                .Include(f => f.ForecastReportTypes)
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

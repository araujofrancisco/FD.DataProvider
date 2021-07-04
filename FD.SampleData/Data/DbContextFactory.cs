using FD.SampleData.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace FD.SampleData.Data
{
    public class DbContextFactory<TDbContext> : IDisposable, Interfaces.IDbContextFactory<TDbContext>
        where TDbContext : DbContext, IDbContextData, new()
    {
        private DbConnection _connection;
        private bool _disposed = false;

        /// <summary>
        /// Creates database options using sqlite.
        /// </summary>
        /// <returns></returns>
        private DbContextOptions<TDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<TDbContext>()
                .UseSqlite(_connection).Options;
        }

        /// <summary>
        /// Returns database context, creates a new one if none exists. The database connection is a sqlite in memory and it will persists in memory 
        /// it gets manually disposed.
        /// </summary>
        /// <returns></returns>
        public TDbContext CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using var context = Activator.CreateInstance(typeof(TDbContext), options) as TDbContext;
                context.Database.EnsureCreated();
            }

            return Activator.CreateInstance(typeof(TDbContext), CreateOptions()) as TDbContext;
        }

        /// <summary>
        /// Dispose connection and informs garbage collector that everything has been cleared.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Close the in-memory database and release the connection.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            // Execute if resources have not already been disposed.
            if (!_disposed)
            {
                // If the call is from Dispose, free managed resources.
                if (disposing)
                {

                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
            }
            _disposed = true;
        }
    }
}

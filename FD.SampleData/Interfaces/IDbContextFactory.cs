using FD.SampleData.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace FD.SampleData.Interfaces
{
    public interface IDbContextFactory<TDbContext>
        where TDbContext : DbContext, IDisposable, new()
    {
        DbConnectionRestricted ConnectionRestricted { get; }
        TDbContext CreateContext();
        void Dispose();
    }
}

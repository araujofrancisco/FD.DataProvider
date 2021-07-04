using Microsoft.EntityFrameworkCore;
using System;

namespace FD.SampleData.Interfaces
{
    public interface IDbContextFactory<TDbContext>
        where TDbContext : DbContext, IDisposable, new()
    {
        TDbContext CreateContext();
        void Dispose();
    }
}

using FD.SampleData.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FD.SampleData.Data
{
    public class DbInitializer<TDbContext>
        where TDbContext : DbContext, IDbContextData, new()
    {
        public static Task Initialize(TDbContext context, int? seedSize) =>
            Task.FromResult(context.Seed(seedSize));

        public static Task Initialize(IServiceScope serviceScope, TDbContext context, int? seedSize) =>
            Task.FromResult(context.Seed(serviceScope, seedSize));
    }
}

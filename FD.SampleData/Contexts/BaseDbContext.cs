using FD.SampleData.Data;
using FD.SampleData.Extensions;
using FD.SampleData.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FD.SampleData.Contexts
{
    public abstract class BaseDbContext : DbContext, IDbContextData
    {
        public BaseDbContext()
        {
            
        }

        public BaseDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(@"DataSource=:memory:");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // this allow the user to implement its seeding that will trigger on method execution
            modelBuilder.Seed(Seed);
        }

        public virtual IEnumerable<DbContextEntity> GetAllEntityQueries() => 
            this.GetDbContextEntityQueries();

        public virtual Task Seed(ModelBuilder builder) =>
            Task.CompletedTask;

        public virtual Task Seed(int? seedSize) =>
            Task.CompletedTask;
        public virtual Task Seed(IServiceScope serviceScope, int? seedSize) =>
            Task.CompletedTask;
    }
}

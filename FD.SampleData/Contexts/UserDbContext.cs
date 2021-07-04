using FD.SampleData.Data;
using FD.SampleData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
//using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FD.SampleData.Contexts
{
    public class UserDbContext : BaseDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        //public readonly ILoggerFactory MyLoggerFactory;

        public UserDbContext()
        {

        }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
#if DEBUG
            Debug.WriteLine($"{ContextId} context created.");
            // we can enable factory logger if is required to check the sql statements
            //MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
#endif
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set model relations
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRole>(
                    j => j
                        .HasOne(ur => ur.Role)
                        .WithMany(t => t.UserRoles)
                        .HasForeignKey(ur => ur.RoleId),
                    j => j
                        .HasOne(ur => ur.User)
                        .WithMany(t => t.UserRoles)
                        .HasForeignKey(ur => ur.UserId),
                    j =>
                    {
                        j.HasKey(t => new { t.UserId, t.RoleId });
                    });
        }

        public override async Task Seed(int? SeedSize)
        {
            // generates roles and save then to get the database generate ids
            List<Role> roles = await UserGenerator.GenerateRoles();
            await AddRangeAsync(roles);
            await SaveChangesAsync();

            List<User> users = await UserGenerator.GenerateUsers(roles, SeedSize);
            await AddRangeAsync(users);
            await SaveChangesAsync();
        }
    }
}
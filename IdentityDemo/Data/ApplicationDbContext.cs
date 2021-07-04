using FD.SampleData.Data;
using FD.SampleData.Extensions;
using FD.SampleData.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IdentityDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext, IDbContextData
    {
        public readonly ILoggerFactory MyLoggerFactory;

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
#if DEBUG
            Debug.WriteLine($"{ContextId} context created.");
            MyLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("System", LogLevel.Debug)
                    .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Information)
                    .AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Trace)
                    .AddConsole();
            });
#endif
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed(Seed);
        }

        public async Task Seed(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            });
            modelBuilder.Entity<IdentityUser>().HasData(new List<IdentityUser>
            {
                new IdentityUser {
                    Id = "1",
                    UserName = "sysadmin@mydomain.com",
                    NormalizedUserName = "SYSADMIN@MYDOMAIN.COM",
                    NormalizedEmail = "SYSADMIN@MYDOMAIN.COM",
                    PasswordHash = hasher.HashPassword(null, "123456")
                }
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId ="1"
                }
            });
            await Task.CompletedTask;
        }

        public IEnumerable<DbContextEntity> GetAllEntityQueries() =>
            this.GetDbContextEntityQueries();

        public async Task Seed(IServiceScope serviceScope, int? SeedSize)
        {
            //using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            // For sample purposes seed both with the same password.
            // Password is set with the following:
            // dotnet user-secrets set SeedUserPW <pw>
            // The admin user can do anything
            var pwd = "123456";
            var rng = new Random();
            for (var index = 1; index < 5; index++)
                await EnsureUser(serviceScope, pwd, $"user{index}@{Generics.EmailProvider[rng.Next(Generics.EmailProvider.Length)]}");
        }

        private static async Task<string> EnsureUser(IServiceScope serviceScope,
                                                    string pwd, string UserName)
        {
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true,
                    Email = UserName
                };
                await userManager.CreateAsync(user, pwd);
            }

            if (user == null)
                throw new Exception("The password is probably not strong enough!");

            return user.Id;
        }

        public Task Seed(int? seedSize)
        {
            throw new NotImplementedException();
        }
    }
}

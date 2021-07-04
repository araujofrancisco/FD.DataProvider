﻿using FD.SampleData.Data;
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

        /// <summary>
        /// Demonstrates modelbuilder seeder creating an admin user and a couple roles.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public async Task Seed(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            // creates admin and user roles
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

            // admin demo user
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

            // set role for our admin user
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

        /// <summary>
        /// Returns all the entities that can be query in dbcontext.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DbContextEntity> GetAllEntityQueries() =>
            this.GetDbContextEntityQueries();

        /// <summary>
        /// Generates random users. This gets executed just after host started all the services.
        /// </summary>
        /// <param name="serviceScope"></param>
        /// <param name="SeedSize"></param>
        /// <returns></returns>
        public async Task Seed(IServiceScope serviceScope, int? seedSize)
        {
            // For sample purposes seed both with the same password.
            // Password is set with the following:
            // dotnet user-secrets set SeedUserPW <pw>
            // The admin user can do anything
            var pwd = "123456";
            var rng = new Random();
            for (var index = 1; index < seedSize; index++)
                await EnsureUser(serviceScope, pwd, 
                    UserGenerator.GenerateEmail(rng, UserGenerator.GenerateLastName(rng)), 
                    UserGenerator.GeneratePhone(rng));
        }

        /// <summary>
        /// Check if an user exists, if not gets it created.
        /// </summary>
        /// <param name="serviceScope"></param>
        /// <param name="pwd"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        private static async Task<string> EnsureUser(IServiceScope serviceScope,
                                                    string pwd, string UserName, string PhoneNumber)
        {
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true,
                    Email = UserName,
                    PhoneNumber = PhoneNumber
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

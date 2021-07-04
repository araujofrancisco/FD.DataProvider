using FD.SampleData.Data;
using FD.SampleData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FD.SampleData.Contexts
{
    public class UserDbContext : BaseDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        //public UserDbContext()
        //{
        //}
        //public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        //{
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
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

        /// <summary>
        /// Seed roles and users using UserGenerator.
        /// </summary>
        /// <param name="seedSize"></param>
        /// <returns></returns>
        public override async Task Seed(int? seedSize)
        {
            // generates roles and save then to get the database generate ids
            List<Role> roles = await UserGenerator.GenerateRoles();
            await AddRangeAsync(roles);
            await SaveChangesAsync();

            List<User> users = await UserGenerator.GenerateUsers(roles, seedSize);
            await AddRangeAsync(users);
            await SaveChangesAsync();
        }
    }
}
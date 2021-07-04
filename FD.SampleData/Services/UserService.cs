using FD.Blazor.Core;
using FD.SampleData.Contexts;
using FD.SampleData.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FD.SampleData.Services
{
    public class UserService
    {
        private UserDbContext _context;

        // Instantiate a Singleton of the Semaphore with a value of 1. This means that only 1 thread can be granted access at a time
        private static SemaphoreSlim semUsers = new(1, 1);

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns roles that match filters and sorted by column and direction indicated. This method is compatible with virtualize component
        /// so allows to fetch only a portion of total records.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortDirection"></param>
        /// <param name="startIndex"></param>
        /// <param name="numberOfRecords"></param>
        /// <returns></returns>
        public async Task<List<Role>> GetRolesAsync(Expression<Func<Role, bool>>? filters,
            string sortColumn, SortDirection sortDirection, int startIndex, int numberOfRecords)
        {
            return await _context.Roles
                .AsNoTracking()
                .Include(u => u.Users)
                .Include(ur => ur.UserRoles)
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
        /// Returns user count for records that match filters. This method can be used to determine the total number
        /// of users for virtualize.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<int> GetUsersCountAsync(Expression<Func<User, bool>>? filters)
        {
            int retVal;

            await semUsers.WaitAsync();
            try
            {
                retVal = await _context.Users
                    .AsNoTracking()
                    .Include(r => r.Roles)
                    .Include(ur => ur.UserRoles)
                    .IfThenElse(
                        () => (filters == null),
                        e => e,
                        e => e.Where(filters)
                    )
                    .CountAsync();
            }
            finally
            {
                semUsers.Release();
            }

            return retVal;
        }

        /// <summary>
        /// Returns users that match filters and sorted by column and direction indicated. This method is compatible with virtualize component
        /// so allows to fetch only a portion of total records.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortDirection"></param>
        /// <param name="startIndex"></param>
        /// <param name="numberOfRecords"></param>
        /// <returns></returns>
        public async Task<List<User>> GetUsersAsync(Expression<Func<User, bool>>? filters,
            string sortColumn, SortDirection sortDirection, int startIndex, int numberOfRecords)
        {
            List<User> users = null;

            // Asynchronously wait to enter the Semaphore. If no-one has been granted access to the Semaphore, code execution will proceed,
            // otherwise this thread waits here until the semaphore is released
            await semUsers.WaitAsync();
            try
            {
                // does the join with tables referrenced and apply filters
                users = await _context.Users
                    .AsNoTracking()
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
                semUsers.Release();
            }
            return users;
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task EditUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task SetNewPassword(User user, string password)
        {
            //TODO: implement password hashing
            user.PasswordHash = password;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> SignIn(User user, bool enabled)
        {
            var _user = await _context.Users
                .Where(u => u.Id == user.Id)
                .FirstAsync();
            _user.IsEnabled = enabled;

            await _context.SaveChangesAsync();

            return _user;
        }
    }
}

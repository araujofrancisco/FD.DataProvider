using FD.Blazor.Core;
using FD.SampleData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FD.SampleData.Data.Generators
{
    public static class UserGenerator
    {
        /// <summary>
        /// Generates a list of random roles.
        /// </summary>
        /// <returns></returns>
        public static Task<List<Role>> GenerateRoles()
        {
            List<Role> roles = Generics.Roles.Select(r => new Role { Name = r }).ToList();
            return Task.FromResult(roles);
        }

        /// <summary>
        /// Generates a list of random unique users, using UserName as a key.
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="SeedSize"></param>
        /// <returns></returns>
        public static Task<List<User>> GenerateUsers(List<Role> roles, int? SeedSize = 50)
        {
            var rng = new Random();

            List<User> users = Enumerable.Range(1, (int)SeedSize).Select(index => new User
            {
                UserName = DataGenerator.GenerateUserName(rng),
                Email = DataGenerator.GenerateEmail(rng),
                MobileNbr = DataGenerator.GeneratePhone(rng),
                IsEnabled = (rng.Next(100) % 2) != 0,
                Roles = roles.Where(r => r.Name.Length * 10 > rng.Next(999) || r.Name.Length * 10 < rng.Next(100)).ToList()
            })
                .DistinctBy(u => u.UserName)
                .ToList();

            // updates first and last names
            users.ForEach(u => { string[] names = u.UserName.Split("."); u.LastName = names[0]; u.FirstName = names[1]; });

            return Task.FromResult(users);
        }
    }
}

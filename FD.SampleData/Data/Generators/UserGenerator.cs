using FD.Blazor.Core;
using FD.SampleData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FD.SampleData.Data
{
    public static class UserGenerator
    {
        /// <summary>
        /// Generates a random email address.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static string GenerateEmail(Random? random, string? prefix = "user")
        {
            var rng = random ?? new Random();
            return $"{prefix}{rng.Next(10000, 99999)}@{Generics.EmailProvider[rng.Next(Generics.EmailProvider.Length)]}";
        }

        /// <summary>
        /// Generates a random phone number.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static string GeneratePhone(Random? random)
        {
            var rng = random ?? new Random();
            return $"+{rng.Next(1, 9)}{rng.Next(100, 999)}{rng.Next(100, 999)}{rng.Next(1000, 9999)}";
        }

        /// <summary>
        /// Generates a random last name.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static string GenerateLastName(Random? random)
        {
            var rng = random ?? new Random();
            return $"{Generics.LastNames[rng.Next(Generics.LastNames.Length)]}";
        }

        /// <summary>
        /// Generates a random first name.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static string GenerateFirstName(Random? random)
        {
            var rng = random ?? new Random();
            return $"{Generics.FirstNames[rng.Next(Generics.FirstNames.Length)]}";
        }

        /// <summary>
        /// Generates a random user name.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static string GenerateUserName(Random? random)
        {
            var rng = random ?? new Random();
            return $"{GenerateLastName(rng)}.{GenerateFirstName(rng)}";
        }

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
                UserName = GenerateUserName(rng),
                Email = GenerateEmail(rng),
                MobileNbr = GeneratePhone(rng),
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

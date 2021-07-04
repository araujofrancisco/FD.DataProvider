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
        public static Task<List<Role>> GenerateRoles()
        {
            List<Role> roles = Generics.Roles.Select(r => new Role { Name = r }).ToList();
            return Task.FromResult(roles);
        }

        public static Task<List<User>> GenerateUsers(List<Role> roles, int? SeedSize = 50)
        {
            var rng = new Random();

            List<User> users = Enumerable.Range(1, (int)SeedSize).Select(index => new User
            {
                UserName = $"{Generics.LastNames[rng.Next(Generics.LastNames.Length)]}.{Generics.FirstNames[rng.Next(Generics.FirstNames.Length)]}",
                Email = $"user{rng.Next(10000, 99999)}@{Generics.EmailProvider[rng.Next(Generics.EmailProvider.Length)]}",
                MobileNbr = $"+{rng.Next(1, 9)}{rng.Next(100, 999)}{rng.Next(100, 999)}{rng.Next(1000, 9999)}",
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

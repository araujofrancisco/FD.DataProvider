using System;

namespace FD.SampleData.Data.Generators
{
    public static class DataGenerator
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
    }
}

using FD.SampleData.Models.Individual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FD.SampleData.Data.Generators
{
    public static class IndividualGenerator
    {
        public static Task<List<Address>> GenerateAddresses(int? SeedSize = 50)
        {
            var rng = new Random();

            List<Address> addresses = Enumerable.Range(1, (int)SeedSize).Select(index => new Address
            {
                //AddressID = ,
                AddressLine1 = Generics.Addresses[rng.Next(Generics.Addresses.Length)],
                AddressLine2 = null,
                City = Generics.Cities[rng.Next(Generics.Cities.Length)],
                //StateProvinceID = ,
                PostalCode = rng.Next(10000, 99999).ToString(),
                ModifiedDate = DateTime.Today.Subtract(TimeSpan.FromDays(rng.Next(0, 100)))
            })
                .ToList();

            return Task.FromResult(addresses);
        }

        public static Task<List<Person>> GenerateIndividuals(int? SeedSize = 50)
        {
            var rng = new Random();

            List<Person> individuals = Enumerable.Range(1, (int)SeedSize).Select(index => new Person
            {
                //BusinessEntityID = ,
                PersonType = Generics.PersonTypes[rng.Next(Generics.PersonTypes.Length)],
                NameStyle = false,
                Title = Generics.PersonTitles[rng.Next(Generics.PersonTitles.Length)],
                FirstName = DataGenerator.GenerateFirstName(rng),
                MiddleName = DataGenerator.GenerateFirstName(rng).Substring(0,1),
                LastName = DataGenerator.GenerateLastName(rng),
                Suffix = rng.Next(100) > 90 ? Generics.PersonSuffix[rng.Next(Generics.PersonSuffix.Length)] : null,
                EmailPromotion = rng.Next(2),
                AdditionalContactInfo = null,
                Demographics = null,
                ModifiedDate = DateTime.Today.Subtract(TimeSpan.FromDays(rng.Next(0, 100)))
            })
                .ToList();

            return Task.FromResult(individuals);

        }
    }
}

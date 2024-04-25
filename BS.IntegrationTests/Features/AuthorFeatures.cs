using Bogus;
using BS.Contracts.ApiDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.EndToEnd.Features
{
    internal class AuthorFeatures
    {
        public static AuthorApiDto GetItem()
        {
            return AuthorFeatures.GetItems(1).Single();
        }

        public static List<AuthorApiDto> GetItems(int amount = 1)
        {
            return new Faker<AuthorApiDto>()
               .RuleFor(u => u.Name, f => f.Person.FirstName)
               .RuleFor(u => u.Surname, f => f.Person.LastName)
               .Generate(amount);
        }
    }
}

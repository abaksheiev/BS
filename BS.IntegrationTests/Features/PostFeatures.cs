using Bogus;
using BS.Contracts.ApiDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.EndToEnd.Features
{
    internal class PostFeatures
    {
        public static PostApiDto GetItem()
        {
            return PostFeatures.GetItems(1).Single();
        }

        public static List<PostApiDto> GetItems(int amount = 1)
        {
            return new Faker<PostApiDto>()
               .RuleFor(u => u.Title, f => f.Lorem.Sentences(1))
               .RuleFor(u => u.Description, f => f.Lorem.Sentences(5))
               .RuleFor(u => u.Content, f => f.Lorem.Sentences(7))
               .Generate(amount);
        }
    }
}

using System;
using Bogus;
using sipsa.Domain.Users;

namespace sipsa.DomainTest._Builders
{
    public class UserBuilder
    {
        protected string Name;
        protected string Email;
        protected string Password;
        protected string Permission;

        public static UserBuilder New()
        {
            var faker = new Faker();

            return new UserBuilder
            {
                Name = faker.Person.FullName,
                Email = faker.Person.Email,
                Password = faker.Random.AlphaNumeric(10),
                Permission = UserPermission.ADMINISTRATOR
            };
        }

        public UserBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public User Build()
        {
            return new User(Name, Email, Password, Permission);
        }
    }
}
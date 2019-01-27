using System.ComponentModel;
using FluentValidation.Results;
using sipsa.Domain._Base;

namespace sipsa.Domain.Users
{
    public class User
    {
        [DisplayName("Nome")]
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Permission { get; private set; }

        public User(string name, string email, string password, string permission)
        {
            Name = name;
            Email = email;
            Password = password;
            Permission = permission;

            Validate();
        }

        private void Validate()
        {
            var validator = new UserValidator();
            ValidationResult results = validator.Validate(this);

            if (!results.IsValid)
                throw new DomainException(results.Errors);
        }
    }
}
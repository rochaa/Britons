using System;
using ExpectedObjects;
using sipsa.Domain._Base;
using sipsa.Domain.Users;
using sipsa.DomainTest._Builders;
using sipsa.DomainTest._Extensions;
using Xunit;

namespace sipsa.DomainTest.Users
{
    public class UserTest
    {
        private readonly User _user;

        public UserTest()
        {
            _user = UserBuilder.New().Build();
        }

        [Fact]
        public void MustToCreateUser()
        {
            //Given
            var userExpected = new
            {
                _user.Name,
                _user.Email,
                _user.Password,
                _user.Permission
            };

            //When
            var user = new User(userExpected.Name, userExpected.Email, userExpected.Password, userExpected.Permission);

            //Then
            userExpected.ToExpectedObject().ShouldMatch(user);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("123")]
        [InlineData("Zé")]
        public void MustNotHaveUserWithInvalidName(string invalidName)
        {
            //Then
            Assert.Throws<DomainException>(() =>
               UserBuilder.New().WithName(invalidName).Build()
            ).TestProperty(_user.Name);
        }
    }
}
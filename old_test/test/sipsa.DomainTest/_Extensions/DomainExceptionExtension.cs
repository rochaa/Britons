using System.Linq;
using sipsa.Domain._Base;
using Xunit;

namespace sipsa.DomainTest._Extensions
{
    public static class DomainExceptionExtension
    {
        public static void TestProperty(this DomainException ex, string property)
        {
            var propertyName = nameof(property);
            Assert.True(ex.Errors.Any(e => e.PropertyName == propertyName));
        }
    }
}
using Bogus;
using Finances.Business.Domain.Entities;

namespace Finances.Tests.Mocks
{
    public static class FinanceMock
    {
        public static Finance FinanceEntity()
        {
            var fake = new Faker<Finance>()
                .CustomInstantiator(faker => new Finance(faker.Lorem.Paragraph(), faker.Random.Double(), "Entrada"))
                .Generate();

            return fake;
        }
    }
}

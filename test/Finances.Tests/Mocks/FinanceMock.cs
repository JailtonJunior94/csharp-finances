using Bogus;
using Finances.Business.Domain.Dtos;
using Finances.Business.Domain.Entities;
using Finances.Business.Domain.Enums;

namespace Finances.Tests.Mocks
{
    public static class FinanceMock
    {
        public static Finance FinanceEntity()
        {
            var fake = new Faker<Finance>()
                .CustomInstantiator(faker => new Finance(faker.Lorem.Paragraph(), faker.Random.Double(), "INCOME"))
                .Generate();

            return fake;
        }

        public static FinanceRequest FinanceRequest()
        {
            var fake = new Faker<FinanceRequest>()
                .CustomInstantiator(faker => new FinanceRequest(faker.Lorem.Paragraph(), faker.Random.Double(), FinanceType.Income))
                .Generate();

            return fake;
        }
    }
}

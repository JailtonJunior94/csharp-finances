using Moq;
using Xunit;
using Moq.AutoMock;
using Finances.Tests.Mocks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Finances.Business.Domain.Entities;
using Finances.Business.Domain.Interfaces;
using Finances.Business.Application.Services;

namespace Finances.Tests.Application.Services
{
    public class FinanceServiceTest
    {
        private readonly AutoMocker _mocker;
        private readonly FinanceService _service;

        public FinanceServiceTest()
        {
            _mocker = new AutoMocker();
            _service = _mocker.CreateInstance<FinanceService>();
        }

        [Fact]
        public async Task MustBeCreateFinance()
        {
            //Arrange
            _mocker.GetMock<IFinanceRepository>()
                .Setup(t => t.InsertAsync(It.IsAny<Finance>()))
                .ReturnsAsync(FinanceMock.FinanceEntity());

            //Act
            var result = await _service.CreateFinanceAsync(FinanceMock.FinanceRequest());

            //Assert
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
        }
    }
}

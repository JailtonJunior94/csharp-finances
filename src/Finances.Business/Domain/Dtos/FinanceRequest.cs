using Finances.Business.Domain.Enums;

namespace Finances.Business.Domain.Dtos
{
    public class FinanceRequest
    {
        public string Title { get; set; }
        public double Value { get; set; }
        public FinaceType Type { get; set; }
    }
}

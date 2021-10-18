using Finances.Business.Domain.Enums;

namespace Finances.Business.Domain.Dtos
{
    public class FinanceRequest
    {
        public FinanceRequest() { }
        public FinanceRequest(string title, double value, FinanceType type)
        {
            Title = title;
            Value = value;
            Type = type;
        }

        public string Title { get; set; }
        public double Value { get; set; }
        public FinanceType Type { get; set; }
    }
}

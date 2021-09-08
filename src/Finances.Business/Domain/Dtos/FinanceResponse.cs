using System;

namespace Finances.Business.Domain.Dtos
{
    public class FinanceResponse
    {
        public FinanceResponse(Guid id, string title, double value, string type, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Value = value;
            Type = type;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public double Value { get; private set; }
        public string Type { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}

using System;
using Finances.Business.Shared.Extensions;

namespace Finances.Business.Domain.Entities
{
    public class Finance
    {
        public Finance() { }
        public Finance(string title, double value, string type)
        {
            ID = Guid.NewGuid();
            Title = title;
            Value = value;
            Type = type;
            CreatedAt = DateTime.Now.UtcBrazil();
        }

        public Guid ID { get; private set; }
        public string Title { get; private set; }
        public double Value { get; private set; }
        public string Type { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}

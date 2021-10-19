using System;

namespace Finances.Business.Domain.DomainObjects
{
    public class DomainException : Exception
    {
        public int Code { get; }

        public DomainException() { }
        public DomainException(int code, string message) : base(message)
        {
            Code = code;
        }

        public DomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}

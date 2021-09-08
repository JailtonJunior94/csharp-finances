using System.ComponentModel;

namespace Finances.Business.Domain.Enums
{
    public enum FinaceType
    {
        [Description("INCOME")]
        Income,

        [Description("OUTCOME")]
        Outcome
    }
}
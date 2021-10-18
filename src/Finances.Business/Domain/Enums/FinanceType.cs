using System.ComponentModel;

namespace Finances.Business.Domain.Enums
{
    public enum FinanceType
    {
        [Description("INCOME")]
        Income,

        [Description("OUTCOME")]
        Outcome
    }
}
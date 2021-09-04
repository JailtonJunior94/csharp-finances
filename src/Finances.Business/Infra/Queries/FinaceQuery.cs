namespace Finances.Business.Infra.Queries
{
    public static class FinaceQuery
    {
        public const string GetFinance = @"";
        public const string GetFinanceByID = @"";
        public const string InsertFinance = @"INSERT INTO
                                                  dbo.Finance
                                                VALUES
                                                  (@id, @title, @value, @type, @createdAt);";
    }
}

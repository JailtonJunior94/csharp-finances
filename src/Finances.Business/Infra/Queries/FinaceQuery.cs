namespace Finances.Business.Infra.Queries
{
    public static class FinaceQuery
    {
        public const string GetFinance = @"SELECT
                                              [ID],
                                              [Title],
                                              [Value],
                                              [Type],
                                              [CreatedAt]
                                            FROM
                                              [dbo].[Finance] (NOLOCK)
                                            ";
        public const string InsertFinance = @"INSERT INTO
                                                  dbo.Finance
                                                VALUES
                                                  (@id, @title, @value, @type, @createdAt);";
    }
}

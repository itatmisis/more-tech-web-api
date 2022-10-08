namespace CryptoPunks.MoreTech.Api.DataAccess.Abstractions;

public interface IDbPagable
{
    string GetPagingClause();
}

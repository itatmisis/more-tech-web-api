using System.Data.Common;

namespace CryptoPunks.MoreTech.Platform.Data.Factories;

public interface IPostgresConnectionFactory
{
    DbConnection GetConnection();
}

using System.Data.Common;

namespace CryptoPunks.MoreTech.Platform.Data.Providers;

public interface IDbConnectionsProvider
{
    DbConnection GetConnection();
}

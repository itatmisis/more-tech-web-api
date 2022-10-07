using System.Data;
using System.Data.Common;

namespace CryptoPunks.MoreTech.Platform.Data.Providers;

public interface IDbTransactionsProvider
{
    DbTransaction? Current { get; }

    Task<DbTransaction> BeginTransactionAsync(CancellationToken token);

    Task<DbTransaction> BeginTransactionAsync(
        IsolationLevel isolationLevel,
        CancellationToken token);
}

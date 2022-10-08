namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;

public interface ITransactionObjectRepository
{
    Task<TransactionObjectDb> GetTransactionObjectAsync(long transactionObjectId, CancellationToken cancellationToken);

    Task<long> AddTransactionObjectAsync(TransactionObjectDb transactionObjectDb, CancellationToken cancellationToken);

    Task DeleteTransactionObjectAsync(long transactionObjectId, CancellationToken cancellationToken);
}

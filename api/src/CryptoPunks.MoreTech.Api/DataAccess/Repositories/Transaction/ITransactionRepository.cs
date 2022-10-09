namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Transaction;

public interface ITransactionRepository
{
    Task<TransactionDb> GetTransactionAsync(long transactionId, CancellationToken cancellationToken);

    Task<long> AddTransactionAsync(TransactionDb transactionDb, CancellationToken cancellationToken);

    Task DeleteTransactionAsync(long transactionId, CancellationToken cancellationToken);
}

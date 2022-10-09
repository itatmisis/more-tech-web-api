namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Get;

public record GetTransactionsResponse(IEnumerable<Dtos.TransactionsMOdels.Transaction> Transactions);

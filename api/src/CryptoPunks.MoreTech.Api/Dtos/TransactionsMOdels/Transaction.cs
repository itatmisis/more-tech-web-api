using CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;
using CryptoPunks.MoreTech.Api.Dtos.UserModels;

namespace CryptoPunks.MoreTech.Api.Dtos.TransactionsMOdels;

public record Transaction(User? From, User To, TransactionObjectDb Object, DateTime DateTime);

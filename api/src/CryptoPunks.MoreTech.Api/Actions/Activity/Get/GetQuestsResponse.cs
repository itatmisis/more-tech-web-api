using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Quest;

namespace CryptoPunks.MoreTech.Api.Actions.Activity.Get;

public record GetQuestsResponse(IEnumerable<QuestDb> Quests);

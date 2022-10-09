using FluentMigrator;

namespace CryptoPunks.MoreTech.Api.DataAccess.Migrations;

[Migration(4)]
public class ActivitiesMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("quests").WithDescription("??")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("task_description").AsString().NotNullable()
            .WithColumn("reward").AsDecimal().NotNullable()
            .WithColumn("created_by").AsInt64().ForeignKey("users", "id");

        Create.Table("quests_answers").WithDescription("??")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("quest_id").AsInt64().ForeignKey("quests", "id")
            .WithColumn("correct_answer").AsString();

        Create.Table("quests_assignee").WithDescription("??")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("quest_id").AsInt64().ForeignKey("quests", "id")
            .WithColumn("user_id").AsInt64().ForeignKey("users", "id")
            .WithColumn("completion").AsBoolean().WithDefaultValue(false);
    }
}

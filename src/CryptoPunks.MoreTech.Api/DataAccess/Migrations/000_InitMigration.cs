// <auto-generated/>
using FluentMigrator;
using FluentMigrator.Oracle;
using FluentMigrator.Postgres;

namespace CryptoPunks.MoreTech.Api.DataAccess.Migrations;

[Migration(0)]
public class InitMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Execute.Sql(@"CREATE TYPE token_type AS ENUM ('NFT','DigitalRuble','Matic')");

        Create.Table("roles").WithDescription("")
            .WithColumn("role_id").AsString().PrimaryKey()
            .WithColumn("name").AsString().Unique().NotNullable()
            .WithColumn("description").AsString().NotNullable();

        Create.Table("job_titles").WithDescription("")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("name").AsString().Unique()
            .WithColumn("description").AsString().NotNullable();

        Create.Table("users").WithDescription("")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("nickname").AsString().Unique().NotNullable()
            .WithColumn("role").AsString().ForeignKey("roles", "role_id").NotNullable()
            .WithColumn("profile_pic_url").AsString().Nullable()
            .WithColumn("first_name").AsString().NotNullable()
            .WithColumn("second_name").AsString().NotNullable()
            .WithColumn("middle_name").AsString().Nullable()
            .WithColumn("job_title").AsInt32().ForeignKey("job_titles", "id")
            .WithColumn("employer").AsString().ForeignKey("users", "nickname").Nullable()
            .WithColumn("created_at").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime);

        Create.Table("transactional_objects").WithDescription("")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("descriminator").AsCustom("token_type")
            .WithColumn("digital_rub_value").AsDecimal().Nullable()
            .WithColumn("matic_value").AsDecimal().Nullable()
            .WithColumn("token_id").AsInt64().Nullable();

        Create.Table("pending_transactions").WithDescription("")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("transactional_object").AsInt64().ForeignKey("transactional_objects", "id")
            .WithColumn("from").AsInt64().ForeignKey("users", "id").Nullable()
            .WithColumn("to").AsInt64().ForeignKey("users", "id").NotNullable()
            .WithColumn("hash").AsString().NotNullable()
            .WithColumn("created_at").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime);

        Create.Table("wallets").WithDescription("")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("owner").AsInt64().ForeignKey("users", "id").NotNullable()
            .WithColumn("public_key").AsString().Unique().NotNullable()
            .WithColumn("private_key").AsString().Unique().NotNullable();
    }
}

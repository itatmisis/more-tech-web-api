using FluentMigrator;

namespace CryptoPunks.MoreTech.Api.DataAccess.Migrations;

[Migration(3)]
public class RolesAndTitlesMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        var dataToMigrate = new
        {
            name = "Админ",
            description = "???"
        };
        var dataToMigrate2 = new
        {
            name = "Тимлид",
            description = "???"
        };
        var dataToMigrate3 = new
        {
            name = "HR",
            description = "???"
        };
        var dataToMigrate4 = new
        {
            name = "Старший Контроллер",
            description = "???"
        };
        Insert
            .IntoTable("job_titles")
            .Row(dataToMigrate)
            .Row(dataToMigrate2)
            .Row(dataToMigrate3)
            .Row(dataToMigrate4);
        var role1 = new
        {
            role_id = "user",
            name = "Пользователь",
            description = "??"
        };
        var role2 = new
        {
            role_id = "admin",
            name = "Администратор",
            description = "??"
        };
        Insert
            .IntoTable("roles")
            .Row(role1)
            .Row(role2);
    }
}

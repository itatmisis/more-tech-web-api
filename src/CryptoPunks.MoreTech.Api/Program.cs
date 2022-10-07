// <auto-generated/>
using CryptoPunks.MoreTech.Platform.Data.FluentMigrator;
using CryptoPunks.MoreTech.Platform.Extensions;

var builder = WebApplication
    .CreateBuilder(args)
    .UsePlatform();
var services = builder.Services;

#region DI

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwagger("more-tech-api");

#endregion

var app = builder.Build();

#region App

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


#endregion

await app.RunOrMigrateAsync(args);

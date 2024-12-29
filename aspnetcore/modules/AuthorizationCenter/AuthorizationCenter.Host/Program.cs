using AuthorizationCenter.Host;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseAutofac();

await builder.AddApplicationAsync<AuthorizationCenterHostModule>();

var app = builder.Build();

await app.InitializeApplicationAsync();
await app.RunAsync();

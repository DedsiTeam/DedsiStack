using AuthorizationCenter.Host;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
    
builder.Services
    .AddDbContext<AuthorizationCenterDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
        options.UseOpenIddict();
    });

builder.Services
    .AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore().UseDbContext<AuthorizationCenterDbContext>();
    })
    .AddServer(options =>
    {
        options
            .SetTokenEndpointUris("connect/token");

        options
            .AllowClientCredentialsFlow();

        options
            .AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate();

        options
            .UseAspNetCore()
            .EnableTokenEndpointPassthrough()
            .DisableTransportSecurityRequirement();
    });

var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseCors();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();
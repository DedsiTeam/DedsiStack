using AuthorizationCenter.Host;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;

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
            .SetAuthorizationEndpointUris("connect/authorize", "connect/authorize/callback")
            .SetDeviceAuthorizationEndpointUris("device")
            .SetIntrospectionEndpointUris("connect/introspect")
            .SetEndSessionEndpointUris("connect/endsession")
            .SetRevocationEndpointUris("connect/revocat")
            .SetTokenEndpointUris("connect/token")
            .SetUserInfoEndpointUris("connect/userinfo")
            .SetEndUserVerificationEndpointUris("connect/verify");

        options
            .AllowAuthorizationCodeFlow()
            .AllowHybridFlow()
            .AllowImplicitFlow()
            .AllowPasswordFlow()
            .AllowClientCredentialsFlow()
            .AllowRefreshTokenFlow()
            .AllowDeviceAuthorizationFlow()
            .AllowNoneFlow();

        options.RegisterScopes(OpenIddictConstants.Scopes.OpenId, OpenIddictConstants.Scopes.Email, OpenIddictConstants.Scopes.Profile, OpenIddictConstants.Scopes.Phone, OpenIddictConstants.Scopes.Roles, OpenIddictConstants.Scopes.Address, OpenIddictConstants.Scopes.OfflineAccess);

        options
            .AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate();

        options.UseAspNetCore()
            .EnableAuthorizationEndpointPassthrough()
            .EnableTokenEndpointPassthrough()
            .EnableUserInfoEndpointPassthrough()
            .EnableEndSessionEndpointPassthrough()
            .EnableEndUserVerificationEndpointPassthrough()
            .EnableStatusCodePagesIntegration()
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
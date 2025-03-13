using Dedsi.CleanArchitecture.Domain;

namespace DedsiAuthorization;

public class DedsiAuthorizationDomainOptions : DedsiCleanArchitectureDomainOptions
{
    public const string ApplicationName = "DedsiAuthorization";
    
    public const string MobileApplicationName = "DedsiAuthorization.Mobile";
    
    public const string ConnectionStringName = "DedsiAuthorizationDB";
    
    public const string DbSchemaName  = "DedsiAuthorization";

    public const string DbTablePrefix = "DedsiAuthorization";
}
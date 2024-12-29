using Dedsi.CleanArchitecture.Domain;

namespace Identity;

public class IdentityDomainOptions : DedsiCleanArchitectureDomainOptions
{
    public const string ApplicationName = "Identity";
    
    public const string MobileApplicationName = "Identity.Mobile";
    
    public const string ConnectionStringName = "IdentityDB";
    
    public const string DbSchemaName  = "Identity";

    public const string DbTablePrefix = "Identity";
}
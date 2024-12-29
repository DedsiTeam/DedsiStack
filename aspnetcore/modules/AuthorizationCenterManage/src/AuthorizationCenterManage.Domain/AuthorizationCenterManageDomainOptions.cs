using Dedsi.CleanArchitecture.Domain;

namespace AuthorizationCenterManage;

public class AuthorizationCenterManageDomainOptions : DedsiCleanArchitectureDomainOptions
{
    public const string ApplicationName = "AuthorizationCenterManage";
    
    public const string MobileApplicationName = "AuthorizationCenterManage.Mobile";
    
    public const string ConnectionStringName = "AuthorizationCenterManageDB";
    
    public const string DbSchemaName  = "AuthorizationCenterManage";

    public const string DbTablePrefix = "AuthorizationCenterManage";
}
namespace AuthorizationCenterManage.OpenIddictApplications.Dtos;

public class CreateOpenIddictApplicationInputDto
{
    public string ClientId { get; set; }
    
    public string? DisplayName { get; set; }
    
    public HashSet<Uri> RedirectUris { get; set; }
    
    public HashSet<string> Permissions { get; set; }
}
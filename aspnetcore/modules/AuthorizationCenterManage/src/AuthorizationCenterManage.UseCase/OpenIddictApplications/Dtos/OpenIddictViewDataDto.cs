namespace AuthorizationCenterManage.OpenIddictApplications.Dtos;

public class OpenIddictViewDataDto
{
    /// <summary>
    /// GrantTypes
    /// </summary>
    public OpenIddictSelectItemDto[] Endpoints { get; set; }
    
    /// <summary>
    /// GrantTypes
    /// </summary>
    public OpenIddictSelectItemDto[] GrantTypes { get; set; }
    
    /// <summary>
    /// ResponseTypes
    /// </summary>
    public OpenIddictSelectItemDto[] ResponseTypes { get; set; }
}

public record OpenIddictSelectItemDto(string Value, string Label);
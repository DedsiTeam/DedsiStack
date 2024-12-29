using AuthorizationCenterManage.OpenIddictApplications.Commands;
using AuthorizationCenterManage.OpenIddictApplications.Dtos;
using AuthorizationCenterManage.OpenIddictApplications.Queries;
using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;

namespace AuthorizationCenterManage.OpenIddictApplications;

/// <summary>
/// OpenIddictApplication Manage
/// </summary>
/// <param name="dedsiMediator"></param>
/// <param name="openIddictApplicationQuery"></param>
public class OpenIddictApplicationController
    (IDedsiMediator dedsiMediator,
    IOpenIddictApplicationQuery openIddictApplicationQuery)
    : AuthorizationCenterManageController
{
    /// <summary>
    /// 获得 创建所需的数据
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<OpenIddictViewDataDto> GetOpenIddictViewDataAsync()
    {
        return openIddictApplicationQuery.GetOpenIddictViewDataAsync();
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<CreateOpenIddictApplicationResultDto> CreateOpenIddictApplicationAsync(CreateOpenIddictApplicationInputDto input)
    {
        return dedsiMediator.PublishAsync(new CreateOpenIddictApplicationCommand(input), HttpContext.RequestAborted);
    }
    
    /// <summary>
    /// 重置
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    [HttpPost("{clientId}")]
    public Task<string> CreateOpenIddictApplicationAsync(string clientId)
    {
        return dedsiMediator.PublishAsync(new ResetClientSecretCommand(clientId), HttpContext.RequestAborted);
    }
}

public class TestApiController : AuthorizationCenterManageController
{
    [HttpGet]
    public string Get() => CurrentUser.Name ?? "找不到Name！";
}
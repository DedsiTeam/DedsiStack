using Dedsi.Ddd.CQRS.Mediators;
using Dedsi.Ddd.Domain.Shared.EntityIds;
using DedsiAuthorization.DedsiUsers.CommandHandlers;
using DedsiAuthorization.DedsiUsers.Requests;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Security.Encryption;

namespace DedsiAuthorization.DedsiUsers;

public class DedsiUserController(IStringEncryptionService stringEncryptionService,IDedsiMediator dedsiMediator): DedsiAuthorizationController
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<GuidStronglyTypedId> CreateCrtadgAiUserAsync(CreateDedsiUserRequest request)
    {
        var crtadgAiUser = await dedsiMediator.SendAsync(new CreateDedsiUserCommand(request.Name, request.Account, request.Pwd), HttpContext.RequestAborted);

        return crtadgAiUser.Id;
    }
    
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<bool> UpdatePwdAsync(UpdatePwdRequest input)
    {
        var passPhrase = input.Id.ToString();

        var command = new UpdatePwdCommand(
            new GuidStronglyTypedId(input.Id),
            stringEncryptionService.Encrypt(input.OldPwd, passPhrase)!,
            stringEncryptionService.Encrypt(input.NewPwd, passPhrase)!);

        return dedsiMediator.SendAsync(command, HttpContext.RequestAborted);
    }
    
    /// <summary>
    /// 恢复：默认密码
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("{id}")]
    public Task<string> SetDefaultPwdAsync([FromRoute] Guid id)
    {
        return dedsiMediator.SendAsync(new SetDefaultPwdCommand(new GuidStronglyTypedId(id)), HttpContext.RequestAborted);
    }
}
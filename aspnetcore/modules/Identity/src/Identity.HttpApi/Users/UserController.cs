using Dedsi.Ddd.CQRS.Mediators;
using Microsoft.AspNetCore.Mvc;
using Identity.Users.Commands;
using Identity.Users.Dtos;
using Identity.Users.Queries;

namespace Identity.Users;

/// <summary>
/// 用户
/// </summary>
/// <param name="dedsiMediator"></param>
/// <param name="userQuery"></param>
public class UserController(IDedsiMediator dedsiMediator, IUserQuery userQuery) : IdentityController
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<Guid> CreateAsync(CreateUserInputDto input)
    {
        return dedsiMediator.PublishAsync(new CreateUserCommand(input.UserName, input.Account, input.Email));
    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<bool> UpdateAsync(UpdateUserInputDto input)
    {
        return dedsiMediator.PublishAsync(new UpdateUserCommand(input.Id, input.UserName, input.Account, input.Email));
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("{id}")]
    public Task<bool> DeleteAsync(Guid id)
    {
        return dedsiMediator.PublishAsync(new DeleteUserCommand(id));
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<UserDto> GetAsync(Guid id)
    {
        return userQuery.GetByidAsync(id, HttpContext.RequestAborted);
    }
}
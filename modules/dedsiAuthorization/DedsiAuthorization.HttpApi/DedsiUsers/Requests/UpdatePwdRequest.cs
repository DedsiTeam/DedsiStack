namespace DedsiAuthorization.DedsiUsers.Requests;

public record UpdatePwdRequest(Guid Id, string OldPwd,string NewPwd);
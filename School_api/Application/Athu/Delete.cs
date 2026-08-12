using System;

public class Delete
{
    private readonly IAuthRepository IAuth;
    public Delete(IAuthRepository _IAuth)
    {
        IAuth = _IAuth;
    }
    public async Task<bool> remove_user(DeleteAccount user)
    {
        return await IAuth.delete(user);
    }
}

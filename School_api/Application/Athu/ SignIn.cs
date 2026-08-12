using System;

public class SignIn
{
    private readonly IAuthRepository IAuth;
    public SignIn(IAuthRepository _IAuth)
    {
        IAuth = _IAuth;
    }
    public Task<string> LoginAccount(Login user)
    {
        return (IAuth.signin(user));
    }
}

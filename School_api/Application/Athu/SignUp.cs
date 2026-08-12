using System;
using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.entity;
public class SignUp
{
    private readonly IAuthRepository IAuth;
    public SignUp(IAuthRepository _IAuth)
    {
        IAuth = _IAuth;
    }
    public Task<register> signup(register user)
    {
        return (IAuth.signup(user));
    }
}

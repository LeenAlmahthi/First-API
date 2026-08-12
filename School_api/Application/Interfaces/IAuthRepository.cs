using System;
using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.entity;
public interface IAuthRepository
{
    public Task<register> signup(register user);
    public Task<string>? signin(Login user);
    public Task<bool> delete(DeleteAccount user);
}
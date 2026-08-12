using System;
using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.entity;

public class usermanager : IAuthRepository 
{
    private UserManager<ApplicationUser> _usermanager;
    private GenerateJwt _GenerateJwt;
    public usermanager(UserManager<ApplicationUser> App_user, GenerateJwt generateJwt)
    {
        _usermanager = App_user;
        _GenerateJwt = generateJwt;
    }
    private async Task<bool> IsAdmin()
    {
        var admin = await _usermanager.FindByNameAsync("Admin");
        if (admin == null)
        {
            return true;
        }
        return false;
    }
    ////int async FindCheckUser(string username , string password)
    ////{
    ////    var account = await _usermanager.FindByNameAsync(username);
    ////    if (account == null)
    ////        return 0;
    ////    //return Unauthorized("user name not found");
    ////    var pass = await _usermanager.CheckPasswordAsync(user, password);
    ////    if (!pass)
    ////        return null;
    ////}
    private async Task AddAccount(register user, string role)
    {
        var account = new ApplicationUser();
        account.UserName = user.Username;
        account.Email = user.Email;
        var Pass = await _usermanager.CreateAsync(account, user.Password);
        if (Pass == null)
            throw new Exception("Not Allow This Passwords!!");
        var roleResult = await _usermanager.AddToRoleAsync(account, role);
        if (!roleResult.Succeeded)
        {
            throw( new Exception("can't add role!!"));
        }
    }
    public async Task<register> signup(register user)
    {
        if (user == null)
            throw new Exception("Enter password and Username");
        if (await IsAdmin())
        {
            await AddAccount(user, "Admin");
            return (user);
        }
        await AddAccount(user, "student");
        return (user);
    }

    public async Task<string>? signin(Login user)
    {
        if (user == null)
            return null;
        var Account = await _usermanager.FindByNameAsync(user.UserName);
        if (Account == null)
            return null;
        var pass = await _usermanager.CheckPasswordAsync(Account, user.Password);
        if (!pass)
            return null;
        var re = await _GenerateJwt.CreateJwt(Account);
        return (re);
    }
    public async Task<bool> delete(DeleteAccount user)
    {
        var Account = await _usermanager.FindByNameAsync(user.UserName);
        if (Account == null)
            return false;
        var re = await _usermanager.DeleteAsync(Account);
        if (!re.Succeeded)
            return false;
        return true;
    }

}

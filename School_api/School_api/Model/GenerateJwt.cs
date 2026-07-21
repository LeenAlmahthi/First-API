using System;
using School_api._login;
using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using School_api.Model;
using School_api.Data;
using School_api.Register;
using School_api._login;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
public class GenerateJwt
{
	private DataContext Data; 
	private UserManager<ApplicationUser> _manageruser;
	public GenerateJwt(DataContext data, UserManager<ApplicationUser> _user)
	{
		Data = data;
		_manageruser = _user;
	}
	public static string CreateJwt(ApplicationUser user)
	{
        List<Claim>_claims  = new List<Claim>();

		Claim c1 = new Claim(ClaimTypes.NameIdentifier, user.Id);
        Claim c2 = new Claim(ClaimTypes.Email, user.Email);
		Claim c3 = new Claim(ClaimTypes.Name, user.UserName);

		_claims.Add(c1);
		_claims.Add(c2);
		_claims.Add(c3);

		// Claim is Done 
		var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes("ThisIsMySecretKey123!"));
		var algo = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
		var objJwt = 
            new JwtSecurityToken(
    claims: _claims,
    expires: DateTime.Now.AddHours(1),
    signingCredentials: algo
);
		var token = new JwtSecurityTokenHandler();
		string str = token.WriteToken(objJwt);
		//return objJwt.GenerateToken(user);
		return (str);
	}
}
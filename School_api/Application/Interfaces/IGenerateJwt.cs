using System;
using School_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.entity;
public interface IGenerateJwt 
{
    public  Task<string> CreateJwt(ApplicationUser user);
}
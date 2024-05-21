using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    //private readonly AppSettings _appSettings;


    public IdentityService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        //_appSettings = appSettings.Value;
    }

    public async Task<bool> CreateUserAsync(string userName, string password, string email)
    {
        var user = new IdentityUser
        {
            UserName = userName,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }

    public async Task<bool> SignInAsync(string userName, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
        return result.Succeeded;
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IIdentityService
{
    Task<bool> SignInAsync(string userName, string password);
    Task<bool> CreateUserAsync(string userName, string password, string email);
}

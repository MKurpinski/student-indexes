using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudentIndexes.Domain.DTOs;

namespace StudentIndexes.Domain.Repositories.Interfaces
{
    public interface IAuthRepository:IDisposable
    {
        Task<IdentityResult> RegisterUser(UserDto userModel);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}

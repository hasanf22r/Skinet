using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task Create(AppUser appUser, string password);
        Task<AppUser> Delete(string userid);
        Task<AppUser> Get(string userid);
        Task<IReadOnlyList<AppUser>> GetAll();
        Task<AppUser> Update(AppUser appUser);
    }
}
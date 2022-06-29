using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class StoreContext : IdentityDbContext<AppUser, AppRole, int>
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }
}

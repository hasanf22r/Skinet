using Microsoft.AspNetCore.Identity;
#nullable disable
namespace Domain;
public class AppUser: IdentityUser<int>
{
    public string Image { get; set; }
}

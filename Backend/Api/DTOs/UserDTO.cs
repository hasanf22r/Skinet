using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable
namespace Api.DTOs
{
    public class CreateUserDTO
    {
        public IFormFile Image { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
    public class UpdateUserDTO
    {
        public IFormFile Image { get; set; }
        public string Username { get; set; }

        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
    public class GetUserDTO
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }

}
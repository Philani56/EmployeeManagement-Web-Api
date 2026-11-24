using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models.Entitties
{


    public class ApplicationUser : IdentityUser
    {
    }

     
        public class RegisterModel
        {
            //public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginModel
        {
            //public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }


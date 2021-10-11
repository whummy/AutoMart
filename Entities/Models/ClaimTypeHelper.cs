using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ClaimTypeHelper
    {
        public static string UserId { get; set; } = "UserId";
        public static string Email { get; set; } = "Email";
        public static string FirstName { get; set; } = "FirstName";
        public static string LastName { get; set; } = "LastName";
        public static string Roles { get; set; } = ClaimTypes.Role;
    }
}

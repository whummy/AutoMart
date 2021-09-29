using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserToken
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public User User { get; set; }
    }
}

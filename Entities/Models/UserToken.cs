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
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; }
        
    }
    public class RefreshTokenDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class UserTokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime? ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}

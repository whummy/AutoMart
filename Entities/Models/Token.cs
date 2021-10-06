using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Token
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string TokenType { get; set; }
        public string Value { get; set; }
        public DateTime ExpiresAt { get; set; } = DateTime.Now.AddDays(3);
    }
}

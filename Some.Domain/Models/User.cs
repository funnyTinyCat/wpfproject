using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public int? ModifiedByUserId { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Locked { get; set; }
        public bool Visible { get; set; }
        public bool Version { get; set; }
    }
}

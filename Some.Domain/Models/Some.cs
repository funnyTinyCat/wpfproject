using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somes.Domain.Models
{
    public class Some
    {
        public Guid Id { get; }
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public Some(Guid id, string username, bool isSubscribed, bool isMember) 
        {
            Id = id;
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }

    }
}

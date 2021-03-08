using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Entities
{
    public class Credentials
    {
        public IEnumerable<Role> Roles { get; set; }
    }

    public class Role
    {
        public string Name { get; set; }
        public ICollection<ClaimRole> Claims { get; set; }
    }

    public class ClaimRole
    {
        public Claim Claim { get; set; }
    }

    public class Claim
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}

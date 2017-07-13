using System;
using Microsoft.AspNet.Identity;

namespace FoxyEcomm.Identity.PostgreSql.Models
{
    public class IdentityUser : IUser
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public IdentityUser(string username)
            : this()
        {
            this.UserName = username;
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string SecurityStamp { get; set; }
        public virtual string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public DateTime Created { get; set; }

        public DateTime UpdateTime { get; set; }

        public int Status { get; set; }
      
    }
}

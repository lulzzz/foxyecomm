using System;
using Microsoft.AspNet.Identity;

namespace FoxyEcomm.Identity.PostgreSql.Models
{
    public class IdentityRole : IRole
    {
        public IdentityRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public IdentityRole(string name)
            : this()
        {
            this.Name = name;
        }

        public IdentityRole(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}

using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Programming005.WebProj.DataAccessLayer
{
    public class InMemoryRoleRepository : IRoleRepository
    {
        private readonly List<Role> _roles;

        public InMemoryRoleRepository()
        {
            _roles = new List<Role>();
        }

        public void Add(Role role)
        {
            _roles.Add(role);   
        }

        public void Update(Role role)
        {
            var fromDb = _roles.FirstOrDefault(x => x.Id == role.Id);
            fromDb.Name = role.Name;
        }

        public Role GetById(int id)
        {
            return _roles.FirstOrDefault(x => x.Id == id);
        }

        public Role GetByRolename(string rolename)
        {
            return _roles.FirstOrDefault(x => 
            x.Name.ToLowerInvariant() == rolename.ToLowerInvariant());
        }
    }
}

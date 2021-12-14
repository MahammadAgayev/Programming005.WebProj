using Programming005.WebProj.DataAccessLayer.Domain.Entities;

namespace Programming005.WebProj.DataAccessLayer.Abstraction
{
    public interface IRoleRepository
    {
        void Add(Role role);
        void Update(Role role);
        Role GetByRolename(string rolename);
        Role GetById(int id);
    }
}

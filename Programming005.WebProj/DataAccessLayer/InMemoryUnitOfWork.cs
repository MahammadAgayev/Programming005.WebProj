using Programming005.WebProj.DataAccessLayer.Abstraction;

namespace Programming005.WebProj.DataAccessLayer
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public IAccountRepository AccountRepository => new InMemoryAccountRepository();
        public IRoleRepository RoleRepository => new InMemoryRoleRepository();
        public IAccountRoleRepository AccountRoleRepository => new InMemoryAccountRoleRepository();
    }
}

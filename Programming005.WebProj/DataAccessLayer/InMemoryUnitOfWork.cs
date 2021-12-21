using Programming005.WebProj.DataAccessLayer.Abstraction;

namespace Programming005.WebProj.DataAccessLayer
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private static IAccountRepository _accountRepository = new InMemoryAccountRepository();
        private static IRoleRepository _roleRepository = new InMemoryRoleRepository();
        private static IAccountRoleRepository _accountRoleRepository = new InMemoryAccountRoleRepository();


        public IAccountRepository AccountRepository => _accountRepository;
        public IRoleRepository RoleRepository => _roleRepository;
        public IAccountRoleRepository AccountRoleRepository => _accountRoleRepository;
    }
}

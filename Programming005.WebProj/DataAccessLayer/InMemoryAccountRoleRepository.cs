using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Programming005.WebProj.DataAccessLayer
{
    public class InMemoryAccountRoleRepository : IAccountRoleRepository
    {
        private readonly List<AccountRole> _accountRoles = new List<AccountRole>();

        public void Add(AccountRole accountRole)
        {
           accountRole.Id = _accountRoles.LastOrDefault()?.Id ?? 1;

            _accountRoles.Add(accountRole);
        }

        public IList<AccountRole> GetByUser(int userId)
        {
            return _accountRoles.Where(x => x.AccountId == userId).ToList();
        }

        public IList<Account> GetByRole(string roleName)
        {
            return _accountRoles
                .Where(x => x.Role.Name.ToLowerInvariant() == roleName.ToLowerInvariant())
                .Select(x => x.Account).ToList();
        }
    }
}
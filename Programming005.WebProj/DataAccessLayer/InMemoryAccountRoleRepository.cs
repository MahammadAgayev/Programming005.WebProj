using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using System.Collections.Generic;

namespace Programming005.WebProj.DataAccessLayer
{
    public class InMemoryAccountRoleRepository : IAccountRoleRepository
    {
        private readonly List<AccountRole> _accountRoles = new List<AccountRole>();

        public void Add(AccountRole accountRole)
        {
            var latest = _accountRoles[_accountRoles.Count - 1].Id;
            accountRole.Id = latest + 1;

            _accountRoles.Add(accountRole);
        }
    }
}
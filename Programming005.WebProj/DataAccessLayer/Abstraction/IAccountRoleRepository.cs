using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using System.Collections.Generic;

namespace Programming005.WebProj.DataAccessLayer.Abstraction
{
    public interface IAccountRoleRepository
    {
        void Add(AccountRole accountRole);

        IList<AccountRole> GetByUser(int userId);

        IList<Account> GetByRole(string roleName);
    }
}

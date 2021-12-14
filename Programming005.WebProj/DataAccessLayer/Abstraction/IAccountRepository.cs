using Programming005.WebProj.DataAccessLayer.Domain.Entities;

namespace Programming005.WebProj.DataAccessLayer.Abstraction
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Update(Account account);

        Account Get(int id);
        Account GetByUsername(string username);

        void Delete(int id);
    }
}

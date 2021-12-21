using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming005.WebProj.DataAccessLayer
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts;

        public InMemoryAccountRepository()
        {
            _accounts = new List<Account>();
        }


        public void Add(Account account)
        {
            //var latest = _accounts.LastOrDefault();
            //int id = 1;

            //if(latest != null)
            //{
            //    id = latest.Id + 1;
            //}

            int id = _accounts.LastOrDefault()?.Id ?? 1;

            account.Id = id;
            _accounts.Add(account);
        }

        public Account Get(int id)
        {
            //LINQ;
            //First and FirstDefault difference

            return _accounts.FirstOrDefault(x => x.Id == id);
        }

        public Account GetByUsername(string username)
        {
            return _accounts.FirstOrDefault(x =>
            x.Username.ToLowerInvariant() == username.ToLowerInvariant());
        }

        public void Update(Account account)
        {
            var dbAccount = _accounts.FirstOrDefault(x => x.Id == account.Id);

            if (dbAccount != account)
            {
                dbAccount.Username = account.Username;
                dbAccount.PasswordHash = account.PasswordHash;
                dbAccount.PhoneNumber = account.PhoneNumber;
                dbAccount.Email = account.Email;
                dbAccount.PhoneNumberConfirmed = account.PhoneNumberConfirmed;
                dbAccount.EmailConfirmed = account.EmailConfirmed;
            }
        }

        public void Delete(int id)
        {
            _accounts.RemoveAll(x => x.Id == id);
        }
    }
}

using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Programming005.WebProj.DataAccessLayer.Abstraction
{
    public interface IDatabase
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int customerId);

        Customer Get(int id);
        IList<Customer> Get();

        void AddOperation(string operation);
    }
}

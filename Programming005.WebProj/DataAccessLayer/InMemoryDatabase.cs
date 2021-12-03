using Newtonsoft.Json;
using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Programming005.WebProj.DataAccessLayer
{
    public class InMemoryDatabase : IDatabase
    {
        private const string _datastate = "customers.json";
        private const string _operationDatastate = "customers.json";


        private readonly List<Customer> _customers = new List<Customer>();
        private readonly List<string> _operations = new List<string>();

        public InMemoryDatabase()
        {
            if(File.Exists(_datastate))
            {
                string rawText = File.ReadAllText(_datastate);
                var customers = JsonConvert.DeserializeObject<Customer[]>(rawText);

                _customers.AddRange(customers);
            }

            if(File.Exists(_operationDatastate))
            {
                string rawText = File.ReadAllText(_operationDatastate);
                var operations = JsonConvert.DeserializeObject<string[]>(rawText);

                _operations.AddRange(operations);
            }

            //_customers.Add(new Customer
            //{
            //    Id = 1,
            //    Email = "mahammad.agayev@gmail.com",
            //    Firstname = "Mahammad",
            //    Lastname = "Agayev",
            //    PhoneNumber = "994519110661"
            //});

            //_customers.Add(new Customer
            //{
            //    Id = 2,
            //    Email = "leyla.aliyeva@gmail.com",
            //    PhoneNumber = "idontknow",
            //    Firstname = "Leyla",
            //    Lastname = "Aliyeva"
            //});

            //_customers.Add(new Customer
            //{
            //    Id = 3,
            //    Email = "muzaffar.agayev@gmail.com",
            //    Firstname = "Muzaffer",
            //    Lastname = "Agayev",
            //    PhoneNumber = "994515853545"
            //});

            //_customers.Add(new Customer
            //{
            //    Email = "qabil.huseynli@gmail.com",
            //    Firstname = "Qabil",
            //    Lastname = "Huseynli",
            //    Id = 4,
            //    PhoneNumber = "idontknow2"
            //});
        }

        public void Add(Customer customer)
        {
            int id = 1;
            if(_customers.Count > 0)
            {
                id = _customers[_customers.Count - 1].Id + 1;
            }

            customer.Id = id;

            _customers.Add(customer);

            this.SaveToFile();
        }

        public void AddOperation(string operation)
        {
            _operations.Add(operation);


        }

        public void Delete(int customerId)
        {
            _customers.RemoveAll(x => x.Id == customerId);

            //Customer customer = null;

            //foreach (var c in _customers)
            //{
            //    if(c.Id == customerId)
            //    {
            //        customer = c;
            //        break;
            //    }
            //}

            //_customers.Remove(customer);

            this.SaveToFile();
        }

        public Customer Get(int id)
        {
            return _customers.FirstOrDefault(x => x.Id == id);
        }

        public IList<Customer> Get()
        {
            return _customers;
        }

        public void Update(Customer customer)
        {
            var updatable = _customers.FirstOrDefault(x => x.Id == customer.Id);

            if(updatable != null)
            {
                updatable.Firstname = customer.Firstname;
                updatable.Lastname = customer.Lastname;
                updatable.PhoneNumber = customer.PhoneNumber;
                updatable.Email = customer.Email;
            }

            this.SaveToFile();
        }


        private void SaveToFile()
        {
            File.WriteAllText(_datastate, JsonConvert.SerializeObject(_customers));
        }

        private void SaveOperationsToFile()
        {
            File.WriteAllText(_operationDatastate, JsonConvert.SerializeObject(_operations));
        }
    }
}

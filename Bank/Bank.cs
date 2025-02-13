using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Bank
    {
        public List<Customer> customers { get; set; }
        public ATM Atm { get; set; }
        public Bank()
        {
            ATM Atm = new ATM();
            List<Customer> customers = new List<Customer>();
            generateCustomers(customers);
            Atm.HandleMenu(customers);
        }
        private void generateCustomers(List<Customer> customers)
        {
            customers.Add(new Customer { Name = "Björn", Account = new Account { } });
            customers.Add(new Customer { Name = "Ulf-Arne", Account = new Account { } });
            customers.Add(new Customer { Name = "Britt-Marie", Account = new Account { } });
            customers.Add(new Customer { Name = "Erika", Account = new Account { } });
            customers.Add(new Customer { Name = "Måns", Account = new Account { } });
        }
    }


}

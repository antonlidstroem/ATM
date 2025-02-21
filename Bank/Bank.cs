using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Bank
    {
        public Customer[] customers { get; set; }
        public ATM Atm { get; set; }
        public Bank()
        {
            ATM Atm = new ATM();
            Customer[] customers = new Customer[10];
            generateCustomers(customers);
            Atm.HandleMenu(customers);
        }
        private void generateCustomers(Customer[] customers)
        {
            customers[0] = (new Customer { Name = "Björn", Account = new Account { } });
            customers[1] = (new Customer { Name = "Ulf", Account = new Account { } });
            customers[2] = (new Customer { Name = "Marie", Account = new Account { } });
            customers[7] = (new Customer { Name = "Erika", Account = new Account { } });
            customers[3] = (new Customer { Name = "Måns", Account = new Account { } });
            customers[4] = (new Customer { Name = "Björn", Account = new Account { } });
            customers[5] = (new Customer { Name = "Arne", Account = new Account { } });
            customers[6] = (new Customer { Name = "Britt", Account = new Account { } });
            customers[8] = (new Customer { Name = "Erika", Account = new Account { } });
            customers[9] = (new Customer { Name = "Måns", Account = new Account { } });

        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class ATM
    {
        private void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Meny");
            Console.WriteLine("1. Ta ut pengar");
            Console.WriteLine("2. Sätt in pengar");
            Console.WriteLine("3. Visa kontosaldo");
            Console.WriteLine("4. Visa alla konton");
            Console.WriteLine("0. Avsluta");

        }

        public void HandleMenu(List<Customer> customers)
        {
            int choice;
            int customerId;

            do
            {
                Console.Clear();
                PrintMenu();
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        customerId = PickCustomerId(customers);
                        customers[customerId].Account.Withdrawal(customers, customerId);
                        break;

                    case 2:
                        customerId = PickCustomerId(customers);
                        customers[customerId].Account.Deposit(customers, customerId);
                        break;

                    case 3:
                        ShowAccount(customers, PickCustomerId(customers));
                        Console.ReadLine();
                        break;

                    case 4:
                        ShowAllAccounts(customers);
                        break;
                }
            } while (choice != 0);
        }
        private void ShowAllAccounts(List<Customer> customers)
        {
            for (int i = 0; i < customers.Count(); i++)
            {
                ShowAccount(customers, i);
            }
            Console.ReadLine();

        }
        private void ShowAccount(List<Customer> customers, int customerId)
        {
            Console.WriteLine(customers[customerId].Name);
            Console.WriteLine(customers[customerId].Account.AccountNr);
            Console.WriteLine(customers[customerId].Account.Saldo);
        }

        private int PickCustomerId(List<Customer> customers)
        {
            int customerId = 0;
            Console.WriteLine(customers.Count());
            Console.WriteLine("Fyll i customerId: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input < customers.Count())
                {
                    customerId = input;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Felaktig inmatning");
                Console.ReadLine();
            }
            return customerId;
        }
    }
}



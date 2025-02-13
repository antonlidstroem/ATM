using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        public string AccountNr { get; set; }
        public int Saldo { get; set; }

        public Account()
        {
            Random accountNr = new Random();
            AccountNr = accountNr.Next(1000, 9999).ToString();

            Random saldo = new Random();
            Saldo = saldo.Next(100000, 999999);
        }
        public void Withdrawal(List<Customer> customers, int customerId)
        {
            Console.WriteLine("Hur mycket pengar vill du ta ut?");
            int input = int.Parse(Console.ReadLine());

            if (input <= Saldo)
            {
                Saldo -= input;
            }

            Console.WriteLine($"Ditt nya saldo är {Saldo}");
            
            Console.ReadLine(); 
        }
        public void Deposit(List<Customer> customers, int customerId)
        {
            Console.WriteLine("Hur mycket pengar vill du sätta in?");
            int input = int.Parse(Console.ReadLine());

           
                Saldo += input;
           

            Console.WriteLine($"Ditt nya saldo är {Saldo}");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public void Withdrawal(Customer[] customers, int customerId)
        {
            bool newAttempt = true;

            do
            {
                Welcome(customers, customerId, "UTTAG", "ta ut");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input <= Saldo)
                    {
                        Saldo -= input;
                        NewSaldo(input, true);
                        newAttempt = false;
                    }
                    else
                    {
                        Console.WriteLine("Du har tyvärr inte så mycket pengar på ditt konto.");
                        Console.WriteLine("Tryck valfri tangent för att komma vidare.");
                        Console.ReadLine();
                        newAttempt = NewAttempt();
                    }
                }
                catch (Exception)
                {
                    newAttempt = NewAttempt();
                }
            } while (newAttempt == true);
        }
        public void Deposit(Customer[] customers, int customerId)
        {
            bool newAttempt = true;

            do
            {
                Welcome(customers, customerId, "INSÄTTNING", "sätta in");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    Saldo += input;
                    NewSaldo(input, false);
                    newAttempt = false;
                }
                catch (Exception)
                {
                    newAttempt = NewAttempt();
                }
            } while (newAttempt == true);
        }
        private void Welcome(Customer[] customers, int customerId, string uttag, string action)
        {
            Console.Clear();
            Console.WriteLine(uttag);
            Console.WriteLine();
            Console.WriteLine($"Välkommen {customers[customerId].Name}!");
            Console.WriteLine($"Du har {Saldo} kr på ditt konto.");
            Console.WriteLine();
            Console.WriteLine($"Välj vilket belopp du vill {action}:");
        }
        private void NewSaldo(int input, bool uttag)
        {
            Console.Clear();

            if (uttag == true)
            {
                Console.WriteLine($"Varsågod här kommer {input} kr.");
            }

            Console.WriteLine($"Ditt nya saldo är {Saldo} kr.");
            Console.WriteLine();
            Console.WriteLine("Ha en fortsatt fin dag!");
        }
        private bool NewAttempt()
        {
            Console.WriteLine();
            Console.WriteLine("Felaktig inmatning");
            Console.WriteLine("Vill du prova igen? (J/N)");

            if (Console.ReadLine().ToUpper() != "J")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

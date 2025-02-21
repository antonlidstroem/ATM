using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank
{
    public class ATM
    {
        private void PrintMenu()
        {
            Console.WriteLine("VÄLKOMMEN TILL LIDSTROEM BANK!");
            Console.WriteLine();
            Console.WriteLine("Meny");
            Console.WriteLine("1. Ta ut pengar");
            Console.WriteLine("2. Sätt in pengar");
            Console.WriteLine("3. Visa kontosaldo");
            Console.WriteLine("4. Visa alla konton");
            Console.WriteLine("0. Avsluta");
        }
        public void HandleMenu(Customer[] customers)
        {
            int? choice;
            int customerId;


            do
            {
                Console.Clear();
                PrintMenu();
                choice = Input();


                switch (choice)
                {
                    case 1: //WITHDRAWAL
                        customerId = PickCustomerId(customers);

                        if (customerId < customers.Count())
                            customers[customerId].Account.Withdrawal(customers, customerId);

                        break;

                    case 2: //DEPOSIT
                        customerId = PickCustomerId(customers);

                        if (customerId < customers.Count())
                            customers[customerId].Account.Deposit(customers, customerId);
                        break;

                    case 3: //SHOW SPECIFIC ACCOUNT
                        ShowAccount(customers, PickCustomerId(customers), false);
                        break;

                    case 4: //SHOW ALL ACCOUNTS
                        ShowAllAccounts(customers);
                        break;

                    case 0: //END
                        break;

                    default: //OTHER INPUT
                        InputFailed();
                        break;
                }

                if (choice != 0)
                BackToMenu();

            } while (choice != 0);
        }
        private void ShowAllAccounts(Customer[] customers)
        {
            Console.Clear();
            Console.WriteLine($"Kundnummer\tKund\t\tBankkonto\tSaldo");
            for (int i = 0; i < customers.Count(); i++)
            {
                ShowAccount(customers, i, true);
            }

        }
        private void ShowAccount(Customer[] customers, int customerId, bool showAll)
        {
            try
            {
                if (showAll == false)
                {
                    Console.Clear();
                    Console.WriteLine($"Kundnummer\tKund\t\tBankkonto\tSaldo");
                }
                Console.Write(customerId);
                Console.Write($"\t\t{customers[customerId].Name}");
                Console.Write($"\t\t{customers[customerId].Account.AccountNr}");
                Console.Write($"\t\t{customers[customerId].Account.Saldo} SEK");
                Console.WriteLine();

            }
            catch (Exception)
            {
                InputFailed();
            }
        }
        private int PickCustomerId(Customer[] customers)
        {
            int customerId = 10;
            Console.Clear();
            Console.WriteLine($"Den här banken har {customers.Count()} kunder.");
            Console.WriteLine($"Fyll i ditt Kund-Id (siffra 1-10)");
            //Console.WriteLine("Fyll i customerId: ");
            int inputToInt;
            string input = Console.ReadLine();

            if (IsInputAnInt(input) == true)
            {
                inputToInt = Convert.ToInt32(input) - 1;

                if (inputToInt < customers.Count())
                    customerId = inputToInt;
                else
                    InputFailed();
            }
            else
            {
                InputFailed();
            }

            return customerId;
        }
        public static bool IsInputAnInt(string input)
        {
            if (int.TryParse(input, out int number))
                return true;
            else
                return false;
        }
        public static void InputFailed()
        {
            Console.Clear();
            Console.WriteLine("Felaktig inmatning");
        }
        public static int? Input()
        {
            string input = Console.ReadLine();

            if (IsInputAnInt(input) == true)
                return Convert.ToInt32(input);
            else
                return null;
        }
        public static void BackToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att komma tillbaka till huvudmenyn");
            Console.ReadLine();
        }
    }
}



using System;
using System.Collections.Generic;

namespace Task
{

    class BankAccount
    {
        public string AccountHolder { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        private List<string> transactions = new List<string>();

        public BankAccount(string name, string accNo, decimal balance)
        {
            AccountHolder = name;
            AccountNumber = accNo;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                transactions.Add($"Deposited: {amount:C}");
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                transactions.Add($"Withdrawn: {amount:C}");
                return true;
            }
            return false;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Name           : {AccountHolder}");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Balance        : {Balance:C}");
        }

      
        public void ShowTransactions()
        {
            Console.WriteLine("\n------ TRANSACTION HISTORY ------");

            if (transactions.Count == 0)
            {
                
                Console.WriteLine("No transactions yet.");
                return;
            }

            foreach (var t in transactions)
            {
                Console.WriteLine(t);
            }
        }
    }

    internal class Program
    {
        static int option;

        static void Main(string[] args)
        {

            Console.WriteLine("Enter Account Holder Name: ");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter Account Number: ");
            string accNo = Console.ReadLine()!;

            decimal balance;
            while (!decimal.TryParse(Console.ReadLine(), out balance))
            {
                Console.WriteLine("Enter valid balance:");
            }

            BankAccount account = new BankAccount(name, accNo, balance);

            while (true)
            {
                Console.Clear();

                Header();

 
                ShowMenu();

                Console.Write("Select option: ");
                option = int.Parse(Console.ReadLine()!);

                Console.Clear();

                switch (option)
                {
                    case 1:
                        account.ShowDetails();
                        break;

                    case 2:
                        Console.WriteLine($"Balance: {account.Balance:C}");
                        break;

                    case 3:
                        Deposit(account);
                        break;

                    case 4:
                        Withdraw(account);
                        break;

                    case 5:
                        account.ShowTransactions();
                        break;

                    case 6:
                        Console.WriteLine("Thank you!");
                        return; // Q48: Stop loop
                }

                // Q49: Pause screen
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
            }
        }

        // =========================
        // PART 10: ORGANIZE METHODS
        // =========================

        // Welcome message method
        static void Header()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("     HATTON NATIONAL BANK        ");
            Console.WriteLine("=================================");
        }

        // Menu display method
        static void ShowMenu()
        {
            Console.WriteLine("\n1. View Account");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Transaction History");
            Console.WriteLine("6. Exit");
        }

        // Q54: Deposit method moved out
        static void Deposit(BankAccount acc)
        {
            Console.Write("Enter deposit amount: ");

            decimal amount;
            if (decimal.TryParse(Console.ReadLine(), out amount))
            {
                acc.Deposit(amount);
                Console.WriteLine("Deposit successful!");
            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }

        // Q55: Withdraw method moved out
        static void Withdraw(BankAccount acc)
        {
            Console.Write("Enter withdraw amount: ");

            decimal amount;
            if (decimal.TryParse(Console.ReadLine(), out amount))
            {
                if (acc.Withdraw(amount))
                {
                    Console.WriteLine("Withdraw successful!");
                }
                else
                {
                    Console.WriteLine("Insufficient balance!");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }
    }
}
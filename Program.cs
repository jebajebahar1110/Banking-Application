using System;

namespace Task
{
    internal class Program
    {
        // Global Variables
        static string name;
        static string acNumber;
        static decimal opBalance;
        static int option;

        static void Header()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("          HATTON NATIONAL BANK            ");
            Console.WriteLine("==========================================");
        }

        static void Welcome()
        {
            Console.WriteLine("********************************");
            Console.WriteLine(" Welcome to Hatton National Bank");
            Console.WriteLine("********************************");
        }

        static void Main(string[] args)
        {
            Header();
            Welcome();

            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("           Account Details          ");
            Console.WriteLine("------------------------------------");

            // Account Holder Name
            Console.Write("Enter Account Holder Name: ");
            name = Console.ReadLine()!;

            // Account Number Validation
            while (string.IsNullOrEmpty(acNumber))
            {
                Console.Write($"{name}, Enter Your Account Number: ");
                acNumber = Console.ReadLine()!;

                if (string.IsNullOrEmpty(acNumber))
                {
                    Console.WriteLine("Enter a valid account number.");
                }
            }

            // Opening Balance Validation
            while (true)
            {
                Console.Write("Enter Opening Balance: ");

                if (decimal.TryParse(Console.ReadLine(), out opBalance))
                {
                    break;
                }

                Console.WriteLine("Invalid balance entered. Please enter a valid amount.");
            }

            // MAIN MENU LOOP 
            while (true)
            {
                Console.Clear();
                Header();
                Welcome();

                Console.WriteLine("\n-------------- SUMMARY --------------");
                Console.WriteLine($"Account Holder Name : {name}");
                Console.WriteLine($"Account Number      : {acNumber}");
                Console.WriteLine($"Opening Balance     : {opBalance:C}");
                Console.WriteLine("-------------------------------------");

                Menu();

                // ✅ Pause screen before looping again
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void Menu()
        {
            Console.WriteLine("\n============== MENU ==============");
            Console.WriteLine("1. View Account");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==================================");

            Console.Write("Select an option (1-5): ");
            option = int.Parse(Console.ReadLine()!);

            Selectors();
        }

        static void Selectors()
        {
            if (option == 1)
            {
                Console.WriteLine("\n------ ACCOUNT DETAILS ------");
                Console.WriteLine($"Name           : {name}");
                Console.WriteLine($"Account Number : {acNumber}");
                Console.WriteLine($"Balance        : {opBalance:C}");
            }
            else if (option == 2)
            {
                Console.WriteLine($"Balance        : {opBalance:C}");
            }
            else if (option == 3)
            {
                decimal amount;

                while (true)
                {
                    Console.Write("Enter The Deposit Amount: ");

                    if (decimal.TryParse(Console.ReadLine()!, out amount))
                    {
                        if (amount > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Amount must be greater than zero.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a numeric value.");
                    }
                }

                opBalance += amount;

                Console.WriteLine("Deposit Successful!");
                Console.WriteLine($"Deposited Amount: {amount}");
                Console.WriteLine($"New Balance: {opBalance:C}");
            }
            else if (option == 4)
            {
                decimal withdraw;

                while (true)
                {
                    Console.Write("Enter the Withdrawal Amount: ");

                    if (decimal.TryParse(Console.ReadLine(), out withdraw))
                    {
                        if (withdraw > 0)
                        {
                            if (withdraw <= opBalance)
                            {
                                opBalance -= withdraw;

                                Console.WriteLine("Withdraw Successful!");
                                Console.WriteLine($"Withdrawn Amount: {withdraw}");
                                Console.WriteLine($"Remaining Balance: {opBalance:C}");

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Balance!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Amount must be greater than 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
            }
            else if (option == 5)
            {
                Console.WriteLine("Thank you for using Hatton National Bank!");
                Environment.Exit(0); // ✅ Proper program exit
            }
            else
            {
                Console.WriteLine("Invalid option! Please select 1-5.");
            }
        }
    }
}
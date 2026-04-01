using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemelaATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] accounts = new BankAccount[]
            {
                new SavingsAccount("1001", "1234", 5500.50),
                new ChequeAccount("1002", "5678", 120.00),
                new CreditAccount("1003", "9999", 25000.75),
                new ChequeAccount("1004", "0000", 10.00),
                new SavingsAccount("1005", "4321", 1500.00)
            };

            //Welcome and account type
            Console.WriteLine("Welcome to Memela ATM");
            Console.WriteLine("1. Savings\n2. Cheque\n3. Credit");
            string accTypeInput = Console.ReadLine();

            Console.WriteLine("Please enter your pin: ");
            string pin = Console.ReadLine();

            bool accountFound = false;

            //Verifying account and pin
            foreach (BankAccount account in accounts)
            {
                
                if (pin == account.Pin)
                {
                   
                    bool isCorrectType = false;

                    //Verifying ifS account is correct
                    if (accTypeInput == "1" && account is SavingsAccount) isCorrectType = true;
                    else if (accTypeInput == "2" && account is ChequeAccount) isCorrectType = true;
                    else if (accTypeInput == "3" && account is CreditAccount) isCorrectType = true;

                    if (isCorrectType)
                    {
                        accountFound = true;
                        Console.WriteLine("\n--- Access Granted ---");
                        Console.WriteLine("1. Deposit\n2. Withdraw");
                        string option = Console.ReadLine();

                        // Simplified switch for demonstration
                        switch (option)
                        {
                            case "1":
                                Console.Write("Enter deposit amount: ");
                                double depAmount = double.Parse(Console.ReadLine());
                                account.Deposit(depAmount);
                                Console.WriteLine($"New Balance: R {account.Balance:N2}");
                                break;
                            case "2":
                                Console.Write("Enter withdrawal amount: ");
                                double withAmount = double.Parse(Console.ReadLine());
                                if (account.Withdraw(withAmount))
                                    Console.WriteLine($"Success! New Balance: R {account.Balance:N2}");
                                else
                                    Console.WriteLine("Insufficient funds.");
                                break;
                        }
                        break; 
                    }
                }
            }

            if (!accountFound)
            {
                Console.WriteLine("Error: Invalid PIN or Account Type selection.");
            }
        }
    }
}
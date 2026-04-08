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
            // Creating an array of different bank accounts with account number, pin and balance
            BankAccount[] accounts = new BankAccount[]
            {
                new SavingsAccount("1001", "1234", 5500.50),
                new ChequeAccount("1002", "5678", 120.00),
                new CreditAccount("1003", "9999", 25000.75),
                new ChequeAccount("1004", "0000", 10.00),
                new SavingsAccount("1005", "4321", 1500.00)
            };

            // Creating cardless withdrawal references with the amount available for withdrawal
            CardlessService[] cardlessService = new CardlessService[]
            {
                new CardlessService("REF123", 500.00),
                new CardlessService("REF456", 1500.00),
                new CardlessService("REF789", 250.00),
                new CardlessService("REF321", 750.00)
            };

            // Display ATM welcome message and allow the user to choose a service
            Console.WriteLine("Welcome to Memela ATM");
            Console.WriteLine("1. Use Card");
            Console.WriteLine("2. Cardless Service");

            // Read the user's choice
            string serviceOption = Console.ReadLine();

            // If the user selects normal ATM card service
            if (serviceOption == "1")
            {
                // Ask the user to select the type of account
                Console.WriteLine("1. Savings\n2. Cheque\n3. Credit\n");
                string accTypeInput = Console.ReadLine();

                // Ask the user to enter their PIN
                Console.WriteLine("Please enter your pin: ");
                string pin = Console.ReadLine();

                bool accountFound = false;

                // Loop through all accounts to find a matching PIN
                foreach (BankAccount account in accounts)
                {
                    if (pin == account.Pin)
                    {
                        bool isCorrectType = false;

                        // Check if the selected account type matches the actual account type
                        if (accTypeInput == "1" && account is SavingsAccount) isCorrectType = true;
                        else if (accTypeInput == "2" && account is ChequeAccount) isCorrectType = true;
                        else if (accTypeInput == "3" && account is CreditAccount) isCorrectType = true;

                        // If account type and PIN match
                        if (isCorrectType)
                        {
                            accountFound = true;

                            Console.WriteLine("\n--- Access Granted ---");

                            // Show transaction options
                            Console.WriteLine("1. Deposit\n2. Withdraw");
                            string option = Console.ReadLine();

                            // Perform the selected transaction
                            switch (option)
                            {
                                // Deposit option
                                case "1":
                                    Console.Write("Enter deposit amount: ");
                                    double depAmount = double.Parse(Console.ReadLine());

                                    // Call deposit method
                                    account.Deposit(depAmount);

                                    // Display updated balance
                                    Console.WriteLine($"New Balance: R {account.Balance:N2}");
                                    break;

                                // Withdrawal option
                                case "2":
                                    Console.Write("Enter withdrawal amount: ");
                                    double withAmount = double.Parse(Console.ReadLine());

                                    // Attempt withdrawal
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

                // If no matching account was found
                if (!accountFound)
                {
                    Console.WriteLine("Error: Invalid PIN or Account Type selection.");
                }
            }

            // If the user selects the cardless withdrawal service
            else if (serviceOption == "2")
            {
                // Ask the user to enter their cardless withdrawal reference
                Console.WriteLine("Enter your reference pin: ");
                string refPin = Console.ReadLine();

                // Loop through cardless references to find a match
                foreach (CardlessService service in cardlessService)
                {
                    if (refPin == service.Reference)
                    {
                        Console.WriteLine("\n--- Reference Found ---");

                        // Display the withdrawal amount linked to the reference
                        Console.WriteLine($"Amount to Withdraw: R {service.Amount:N2}");

                        // Ask the user to confirm the withdrawal
                        Console.Write("Confirm withdrawal? (Y/N): ");
                        string confirm = Console.ReadLine();

                        if (confirm.ToUpper() == "Y")
                        {
                            // Process withdrawal
                            if (service.Withdraw(service.Amount))
                                Console.WriteLine("Withdrawal successful! Please collect your cash.");
                            else
                                Console.WriteLine("Error processing withdrawal. Please try again.");
                        }
                        else
                        {
                            // If user cancels the transaction
                            Console.WriteLine("Withdrawal cancelled.");
                        }

                        break;
                    }
                }
            }
        }
    }
}
Memela ATM Application
Welcome to the Memela ATM Application, a console-based C# application that simulates standard Automated Teller Machine (ATM) banking operations. 
This program demonstrates Object-Oriented Programming (OOP) principles, such as inheritance and polymorphism, 
by managing various bank account types and handling cardless cash withdrawals.

Features
The application offers two primary service tracks:

1. Card-Based Services
Users can access standard banking features by specifying their account type and entering a valid PIN.

Account Types Supported: Savings, Cheque, and Credit accounts.
Secure Validation: Matches both the account type selection and PIN before granting access.
Deposits: Add funds to the account and instantly view the updated balance.
Withdrawals: Deduct funds from the account with built-in validation for insufficient funds.

2. Cardless Services
Users can withdraw predetermined cash amounts without an ATM card.
Reference Verification: Enter a unique transaction reference pin (e.g., REF123).
Secure Dispensing: Displays the authorized amount and prompts for user confirmation before successfully completing the cash rollout.

Project Structure & Architecture

The application relies on a modular OOP design. Below is an overview of how the backend classes interact:

BankAccount (Base Class): An abstract or parent class handling shared logic like AccountNumber, Pin, Balance, and default Deposit() / Withdraw() methods.

Derived Account Classes:

SavingsAccount: Tailored for savings logic.
ChequeAccount: Tailored for everyday transactional logic.
CreditAccount: Configured to handle credit limits and balances.

CardlessService: A dedicated class that manages independent, reference-linked cash vouchers and their withdrawal states.

Sample Mock Data
The application boots up with pre-loaded mock data to simulate an active banking environment:

Registered Accounts
Account Number  Account Type  Default PIN  Initial Balance
1001            Savings        1234        R 5,500.50
1002            Cheque         5678        R 120.00
1003            Credit         9999        R 25,000.75
1004            Cheque         0000        R 10.00
1005            Savings        4321        R 1,500.00

Cardless Vouchers
Reference: REF123 | Amount: R 500.00
Reference: REF456 | Amount: R 1,500.00
Reference: REF789 | Amount: R 250.00
Reference: REF321 | Amount: R 750.00

Running the Application

Clone or Download the source code files to your local machine.
Ensure all supplementary class files (BankAccount.cs, SavingsAccount.cs, etc.) are in the same project directory.
Open your terminal/command prompt in the project root folder and execute:
dotnet run

Example Usage
Card-Based Withdrawal Scenario:

Welcome to Memela ATM
1. Use Card
2. Cardless Service
1

1. Savings
2. Cheque
3. Credit

1
Please enter your pin: 
1234

--- Access Granted ---
1. Deposit
2. Withdraw
2
Enter withdrawal amount: 500
Success! New Balance: R 5,000.50

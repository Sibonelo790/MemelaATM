using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemelaATM
{
    public class BankAccount
    {
        //Properties
        public string AccountNumber { get; set; }
        public string Pin { get; set; }
        public double Balance { get;  set; }

        //Constructor to set up a new account
        public BankAccount(string accountNumber, string pin, double balance)
        {
            AccountNumber = accountNumber;
            Pin = pin;
            Balance = balance;
        }

        //Method to deposit money
        public void Deposit(double amount)
        {
            if(amount > 0)
            {
                Balance += amount;
            }
        }

        //Method to withdraw money
        public virtual bool Withdraw(double amount)
        {
            if(amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

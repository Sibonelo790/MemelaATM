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
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Pin { get; set; }
        public double Balance { get; private set; }

        //Constructor to set up a new account
        public BankAccount(string name, string accountNumber, string pin, double balance)
        {
            Name = name;
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
        public virtual bool Withhdraw(double amount)
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

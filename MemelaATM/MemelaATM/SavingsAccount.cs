using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemelaATM
{
    public class SavingsAccount : BankAccount
    {
        public double MinBalance { get; } = 25.00;

        public SavingsAccount(string accountNumber, string pin, double balance)
            : base(accountNumber, pin, balance)
        {
        }

        public override bool Withdraw(double amount)
        {
            //Cannot withdraw if it leaves less than R25
            if (Balance - amount < MinBalance)
            {
                Console.WriteLine($"Error: A minimum balance of R{MinBalance} is required.");
                return false;
            }
            return base.Withhdraw(amount);
    }
}

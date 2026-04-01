using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemelaATM
{
    public class CreditAccount : BankAccount
    {
        //Properties
        public double AnnualInterestRate { get; set; } = 0.24;
        public double CashAdvanceFeePercent { get; set; }  = 0.03;
        public double MinimumFee { get; set; }  = 60;

        public CreditAccount(string accountNumber, string pin, double balance) 
            : base(accountNumber, pin, balance)
        {
        }

        public override bool Withdraw(double amount)
        {
            //Check if amount is valid banknote (R10, R20, R50, R100)
            if (amount % 10 != 0 || amount <= 0)
            {
                Console.WriteLine("Error: ATM only dispense notes (R10, R20, R50, R100)");
                return false;
            }

            // 2. Calculate the Cash Advance Fee
            double percentageFee = amount * CashAdvanceFeePercent;
            double actualFee = Math.Max(percentageFee, MinimumFee);

            // 3. The total deduction to the account
            double totalDeduction = amount + actualFee;

            // 4. Check if there is enough credit/balance
            // Assuming 'Balance' represents the current credit limit or available funds
            if (totalDeduction > Balance)
            {
                Console.WriteLine("Error: Insufficient funds (including withdrawal fees).");
                return false;
            }

            // 5. Update the balance and confirm success
            Balance -= totalDeduction;
            Console.WriteLine($"Successfully withdrawn: R{amount:N2}");
            Console.WriteLine($"Transaction Fee applied: R{actualFee:N2}");
            return true;
        }
    }
}

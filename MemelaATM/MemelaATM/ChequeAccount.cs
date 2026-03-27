using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemelaATM
{
    public class ChequeAccount : BankAccount
    {
        public double DailyLimit { get; set; } = 5000.00:
        public double AmountWithdrawnToday { get; set; } = 0;
        public double OverdraftLimit { get; set; } = 2000.00;  //Allowed to go to -R2000

        public ChequeAccount(string name, int id, string pin, double balance)
            :base(name, id, pin, balance)
        {

        }

        public override bool Withdraw(double amount)
        {
            //Check if amount is valid banknote (R10, R20, R50, R100)
            if(amount % 10 != 0 || amount <= 0)
            {
                Console.WriteLine("Error: ATM only dispense notes (R10, R20, R50, R100");\
                return false;
            }

            //2. Check against Daily limit
            if(AmountWithdrawnToday + amount > DailyLimit)
            {
                Console.WriteLine($"Limited Exceeded! Remaining daily limit: R{DailyLimit - AmountWithdrawnToday}");
                return false;
            }

            //Calculate fee
            double fee = Math.Ceiling(amount / 1000) * 10;
            double totalDeduction = amount + fee;

            //Check if there is enough "room" to withdraw considering overdraft
            if(totalDeduction <= (Balance + OverdraftLimit))
            {
                Balance -= totalDeduction;
                AmountWithdrawnToday += amount;

                Console.WriteLine($"Success! Withdrew: R{amount} (Fee: R{fee})");
                Console.WriteLine($"New Balance: R{Balance}");
                return true;
            }

            Console.WriteLine("Transaction Declined: Insufficient funds (including overdraft).");
            return false;
        }

        
    }
}

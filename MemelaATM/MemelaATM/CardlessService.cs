using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemelaATM
{
    public class CardlessService
    {
        public string Reference { get; set; }
        public double Amount { get; set; }

        public CardlessService(string reference, double amount) 
        {
            Reference = reference;
            Amount = amount;
        }



    }
}

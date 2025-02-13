using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BankAction
    {
        public string AtmAction { get; set; }
        public int Amount { get; set; }
        public DateTime TimeStamp { get; set; }

        public BankAction(DateTime timeStamp, string atmAction, int amount)
        {
            TimeStamp = timeStamp;    
            AtmAction= atmAction;
            Amount = amount;
        }

    }

    

}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

//Probably should be an interface ,TODO 

namespace OptionPricing
{
    public abstract class FinancialInstrument
    {

        public abstract double Npv();
        
        public bool IsExpired(Date expiry)
        {
            return false;

        }

    }
}

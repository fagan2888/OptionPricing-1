﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptionPricing
{
    public enum Exercise
    {
        American,
        European,
        Barrier,
        Asian
    }

    public enum Type
    {
        Put,
        Call
    }

    public enum Month
    {
       /* January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,*/
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12
    }

    public enum Weekday
    {
        /*Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,
        Saturday = 7,*/
        Sun = 1,
        Mon = 2,
        Tue = 3,
        Wed = 4,
        Thu = 5,
        Fri = 6,
        Sat = 7
    }


    public enum TranformType
    {
        BoxMuller,
        InverseCdf
    }

    public enum ValuationMethod
    {
        MonteCarlo,
        Analytic,
        FiniteDifference
    }

    public enum Currencies
    {
        USD,
        GBP,
        EUR,
        CHF,
        JPY,
        AUD
    }

}

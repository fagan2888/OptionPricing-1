using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace OptionPricing
{
    using Year = Int32;

    public class Date
    {
        private Month _month;
        private Weekday _day;
        private Year _year;

        public Date()
        {
             this._month = Month.Jan;
            this._day = Weekday.Mon;
            this._year = 2000;
        }

        public Date(Weekday day, Month month, Year year)
        {
            this._month = month;
            this._day = day;
            this._year = year;
          
        }

    }
}

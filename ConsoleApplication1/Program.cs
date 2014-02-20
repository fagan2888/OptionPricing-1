using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using OptionPricing;

namespace OptionPricer
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = new Date(Weekday.Fri, Month.Jul, 1990);
            try
            {
                var myOption = new VanillaOption();
                Console.WriteLine(myOption.Npv());
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("Some {0}", ex.Message.ToString());
            }
           
            
            
            Console.ReadLine();

        }
    }

   
}

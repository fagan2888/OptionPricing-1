using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptionPricing
{
    public abstract class Option:FinancialInstrument
    {
       // protected OptionType Type;

        public Exercise Type { get; protected set; }
        public double Strike { get; protected set; }
        public double Spot { get; protected set; }
        public double Dividend { get; protected set; }
        public double RiskFreeRate { get; protected set; }
        public double Ttm { get; protected set; }
        public double Vol { get; protected set; }
        public Date ExpDate { get; protected set; }       

        protected Option()
        {
            this.Type = Exercise.American;
            this.Strike = 0.0;
            this.Spot = 0.0;
            this.Dividend = 0.0;
            this.RiskFreeRate = 0.0;
            this.Ttm = 0.0;
            this.Vol = 0.0;
            this.ExpDate = new Date(Weekday.Mon, Month.Jan, 2000);
        }

        public abstract double Delta();
        public abstract double Vega();
        public abstract double Theta();
        public abstract double Rho();
        public abstract double Gamma();

        protected Option(Exercise type, double strike, double spot, double dividend, double riskfreerate, double ttm, double vol, Date expiry)
        {
            InitOption(type, strike, spot, dividend, riskfreerate, ttm, vol, expiry);
        }


        protected void InitOption(Exercise type, double strike, double spot, double dividend, double riskfreerate,
            double ttm, double vol, Date expiry)
        {
            this.Type = type;
            this.Strike = strike;
            this.Spot = spot;
            this.Dividend = dividend;
            this.RiskFreeRate = riskfreerate;
            this.Ttm = ttm;
            this.Vol = vol;
            this.ExpDate = expiry;
        }

        
    }
}

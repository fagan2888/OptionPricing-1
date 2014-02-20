using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptionPricing
{
    sealed public class FxOption:VanillaOption
    {

        private double _npv ;
        private double _crossriskfreerate;

        public override double Npv()
        {

            return _npv;
        }

        public double Npv(ValuationMethod method)
        {

            return _npv;
        }

        public FxOption() : base()
        {
            _crossriskfreerate = 0.0;
        }

        private FxOption(OptionType type, double strike, double spot, double dividend, double riskfreerate,
            double ttm, double vol, Date date, double crossriskfreerate) : base (type, strike, spot, dividend, riskfreerate, ttm, vol, date)
        {
            _crossriskfreerate = crossriskfreerate;
            _npv = 0.0;
        }

        private void GarmanKohlagen()
        {

            _npv = 2.1;
            
        }

        public override double Delta()
        {
            throw new NotImplementedException();
        }

        public override double Vega()
        {
            throw new NotImplementedException();
        }

        public override double Theta()
        {
            throw new NotImplementedException();
        }

        public override double Rho()
        {
            throw new NotImplementedException();
        }

        public override double Lambda()
        {
            throw new NotImplementedException();
        }
    }
}

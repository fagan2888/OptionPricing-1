using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace OptionPricing
{
    public sealed class VanillaOption : Option
    {

        private double _npv, _delta, _gamma, _rho, _theta, _vega;
        private double _dividend, _d1, _d2, _b;
        private readonly ValuationMethod _method;
        private readonly Type _type;

        public override double Npv()
        {
            switch (_method)
            {
                case ValuationMethod.Analytic:
                    _b = RiskFreeRate - Dividend;
                    _d1 = System.Math.Log(Spot / Strike) + (_b + Vol * Vol * 0.5) * Ttm;
                    _d1 = _d1 / Vol * Ttm;
                    _d2 = _d1 - Vol * System.Math.Sqrt(Ttm);

                    switch (_type)
                    {
                        case OptionPricing.Type.Call:
                            _npv = Spot * System.Math.Exp((_b - RiskFreeRate) * Ttm) * Math.Cdf(_d1) -
                                   Strike * System.Math.Exp(-RiskFreeRate * Ttm) * Math.Cdf(_d2);
                            break;
                        case OptionPricing.Type.Put:
                            _npv = Strike * System.Math.Exp(-RiskFreeRate * Ttm) * Math.Cdf(-_d2) - Spot * System.Math.Exp((_b - RiskFreeRate) * Ttm) * Math.Cdf(-_d1);
                            break;
                    }
                    break;
                case ValuationMethod.FiniteDifference:
                    throw new NotImplementedException("Finite Difference Method Not Currently Implemented");
                case ValuationMethod.MonteCarlo:
                    throw new NotImplementedException("Monte Carlo Method Not Currently Implemented");
                default:
                    throw new NotImplementedException("Default Method Not Currently Implemented");
            }

            return _npv;

        }

        public VanillaOption()
            : base()
        {
            _type = OptionPricing.Type.Call;
            _method = ValuationMethod.Analytic;
            _npv = 0.0;
            _dividend = 0.0;
        }

        public VanillaOption(Exercise extype, double strike, double spot, double dividend, double riskfreerate,
            double ttm, double vol, Date date, ValuationMethod method, Type type)
            : base(extype, strike, spot, dividend, riskfreerate, ttm, vol, date)
        {
            _type = type;
            _method = method;
            _dividend = dividend;
            _npv = 0.0;
        }

        public override double Delta()
        {
            switch (_method)
            {
                case ValuationMethod.Analytic:
                    _delta = System.Math.Exp((_b - RiskFreeRate) * Ttm) * Math.Cdf(_d1);
                    break;
                case ValuationMethod.FiniteDifference:
                    throw new NotImplementedException("Finite Difference Method Not Currently Implemented");
                case ValuationMethod.MonteCarlo:
                    throw new NotImplementedException("Monte Carlo Method Not Currently Implemented");
                default:
                    throw new NotImplementedException("Default Method Not Currently Implemented");

            }

            return _delta;
        }

        public override double Vega()
        {
            switch (_method)
            {
                case ValuationMethod.Analytic:

                    _vega = Strike * System.Math.Exp((_b - RiskFreeRate) * Ttm) + Math.NormalDist(_d1) * System.Math.Sqrt(Ttm);

                    break;
                case ValuationMethod.FiniteDifference:
                    throw new NotImplementedException("Finite Difference Method Not Currently Implemented");
                case ValuationMethod.MonteCarlo:
                    throw new NotImplementedException("Monte Carlo Method Not Currently Implemented");
                default:
                    throw new NotImplementedException("Default Method Not Currently Implemented");

            }

            return _vega;
        }

        public override double Theta()
        {
            switch (_method)
            {
                case ValuationMethod.Analytic:

                    switch (_type)
                    {
                        case OptionPricing.Type.Call:
                            _theta = - (Strike * Vol * System.Math.Exp((_b - RiskFreeRate)) * Ttm * Math.NormalDist(_d1) / 2.0 * System.Math.Sqrt(Ttm)) 
                                - (_b - RiskFreeRate) * Strike * System.Math.Exp((_b - RiskFreeRate) * Ttm) * Math.Cdf(_d1) - RiskFreeRate * Strike * System.Math.Exp(-RiskFreeRate * Ttm) * Math.Cdf(_d2); 
                            break;
                        case OptionPricing.Type.Put:
                            _theta = System.Math.Exp((_b - RiskFreeRate) * Ttm) * (Math.Cdf(_d1) - 1);
                            break;
                    }
                    break;
                case ValuationMethod.FiniteDifference:
                    throw new NotImplementedException("Finite Difference Method Not Currently Implemented");
                case ValuationMethod.MonteCarlo:
                    throw new NotImplementedException("Monte Carlo Method Not Currently Implemented");
                default:
                    throw new NotImplementedException("Default Method Not Currently Implemented");

            }

            return _delta;
        }

        public override double Rho()
        {
            switch (_method)
            {
                case ValuationMethod.Analytic:

                    switch (_type)
                    {
                        case OptionPricing.Type.Call:
                           // _delta = System.Math.Exp((_b - RiskFreeRate) * Ttm) * Math.Cdf(_d1);
                            throw new NotImplementedException("Rho Calculation Not Currently Implemented");
                        case OptionPricing.Type.Put:
                           // _delta = System.Math.Exp((_b - RiskFreeRate) * Ttm) * (Math.Cdf(_d1) - 1);
                            throw new NotImplementedException("Rho Calculation Not Currently Implemented");
                            break;
                    }
                    break;
                case ValuationMethod.FiniteDifference:
                    throw new NotImplementedException("Finite Difference Method Not Currently Implemented");
                case ValuationMethod.MonteCarlo:
                    throw new NotImplementedException("Monte Carlo Method Not Currently Implemented");
                default:
                    throw new NotImplementedException("Default Method Not Currently Implemented");

            }

            return _delta;
        }

        public override double Gamma()
        {
            switch (_method)
            {
                case ValuationMethod.Analytic:

                    _gamma = Math.NormalDist(_d1) * System.Math.Exp((_b - RiskFreeRate) * Ttm) / Spot * Vol * System.Math.Sqrt(Ttm);

                    break;
                case ValuationMethod.FiniteDifference:
                    throw new NotImplementedException("Finite Difference Method Not Currently Implemented");
                case ValuationMethod.MonteCarlo:
                    throw new NotImplementedException("Monte Carlo Method Not Currently Implemented");
                default:
                    throw new NotImplementedException("Default Method Not Currently Implemented");

            }

            return _gamma;
        }
    }

}
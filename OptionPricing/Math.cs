using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OptionPricing
{
    static public class Math
    {
        static public double Erf(double x)
        {
            // constants
            const double a1 = 0.254829592;
            const double a2 = -0.284496736;
            const double a3 = 1.421413741;
            const double a4 = -1.453152027;
            const double a5 = 1.061405429;
            const double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = System.Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * System.Math.Exp(-x * x);

            return sign * y;
        }

        static public double Erfc(double x)
        {
            return 1 - Erf(x);
        }

        static public Tuple<double, double> BoxMuller(double mean, double variance)
        {
            var rnd = new Random(777);

            double x1 = rnd.NextDouble();
            double x2 = rnd.NextDouble();
            double y1, y2;
            double w;
            do
            {
                x1 = 2.0 * x1 - 1.0;
                x2 = 2.0 * x2 - 1.0;
                w = x1 * x1 + x2 * x2;

            } while (w >= 1.0);

            w = System.Math.Sqrt((-2.0 * System.Math.Log(w)) / w);
            y1 = x1 * w;
            y2 = x2 * w;
            var pair = new Tuple<double, double>(variance * y1 + mean, variance * y2 + mean);
            return pair;
        }

        static public double Cdf()
        {
            var rnd = new Random(777);
            double x = rnd.NextDouble();
            return 0.5 + 0.5 * Erf(x / System.Math.Sqrt(2.0));
        }

        static public double Cdf(double x)
        {
            return 0.5 + 0.5 * Erf(x / System.Math.Sqrt(2.0));
        }

        static public double NormalDist(double x)
        {
            return (1.0 / System.Math.Sqrt(2.0 * System.Math.PI)) * System.Math.Exp(-x * x * 0.5);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OptionPricing
{
    public partial class Transforms
    {
        private TranformType _type;
        private double _mean, _variance;

        public Transforms(TranformType type, double mean, double variance)
        {
            _type = type;
            _mean = mean;
            _variance = variance;
        }

        public Tuple<double, double> Transform()
        {
            switch (_type)
            {
                case TranformType.BoxMuller:
                    var rnd = new Random(777);
                    var pair = new Tuple<double, double>(0.0, 0.0);

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

                    w = Math.Sqrt((-2.0 * Math.Log(w)) / w);
                    y1 = x1 * w;
                    y2 = x2 * w;

                    pair.Item1 = _variance * y1 + _mean;
                    pair.Item2 = _variance * y2 + _mean;

                    break;
                case TranformType.InverseCdf:
                    throw new NotImplementedException();
                    break;
            }

        }

    }
}

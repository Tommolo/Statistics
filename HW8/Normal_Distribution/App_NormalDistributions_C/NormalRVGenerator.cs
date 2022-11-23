using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_NormalDistributions_C
{
    internal class NormalRVGenerator
    {
        Random r_module;
        Random r_angle;

        double mean;
        double variance;

        double mse;

        public NormalRVGenerator(double m, double v)
        {
            r_module = new Random();
            r_angle = new Random();

            if (m >= 0) mean = m;
            else mean = 0;

            if (v > 0) variance = v;
            else variance = 1;

            mse = Math.Sqrt(variance);
        }

        public NormalRVGenerator()
        {
            r_module = new Random();
            r_angle = new Random();

            mean = 0;
            variance = 1;

            mse = Math.Sqrt(variance);
        }

        public (double, double) getNewPair()
        {
            double r = Math.Sqrt(-2*Math.Log(r_module.NextDouble()));
            double angle = r_angle.NextDouble() * 2 * Math.PI;

            double x = r * Math.Cos(angle) * mse + mean;
            double y = r * Math.Sin(angle) * mse + mean;

            return (x, y);
        }
    }
}

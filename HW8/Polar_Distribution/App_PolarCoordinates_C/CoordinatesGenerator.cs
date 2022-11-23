using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_PolarCoordinates_C
{


    internal class CoordinatesGenerator
    {

        Random r_module;
        Random r_angle;

        int radius;
        
        public CoordinatesGenerator(int r)
        {
            r_module = new Random();
            r_angle = new Random();

            radius = r;
        }

        public (double, double) getNewPair()
        {
            double r = r_module.NextDouble()*radius;
            double angle = r_angle.NextDouble()*2*Math.PI;

            double x = r * Math.Cos(angle);
            double y = r * Math.Sin(angle);

            return (x, y);
        }
    }
}

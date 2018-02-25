using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TP_2
{
    class Parallelogram : Quadrilateral
    {
        public Parallelogram()
        {

        }

        public static Point CalculateFourthPoint(Point p0, Point p1, Point p2)
        {
            return new Point(-p1.X + p0.X + p2.X, -p1.Y + p0.Y + p2.Y);
        }
    }
}

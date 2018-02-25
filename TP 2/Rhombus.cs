using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TP_2
{
    class Rhombus : Parallelogram
    {
        public static Point ConstraintThirdPoint(Point p0, Point p1, Point p2)
        {
            double l01 = Math.Sqrt(Math.Pow(p1.X - p0.X, 2) + Math.Pow(p1.Y - p0.Y, 2));
            double l02 = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));

            return new Point(p1.X + (p2.X - p1.X) * l01/l02, p1.Y + (p2.Y - p1.Y) * l01/l02);
        }
    }
}

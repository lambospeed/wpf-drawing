using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TP_2
{
    class RhombusTool : ParallelogramTool
    {
        protected override Quadrilateral CreateQuadrilateral()
        {
            return new Rhombus();
        }

        protected override Point ConstrainThirdPoint(Point point1, Point point2, Point point3)
        {
            return Rhombus.ConstraintThirdPoint(point1, point2, point3);
        }

      
    }
}

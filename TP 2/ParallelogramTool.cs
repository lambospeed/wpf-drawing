using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TP_2
{
    class ParallelogramTool : QuadTool
    {
        protected override void ThirdPoint(QuadDocument document, QuadCanvas canvas, Point point)
        {
            base.ThirdPoint(document, canvas, point);
            FourthPoint(document, canvas, Parallelogram.CalculateFourthPoint(quadrilateral.Points[0], quadrilateral.Points[1], quadrilateral.Points[2]));
        }

    }
}

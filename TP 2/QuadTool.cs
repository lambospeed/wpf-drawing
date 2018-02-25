using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TP_2
{
    public class QuadTool : Tool
    {
        protected Quadrilateral quadrilateral;

        public override void Deactivate(QuadDocument document, QuadCanvas canvas)
        {
            base.Deactivate(document, canvas);
            if (quadrilateral != null)
            {
                document.Quads.Remove(quadrilateral);
            }
        }

        public override void MouseLeftButtonUp(QuadDocument document, QuadCanvas canvas, MouseButtonEventArgs e)
        {
            if (quadrilateral == null)
                FirstPoint(document, canvas, e.GetPosition(canvas));
            else
            {
                switch (quadrilateral.Points.Count - 1){
                    case 1:
                        SecondPoint(document, canvas, e.GetPosition(canvas));
                        break;
                    case 2:
                        ThirdPoint(document, canvas, e.GetPosition(canvas));
                        break;
                    case 3:
                        FourthPoint(document, canvas, e.GetPosition(canvas));
                        break;
                }
            }
                   
        }
        protected virtual void FirstPoint(QuadDocument document, QuadCanvas canvas, Point point)
        {
            quadrilateral = CreateQuadrilateral();
            quadrilateral.Points.Add(point);
            quadrilateral.Points.Add(point);
            document.Quads.Add(quadrilateral);
        }

        protected virtual void SecondPoint(QuadDocument document, QuadCanvas canvas, Point point)
        {
            quadrilateral.Points.Add(point);
        }
 
        protected virtual void ThirdPoint(QuadDocument document, QuadCanvas canvas, Point point)
        {
            Point thirdPoint = ConstrainThirdPoint(
                quadrilateral.Points[0],
                quadrilateral.Points[1],
                point);

            quadrilateral.Points.Add(thirdPoint);
        }

        protected virtual void FourthPoint(QuadDocument document, QuadCanvas canvas, Point point)
        {
            quadrilateral.Points.Add(point);
            quadrilateral = null;
        }
        protected virtual Quadrilateral CreateQuadrilateral()
        {
            return new Quadrilateral();
        }

        protected virtual Point ConstrainThirdPoint(Point point1, Point point2, Point point3)
        {
            return point3;
        }

        public override void MouseMove(QuadDocument document, QuadCanvas canvas, MouseEventArgs e)
        {
            if (quadrilateral != null)
            {
                Point currentPoint = e.GetPosition(canvas);
                if (quadrilateral.Points.Count == 3)
                {
                    currentPoint = ConstrainThirdPoint(quadrilateral.Points[0],
                        quadrilateral.Points[1],
                        currentPoint);
                }
                if (quadrilateral.Points[quadrilateral.Points.Count -1] != currentPoint)
                {
                    quadrilateral.Points[quadrilateral.Points.Count - 1] = currentPoint;
                }
            }
        }


        public override Cursor GetCursor()
        {
            return Cursors.Cross;
        }
    }
}

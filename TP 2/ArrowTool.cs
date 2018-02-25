using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TP_2
{
    class ArrowTool : Tool
    {
        private Point startPoint;
        private bool inMove;

        public override void MouseLeftButtonDown(QuadDocument document, QuadCanvas canvas, System.Windows.Input.MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(canvas);
            QuadCanvasItem item = canvas.GetItemHit(startPoint);
            bool shifyKeyPressed = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);

            if (item != null)
            {
                if (shifyKeyPressed)
                {
                    canvas.SelectedItems.Add(item.Quadrilateral);
                }
                else
                {
                    canvas.SelectedItem = item.Quadrilateral;
                }
            }
            else
            {
                if (!shifyKeyPressed)
                {
                    canvas.SelectedItem = null;
                }
                inMove = false;
            }
        }
        public override void MouseLeftButtonUp(QuadDocument document, QuadCanvas canvas, MouseButtonEventArgs e)
        {
            inMove = false;
        }

        public override void MouseMove(QuadDocument document, QuadCanvas canvas, MouseEventArgs e)
        {
            if (inMove)
            {

            }
        }

        public override Cursor GetCursor()
        {
            return Cursors.Arrow;
        }
    }
}

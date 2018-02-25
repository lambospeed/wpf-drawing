using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TP_2
{
    public abstract class Tool
    {
        public virtual void Activate(QuadDocument document, QuadCanvas canvas)
        {

        }

        public virtual void Deactivate(QuadDocument document, QuadCanvas canvas)
        {

        }

        public abstract void MouseLeftButtonUp(QuadDocument document, QuadCanvas canvas, MouseButtonEventArgs e);
        public virtual void MouseLeftButtonDown(QuadDocument document, QuadCanvas quadCanvas, MouseButtonEventArgs e)
        {

        }
        public abstract void MouseMove(QuadDocument document, QuadCanvas canvas, MouseEventArgs e);

        public virtual void MouseLeave(QuadDocument document, QuadCanvas canvas, MouseEventArgs e)
        {
            canvas.Cursor = Cursors.Arrow;
        }



        public virtual void MouseEnter(QuadDocument document, QuadCanvas canvas, MouseEventArgs e)
        {
            canvas.Cursor = GetCursor();
       
        }

        public abstract Cursor GetCursor();


    }
}

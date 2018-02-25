using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace TP_2
{
    public class QuadCanvas : MultiSelector
    {
        public QuadCanvas()
        {
            FrameworkElementFactory panel = new FrameworkElementFactory(typeof(Canvas));
            this.ItemsPanel = new ItemsPanelTemplate(panel);

            this.CanSelectMultipleItems = true;
            this.SelectionChanged += QuadCanvas_SelectionChanged;
                                     //new SelectionChangedEventHandler(QuadCanvas_SelectionChanged)
        }

        void QuadCanvas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Quadrilateral q in e.AddedItems)
            {
                QuadCanvasItem item = QuadToCanvasItem(q);
                if (item != null)
                {
                    item.IsSelected = true;
                }
            }

            foreach (Quadrilateral q in e.RemovedItems)
            {
                QuadCanvasItem item = QuadToCanvasItem(q);
                if (item != null)
                {
                    item.IsSelected = false;
                }
            }
        }

        private QuadCanvasItem QuadToCanvasItem(Quadrilateral quadrilateral)
        {
            DependencyObject container = this.ItemContainerGenerator.ContainerFromItem(quadrilateral);

            if (container == null)
                return null;

            for (int index = 0; index < VisualTreeHelper.GetChildrenCount(container); index++)
            {
                DependencyObject e = VisualTreeHelper.GetChild(container, index);
                if (e is QuadCanvasItem)
                {
                    if( (e as QuadCanvasItem).Quadrilateral == quadrilateral){
                        return e as QuadCanvasItem;
                    }
                }
            }
            return null;
        }

        public QuadCanvasItem GetItemHit(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            DependencyObject obj = hitResult.VisualHit;
            if (obj != null)
            {
                DependencyObject container = this.ContainerFromElement(obj);
                if (container != null)
                {
                    return VisualTreeHelper.GetChild(container, 0) as QuadCanvasItem;
                }
            }
            return null;
        }
    }
}

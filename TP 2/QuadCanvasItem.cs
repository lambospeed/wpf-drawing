using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TP_2
{
    public class QuadCanvasItem : Canvas
    {
        public static readonly DependencyProperty QuadrilateralProperty;

        public static readonly DependencyProperty IsSelectedProperty;

        public QuadCanvasItem()
        {

        }

        static QuadCanvasItem()
        {
            QuadrilateralProperty = DependencyProperty.Register("Quadrilateral", 
                typeof(Quadrilateral), 
                typeof(QuadCanvasItem), 
                new PropertyMetadata(new PropertyChangedCallback(OnQuadrilateralChanged)));

            IsSelectedProperty = MultiSelector.IsSelectedProperty.AddOwner(
                typeof(QuadCanvasItem),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsSelectedChanged)));
        }

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            QuadCanvasItem canvasItem = d as QuadCanvasItem;
            canvasItem.UpdateView();
        }

        private static void OnQuadrilateralChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            QuadCanvasItem canvasItem = d as QuadCanvasItem;
            canvasItem.Quadrilateral_Changed(e);
        }

        private void Quadrilateral_Changed(DependencyPropertyChangedEventArgs e)
        {
            Quadrilateral.Points.CollectionChanged += new NotifyCollectionChangedEventHandler(Points_CollectionChanged);

            //Quadrilateral.Points.CollectionChanged += Points_CollectionChanged;

            UpdateView();
        }

        void Points_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateView();
        }


        public Quadrilateral Quadrilateral 
        { 
            get 
            {
                return (Quadrilateral)GetValue(QuadrilateralProperty);
            }
            set
            {
                SetValue(QuadrilateralProperty, value);
            }
        }

        public Boolean IsSelected 
        { 
            get
            { 
                return (bool) GetValue(IsSelectedProperty);
            }
            set 
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        private Polyline CreatePolyline()
        {
            Polyline polyline = new Polyline();
            polyline.Stroke = Brushes.Black;
            polyline.StrokeThickness = 2;
            polyline.Points = new PointCollection(Quadrilateral.Points);
            return polyline;
        }

        private Polygon CreatePolygon()
        {
            Polygon polygon = new Polygon();
            polygon.Stroke = Brushes.Black;
            polygon.StrokeThickness = 2;
            polygon.Points = new PointCollection(Quadrilateral.Points);
            return polygon;
        }

        private void UpdateView()
        {
            if (IsSelected)
            {
                Children.Clear();
                Children.Add(CreatePolygon());

                foreach (Point p in Quadrilateral.Points)
                {
                    Rectangle r = new Rectangle();
                    r.Fill = Brushes.Black;
                    Canvas.SetLeft(r, p.X - 4);
                    Canvas.SetTop(r, p.Y - 4);
                    r.Width = 8;
                    r.Height = 8;
                    Children.Add(r);
                }
            }
            else
            {
                Children.Clear();
                if (Quadrilateral.Points.Count < 4)
                {
                    Children.Add(CreatePolyline());
                }
                else
                {
                    Children.Add(CreatePolygon());
                }
            }
        }
    }
}

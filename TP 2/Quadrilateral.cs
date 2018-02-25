using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TP_2
{
    public class Quadrilateral
    {
        private ObservableCollection<Point> points;

        public ObservableCollection<Point> Points 
        { 
            get { return points; } 
        }

        public Quadrilateral()
        {
            points = new ObservableCollection<Point>();
        }
    }
}

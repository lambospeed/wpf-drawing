using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2
{
    public class QuadDocument
    {
        private ObservableCollection<Quadrilateral> quads;
        public ObservableCollection<Quadrilateral> Quads 
        { 
            get 
            { 
                return quads; 
            } 
        }

        public QuadDocument()
        {
            quads = new ObservableCollection<Quadrilateral>();
        }
    }
}

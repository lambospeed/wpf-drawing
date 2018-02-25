using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TP_2
{
    public static class CustomCommands
    {
        static RoutedUICommand exit;

        static CustomCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.Q, ModifierKeys.Control, "Ctrl+Q"));
            exit = new RoutedUICommand("Quitter", "Quit", typeof(CustomCommands), inputs);

        }
        public static RoutedUICommand Exit { 
            get {
                return(exit);
            }
        }
    }
}

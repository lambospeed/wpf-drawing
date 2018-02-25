using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QuadDocument document;
        private QuadTool quadTool;
        private Tool currentTool;

        private ParallelogramTool parallelogramTool;
        private RhombusTool rhombusTool;
        private ArrowTool arrowTool;

        public MainWindow()
        {
            

            document = new QuadDocument();
            quadTool = new QuadTool();
            currentTool = new QuadTool();

            parallelogramTool = new ParallelogramTool();
            rhombusTool = new RhombusTool();
            arrowTool = new ArrowTool();

            InitializeComponent();

            quadCanvas.ItemsSource = document.Quads;
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public Tool CurrentTool 
        {
            get
            {
                return currentTool;
            }
            set
            {
                if (currentTool != null)
                    currentTool.Deactivate(document, quadCanvas);

                currentTool = value;
                currentTool.Activate(document, quadCanvas);
            }
        }

        private void quadToolButton_Checked(object sender, RoutedEventArgs e)
        {
            CurrentTool = quadTool;
        }

        private void quadCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CurrentTool.MouseLeftButtonUp(document, quadCanvas, e);
        }

        private void quadCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentTool.MouseLeftButtonDown(document, quadCanvas, e);
        }

        private void quadCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentTool.MouseMove(document, quadCanvas, e);
        }

        private void quadCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            CurrentTool.MouseLeave(document, quadCanvas, e);
        }

        private void quadCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            CurrentTool.MouseEnter(document, quadCanvas, e);
        }

        private void parallelogramToolButton_Checked(object sender, RoutedEventArgs e)
        {
            CurrentTool = parallelogramTool;
        }

        private void rhombusToolButton_Checked(object sender, RoutedEventArgs e)
        {
            CurrentTool = rhombusTool;
        }

        private void selectToolButton_Checked(object sender, RoutedEventArgs e)
        {
            CurrentTool = arrowTool;
        }
    }
}

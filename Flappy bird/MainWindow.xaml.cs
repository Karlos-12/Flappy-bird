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
using System.Windows.Threading;

namespace Flappy_bird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int birdy = 400;

        List<int> bariers = new List<int>();

        public MainWindow()
        {
            DispatcherTimer main = new DispatcherTimer();
            main.Interval = new TimeSpan(0, 0, 0, 0, 1);
            main.Tick += new EventHandler(mainloop);
            main.Start();
            InitializeComponent();
        }

        public void mainloop(object sender, EventArgs e)
        {
            birdy -= 10;
            if(birdy < 0)
            {
                ende();
            }
            else if(up == true)
            {
                birdy += 25;
            }
             
            

            draw();
        }

        public void draw()
        {
            Ellipse bird = new Ellipse
            {
                Width = 50,
                Height = 50,
                Fill = new SolidColorBrush(Colors.Red)
            };

            field.Children.Clear();
            field.Children.Add(bird);
            Canvas.SetLeft(bird, 800);
            Canvas.SetBottom(bird, birdy -25);
        }

        public void ende()
        {
            MessageBox.Show("no, posral jsi to, zase....");
            
        }

        bool up = false;
        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.W)
            {
                up = true;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.W)
            {
                up = false;
            }
        }
    }
}

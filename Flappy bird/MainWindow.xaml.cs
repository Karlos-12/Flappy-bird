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
        List<int> barsl = new List<int>();

        public MainWindow()
        {
            startec();
            DispatcherTimer main = new DispatcherTimer();
            main.Interval = new TimeSpan(0, 0, 0, 0, 1);
            main.Tick += new EventHandler(mainloop);
            main.Start();
            InitializeComponent();
            
        }

        public void startec()
        {
            Random ran = new Random();

            bariers.Clear();
            barsl.Clear();
            int x = 0;
            do
            {
                x++;
                bariers.Add(ran.Next(100, 500)); 
            }
            while (x<8);

            barsl.Add(0);
            barsl.Add(200);
            barsl.Add(400);
            barsl.Add(600);
            barsl.Add(800);
            barsl.Add(1000);
            barsl.Add(1200);
            barsl.Add(1400);

        }

        public void debug()
        {
            bariers.Clear();
            int omeg = 0;
            int x = 0;
            do
            {
                omeg =+ 25;
                x++;
                bariers.Add(omeg);
            }
            while (x < 8);

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
             
            for(int i = 0; i < barsl.Count; i++)
            {
                barsl[i] += 10;


                if(barsl[i] > 1600)
                {
                    newzabr();
                }
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
            drawbars();
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

        public void newzabr()
        {
            Random random = new Random();
            bariers.RemoveAt(bariers.Count-1);
            bariers.Insert(0,random.Next(100,500));

            barsl.RemoveAt(barsl.Count-1);
            barsl.Insert(0,0);
        }
        
        public void drawbars()
        {
            for(int i = 0; i < bariers.Count; i++)
            {
                Rectangle r1 = new Rectangle
                {
                    Height = 500,
                    Width = 50,
                    Fill = new SolidColorBrush(Colors.Orange)
                };
                Rectangle r2 = new Rectangle
                {
                    Height = 500,
                    Width = 50,
                    Fill = new SolidColorBrush(Colors.Orange)
                };

                field.Children.Add(r1);
                field.Children.Add(r2);

                Canvas.SetBottom(r1, (bariers[i] + 200 +250));
                Canvas.SetBottom(r2, bariers[i] - 250);

                Canvas.SetLeft(r1, barsl[i]);
                Canvas.SetLeft(r2, barsl[i]);
            }
        }

        Rectangle bar = new Rectangle
        {
            Height = 500,
            Width = 50,
            Fill = new SolidColorBrush(Colors.Orange)
        };

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace Dota攻略宝典.UserControls
{
    public partial class Waiting : UserControl
    {
        DispatcherTimer Timer = null;

        int Count = 1;

        public double Speed { get; set; }


        public Waiting()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();

            Timer.Interval = TimeSpan.FromMilliseconds(Speed);

            Timer.Tick += new EventHandler(Timer_Tick);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           



        }



        void Timer_Tick(object sender, EventArgs e)
        {

            this.image1.Source = new BitmapImage(new Uri("/Assets/loading00" + Count + ".png", UriKind.Relative));
            Count = (Count == 8 ? 1 : Count + 1);

        }



        public void WaitingBegin()
        {

            Timer.Start();

            WaitingWnd.IsOpen = true;

        }



        public void WaitingEnd()
        {

            Timer.Stop();

            WaitingWnd.IsOpen = false;

        }


    }
}

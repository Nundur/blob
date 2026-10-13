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
using System.Windows.Shapes;
using System.Windows.Threading;
using static blob.Classok.StaticBlobTextures;

namespace blob
{
    /// <summary>
    /// Interaction logic for hand.xaml
    /// </summary>
    public partial class hand : Window
    {
        DispatcherTimer hideing = new DispatcherTimer();
        public static int hideingint = 0;

        DispatcherTimer alapKezTimer = new DispatcherTimer();
        MainWindow foWindow = null;
        public int left = 0;
        public int top = 0;

        public hand(string args, int HI = 0, MainWindow foWin = null, int leftt=0, int topp = 0)
        {
            InitializeComponent();
            left = leftt;
            top = topp;

            foWindow = foWin;
            hideingint = HI;

            //MessageBox.Show($"{left} {top}");


            this.Left = foWindow.Left - left;
            this.Top = foWindow.Top + top;

            kez_kep.Source = new BitmapImage(new Uri(Pic($"basic/kezek/{args}.png")));
            if (hideingint != -1) //ha argumentumban -1 et adunk meg, akkor nem zarul be automatikusan
            {
                hideing.Interval = TimeSpan.FromMilliseconds(1000);
                hideing.Tick += Hideing_Tick;
                hideing.Start();
            }
            alapKezTimer.Interval = TimeSpan.FromMilliseconds(1);
            alapKezTimer.Tick += alapKezTimer_Tick;
            alapKezTimer.Start();
        }

        private void alapKezTimer_Tick(object sender, EventArgs e)
        {
            this.Left = foWindow.Left - left;
            this.Top = foWindow.Top + top;
        }

        private void Hideing_Tick(object sender, EventArgs e)
        {
            if (hideingint !=0)
            {
                hideingint--;
                
            } else
            {
                this.Close();
                hideing.Stop();
            }
        }
    }
}

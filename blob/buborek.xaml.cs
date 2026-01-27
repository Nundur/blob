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
    /// Interaction logic for buborek.xaml
    /// </summary>
    public partial class buborek : Window
    {
        DispatcherTimer hideing = new DispatcherTimer();
        public static int hideingint = 0;
        public string beviteliSzoveg = "";

        public buborek(string arg)
        {
            InitializeComponent();

            beviteliSzoveg = arg;

            this.Loaded += Buborek_Loaded;
            hideing.Interval = TimeSpan.FromMilliseconds(1000);
            hideing.Tick += Hideing_Tick;
            hideing.Start();
        }

        private void Hideing_Tick(object sender, EventArgs e)
        {
            if (hideingint == 4)
            {
                hideingint = 0;
                this.Close();
                hideing.Stop();
            }
            hideingint++;
        }

        private void Buborek_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            if (beviteliSzoveg.Length != 0)
            {
                szoveg.Text = beviteliSzoveg;
            }
            else
            {
                szoveg.Text = blobMondat[rnd.Next(blobMondat.Length - 1)];
            }


        }
    }
}

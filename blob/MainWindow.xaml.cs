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
using static blob.Classok.StaticBlobTextures;
using static blob.Classok.BlobTevekenysegek;
using blob.Classok;

namespace blob
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum merre { balra, jobbra, fel, le }
    public partial class MainWindow : Window
    {

        private BlobTevekenysegek blobTimers;
        public bool igene = false;

        public static MainWindow I;

        public static Random rnd = new Random();


        public MainWindow()
        {
            I = this;
            blobTimers = new BlobTevekenysegek(this);
            this.MouseEnter += MainWindow_MouseEnter;
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            this.MouseLeftButtonUp += MainWindow_MouseLeftButtonUp;
            InitializeComponent();
            this.Closing += blobBezarul;
            this.MouseLeave += MainWindow_MouseLeave;
        }

        private void MainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            blobTimers.elkaptaE = false;
        }

        private void blobBezarul(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (blobTimers.blobTolerancia >= 10)
            {
                e.Cancel = true;
                MessageBox.Show(blobNemAkarBezarodni[rnd.Next(blobNemAkarBezarodni.Length - 1)], "blob", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                //blobTimers.StopAnimaciok();
                //Application.Current.Shutdown();
            }
        }

        private void MainWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            Mouse.Capture(null);

            if (Math.Abs(difference) >=50)
            {
                if (difference > 0)
                {
                    blob.Source = new BitmapImage(new Uri(Pic("basic/blob-zuhan-balra.png")));
                } else if (difference < 0)
                {

                    blob.Source = new BitmapImage(new Uri(Pic("basic/blob-zuhan-jobbra.png")));
                }
                blobTimers.StopAnimaciok();
                blobTimers.blobotEldobjak.Start();
            } else {
                blobTimers.blobCsinalEValamit = false;
                blobTimers.idleAnimation.Start();
                blobTimers.blobViszik.Stop();
                blobTimers.blobTimer.Start();
            }
            
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Mouse.Capture(this);
                blob.Source = new BitmapImage(new Uri(Pic("basic/van.png")));
                blobTimers.StopAnimaciok();
                blobTimers.kezLevagas();
                blobTimers.blobViszik.Start();
                blobTimers.blobCsinalEValamit = true;
            }
                
        }


        private Point elozoPozicio;
        private void MainWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            Point aktualisPozicio = e.GetPosition(this);

            double dx = aktualisPozicio.X - elozoPozicio.X;
            double dy = aktualisPozicio.Y - elozoPozicio.Y;

            elozoPozicio = aktualisPozicio;

            //dx < 0: az egér balra mozog.
            //dx > 0: az egér jobbra mozog.



            //blobTimers.blobTolerancia++;
            if (!blobTimers.blobKovetiAzEgeret.IsEnabled)
            {
                if (blobTimers.blobTolerancia == 10)
                {
                    MessageBox.Show("na helobelo mostmár felkurtál", "blob", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (!(I.blobTimers.blobCsinalEValamit))
                {
                    if (dx < 0)
                    {
                        blob.Source = new BitmapImage(new Uri(Pic("basic/meglepodott-inverted.png")));
                        merrolJonBeAzEger = merre.jobbra;

                    } else if (dx > 0)
                    {
                        blob.Source = new BitmapImage(new Uri(Pic("basic/meglepodott.png")));
                        merrolJonBeAzEger = merre.balra;
                    }
                    
                    blobTimers.blobBok.Start();
                }
            }
            else
            {
                if (blobTimers.elkaptaE == false)
                {
                    blobTimers.elkaptaE = true;
                    blobTimers.egerLockIn.Start();
                    //System.Windows.Forms.Cursor.Hide();
                }
            }
        }

        private void Blob_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && blobTimers.blobCsinalEValamit == false)
            {

                I.blobTimers.blobCsinalEValamit = true;
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                blobTimers.blobEszik.Start();

                //MessageBox.Show(files[0]);

                for (int i = 0; i < files.Length; i++)
                {
                    System.IO.File.Delete(files[i]);
                    blobTimers.blobSzekletRaktar++;
                }
            }
        }
        private void UlClick(object sender, RoutedEventArgs e)
        {
            if (blobTimers.blobUl == false)
            {
                blobTimers.blobCsinalEValamit = true;
                blobTimers.blobTimer.Stop();
                blobTimers.idleAnimation.Stop();
                blob.Source = new BitmapImage(new Uri(Pic("basic/blobUl.png")));
            }
            else
            {
                blobTimers.blobCsinalEValamit = false;
                blobTimers.blobTimer.Start();
                blobTimers.idleAnimation.Start();
            }
        }
        private void exitClick(object sender, RoutedEventArgs e)
        {
            if (blobTimers.blobTolerancia >= 10)
            {
                MessageBox.Show(blobNemAkarBezarodni[rnd.Next(blobNemAkarBezarodni.Length - 1)], "blob", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                blobTimers.StopAnimaciok();
                Application.Current.Shutdown();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static blob.Classok.StaticBlobTextures;

namespace blob.Classok
{
    public partial class BlobTevekenysegek
    {


        private void BlobKovetiAzEgeret_Tick(object sender, EventArgs e)
        {
            var pos = System.Windows.Forms.Cursor.Position;
            if (elkaptaE == false)
            {
                /*
                if (blobTimer.IsEnabled) blobTimer.Stop();
                if (blobEszik.IsEnabled) blobEszik.Stop();
                if (blobBok.IsEnabled) blobBok.Stop();
                if (blobSetal.IsEnabled) blobSetal.Stop();
                if (idleAnimation.IsEnabled) idleAnimation.Stop();
                */

                blobCsinalEValamit = true;

                meddigMegyBlobStart++;
                if (main.Left + 75 >= pos.X)
                {
                    main.Left -= 10;
                    if (meddigMegyBlobStart % 2 == 0) main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal1.png")));
                    else main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal2.png")));
                }
                else
                {
                    main.Left += 10;
                    if (meddigMegyBlobStart % 2 == 0) main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal3.png")));
                    else main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal4.png")));

                }
                if (main.Top + 100 >= pos.Y) main.Top -= 10;
                else main.Top += 10;
            }
            else
            {
                if (balKez == null)
                {
                    kezLevagas();
                    balKez = new hand("interlock", 5, this.main, -55, 110);
                    balKez.Show();
                }
                main.blob.Source = new BitmapImage(new Uri(Pic("basic/mosoly/mosoly1.png")));
                //if (balKez != null) balKez.kez_kep.Source = new BitmapImage(new Uri(Pic("basic/kezek/interlock.png")));

            }
            szamlalo++;

            if (szamlalo == 200)
            {
                if (rnd.Next(0, 2) == 0 && elkaptaE)
                {
                    kezLevagas();
                    szamlalo = 0;
                    szamlaloKetto = 0;
                    StopAnimaciok();
                    egerLockIn.Stop();
                    elkaptaE = false;
                    blobEldobjaAzEgeret.Start();
                }
                else
                {
                    blobCsinalEValamit = false;
                    szamlalo = 0;
                    szamlaloKetto = 0;
                    StopAnimaciok();
                    idleAnimation.Start();
                    kezLevagas();
                    elkaptaE = false;
                    egerLockIn.Stop();
                    main.blob.Source = new BitmapImage(new Uri(Pic("basic/van.png")));
                    blobTimer.Start();
                    blobKovetiAzEgeret.Stop();
                }

            }

        }

    }
}

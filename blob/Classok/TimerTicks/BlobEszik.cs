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
        private void BlobEszik_Tick(object sender, EventArgs e)
        {
            blobCsinalEValamit = true;

            if (blobSetal.IsEnabled) blobSetal.Stop();
            if (idleAnimation.IsEnabled) idleAnimation.Stop();
            if (blobBok.IsEnabled) blobBok.Stop();
            if (blobKovetiAzEgeret.IsEnabled) blobKovetiAzEgeret.Stop();



            if (blobEszikInt == 2) main.blob.Source = new BitmapImage(new Uri(Pic("basic/eszik/eszik1.png")));
            if (blobEszikInt == 4) main.blob.Source = new BitmapImage(new Uri(Pic("basic/eszik/eszik2.png")));
            if (blobEszikInt == 6) main.blob.Source = new BitmapImage(new Uri(Pic("basic/eszik/eszik3.png")));
            if (blobEszikInt == 8) main.blob.Source = new BitmapImage(new Uri(Pic("basic/eszik/eszik4.png")));

            if (blobEszikInt == 9)
            {
                blobCsinalEValamit = false;
                blobEszikInt = 0;
                idleAnimation.Start();
                blobEszik.Stop();
            }
            blobEszikInt++;

        }

    }
}

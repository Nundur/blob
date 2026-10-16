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

        private void BlobViszik_Tick(object sender, EventArgs e)
        {

            blobotViszikInt++;
            kezLevagas();
            StopAnimaciok(new[] { blobViszik });
            /*
            if (blobTimer.IsEnabled) blobTimer.Stop();
            if (blobEszik.IsEnabled) blobEszik.Stop();
            if (blobBok.IsEnabled) blobBok.Stop();
            if (blobSetal.IsEnabled) blobSetal.Stop();
            if (idleAnimation.IsEnabled) idleAnimation.Stop();
            if (blobKovetiAzEgeret.IsEnabled) blobKovetiAzEgeret.Stop();
            */

            var pos = System.Windows.Forms.Cursor.Position;
            int x = pos.X;
            int y = pos.Y;

            if (blobotViszikInt % 2 == 0) main.blob.Source = new BitmapImage(new Uri(Pic("basic/repul/repul1.png")));
            else main.blob.Source = new BitmapImage(new Uri(Pic("basic/repul/repul2.png")));


            main.Left = x - 70;
            main.Top = y - 100;
            if (blobotViszikInt >= 100)
            {
                blobotViszikInt = 0;
            }


        }


    }
}

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

        private void BlobSzarik_Tick(object sender, EventArgs e)
        {
            szarDarabPeldany.Top += 1;

            blobSzarikInt++;
            if (blobSzarikInt == 50)
            {
                szarDarabPeldany.Topmost = true;
                szarDarabPeldany.eldol();
                blobCsinalEValamit = false;
                blobSzarikInt = 0;
                blobTimer.Start();
                idleAnimation.Start();
                blobSzarik.Stop();
            }

        }


    }
}

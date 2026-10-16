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
        public void IdleAnimation_Tick(object sender, EventArgs e)
        {
            if (idleAM == 0)
            {
                if (blobErreMegy == merre.balra) main.blob.Source = new BitmapImage(new Uri(Pic("basic/van.png")));
                else main.blob.Source = new BitmapImage(new Uri("pack://application:,,,/images/basic/van3.png"));
                idleAM = 1;
            }
            else if (idleAM == 1)
            {
                if (blobErreMegy == merre.balra) main.blob.Source = new BitmapImage(new Uri(Pic("basic/van2.png")));
                else main.blob.Source = new BitmapImage(new Uri(Pic("basic/van4.png")));
                idleAM = 0;
            }
        }
    }
}

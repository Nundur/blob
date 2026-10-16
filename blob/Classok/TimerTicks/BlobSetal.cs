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
        public void BlobSetal_Tick(object sender, EventArgs e)
        {
            meddigMegyBlobStart++;
            if (idleAnimation.IsEnabled) idleAnimation.Stop();
            //if (blobTimer.IsEnabled) blobTimer.Stop();


            double maxLeft = workingArea.Width - main.Width;
            double maxTop = workingArea.Height - main.Height;

            switch (blobErreMegy)
            {
                case merre.balra:
                    main.Left -= 10;
                    if (meddigMegyBlobStart % 2 == 0) main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal1.png")));
                    else main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal2.png")));

                    break;
                case merre.jobbra:
                    main.Left += 10;
                    if (meddigMegyBlobStart % 2 == 0) main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal3.png")));
                    else main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal4.png")));

                    break;
                case merre.fel:
                    if (meddigMegyBlobStart >= meddigMegyBlobStart / 4)
                    {

                        if (meddigMegyBlobStart >= meddigMegyBlob - 2)
                        {
                            main.blob.Source = new BitmapImage(new Uri(Pic("basic/ugrik/ugrik1.png")));
                        }
                        else
                        {
                            main.blob.Source = new BitmapImage(new Uri(Pic("basic/ugrik/ugrik2.png")));
                            main.Top -= 10;
                        }
                    }
                    break;
                case merre.le:
                    if (meddigMegyBlobStart >= meddigMegyBlobStart / 4)
                    {

                        if (meddigMegyBlobStart >= meddigMegyBlob - 2)
                        {
                            main.blob.Source = new BitmapImage(new Uri(Pic("basic/esik2.png")));
                        }
                        else
                        {
                            main.blob.Source = new BitmapImage(new Uri(Pic("basic/esik1.png")));
                            main.Top += 10;
                        }
                    }
                    break;
                default:
                    break;
            }
            if (meddigMegyBlobStart >= meddigMegyBlob)
            {
                meddigMegyBlobStart = 0;
                meddigMegyBlob = 0;
                //blobTimer.Start();
                idleAnimation.Start();
                blobSetal.Stop();
            }
        }

    }
}

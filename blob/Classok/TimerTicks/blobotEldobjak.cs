using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using static blob.Classok.StaticBlobTextures;

namespace blob.Classok
{
    public partial class BlobTevekenysegek
    {
        
        public void blobotEldobjak_Tick(object sender, EventArgs e)
        {
            double maxLeft = workingArea.Width - main.Width;
            //main.szoveg.Text = $"d:{difference<0} mainL:{main.Left} maxLeft:{maxLeft}";
            if (difference<0)
            {
                if (main.Left<=maxLeft)
                {
                    main.Left += 40;
                } else
                {
                    main.blob.Source = new BitmapImage(new Uri(Pic("basic/blob-utkozik-jobbra.png")));
                    blobotEldobjak.Stop();
                    idleAnimation.Start();
                    blobTimer.Start();
                    if (rnd.Next(0, 2) == 0)
                    {
                        buborek bubi = new buborek(blobNemAkarjaEldobjak[rnd.Next(0, blobNemAkarjaEldobjak.Length - 1)]);
                        bubi.Left = main.Left - 250;
                        bubi.Top = main.Top - 100;
                        bubi.Show();
                    }
                }
            } else
            {
                if (main.Left >= 0)
                {
                    main.Left -= 40;
                }
                else
                {
                    main.blob.Source = new BitmapImage(new Uri(Pic("basic/blob-utkozik-balra.png")));
                    blobotEldobjak.Stop();
                    idleAnimation.Start();
                    blobTimer.Start();

                    if (rnd.Next(0, 2) == 0)
                    {
                        buborek bubi = new buborek(blobNemAkarjaEldobjak[rnd.Next(0, blobNemAkarjaEldobjak.Length - 1)]);
                        bubi.Left = main.Left - 250;
                        bubi.Top = main.Top - 100;
                        bubi.Show();
                    }
                }
            }
        }
    }
}

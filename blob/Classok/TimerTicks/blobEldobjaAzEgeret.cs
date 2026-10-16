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
        private void BlobEldobjaAzEgeret_Tick(object sender, EventArgs e)
        {
            szamlalo++;
            if (szamlalo == 1)
            {
                if (merreDob == merre.balra)
                {
                    main.blob.Source = new BitmapImage(new Uri(Pic("basic/meglepodott.png")));
                    blobDobAnimation = 1;
                    kezLevagas();
                    balKez = new hand("mutat-bal", -1, this.main, 25, 95);
                    jobbKez = new hand("okol-bal", -1, this.main, -120, 47);
                    balKez.Show();
                    jobbKez.Show();
                }
                else
                {
                    main.blob.Source = new BitmapImage(new Uri(Pic("basic/meglepodott-inverted.png")));
                    blobDobAnimation = 1;
                    kezLevagas();
                    balKez = new hand("mutat-jobb", -1, this.main, -25 - 100, 95);
                    jobbKez = new hand("okol-jobb", -1, this.main, 120 - 100, 47);
                    balKez.Show();
                    jobbKez.Show();
                }

            }
            if (szamlalo >= 1 && szamlalo < 50) if(merreDob == merre.balra) SetCursorPos(Convert.ToInt32(main.Left + 122), Convert.ToInt32(main.Top + 47)); else SetCursorPos(Convert.ToInt32(main.Left - 122+150), Convert.ToInt32(main.Top + 47));

            else if (szamlalo == 50) // vagy amennyi tick a várakozási időd
                {
                    if (merreDob == merre.balra)
                    {
                        blobDobAnimation = 2;
                        kezLevagas();
                        balKez = new hand("hand-bal", -1, this.main, 22, 40);
                        jobbKez = new hand("handdown-bal", -1, this.main, -100, 110);
                        balKez.Show();
                        jobbKez.Show();
                    }
                    else
                    {
                        blobDobAnimation = 2;
                        kezLevagas();
                        balKez = new hand("hand-jobb", -1, this.main, -22 - 150, 40);
                        jobbKez = new hand("handdown-jobb", -1, this.main, 100 - 150, 110);
                        balKez.Show();
                        jobbKez.Show();
                    }
                }
            if (szamlalo >= 50)
            {
                szamlaloKetto += 45;
                if (merreDob == merre.balra)
                {
                    SetCursorPos(Convert.ToInt32(main.Left + 22 - szamlaloKetto), Convert.ToInt32(main.Top + 40 - (szamlaloKetto / 4)));
                }
                else
                {
                    SetCursorPos(Convert.ToInt32(main.Left + 22 + szamlaloKetto), Convert.ToInt32(main.Top + 40 - (szamlaloKetto / 4)));
                }

            }
            if (szamlalo == 100)
            {
                main.blob.Source = new BitmapImage(new Uri(Pic("basic/van.png")));
                blobEldobjaAzEgeret.Stop();
                kezLevagas();
                idleAnimation.Start();
                blobTimer.Start();
                //Environment.Exit(0);
            }
        }

    }
}

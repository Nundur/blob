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
        private void blobBok_Tick(object sender, EventArgs e)
        {
            double maxLeft = workingArea.Width - main.Width;
            double maxTop = workingArea.Height - main.Height;
            /*
            var pos =System.Windows.Forms.Cursor.Position;

            if (blobTolerancia>=10)
            {
                if (rnd.Next(2) == 0)
                {
                    SetCursorPos(pos.X - 100, pos.Y);
                }
                else SetCursorPos(pos.X, pos.Y - 100);

            }*/
            int v = 8;
            if (merrolJonBeAzEger == merre.balra)//balra
            {
                if (!(main.Left + v >= maxLeft))
                {
                    main.Left += v;
                    if (rnd.Next(0, 2) == 0) main.Top += v;
                    else main.Top -= v;
                }
                else
                {
                    if (!(main.Top + v >= maxTop)) main.Top += v;
                    else main.Top -= v;
                }
                blobBokInt++;
            }
            else if (merrolJonBeAzEger == merre.jobbra) // jobbra
            {
                if (main.Left - v >= 0)
                {
                    main.Left -= v;

                    if (rnd.Next(0, 2) == 0)
                        main.Top += v;
                    else
                        main.Top -= v;
                }
                else
                {
                    if (main.Top + v < maxTop)
                        main.Top += v;
                    else
                        main.Top -= v;
                }

                blobBokInt++;

            }

            if (blobBokInt >= 20)
            {
                blobBokInt = 0;
                blobBok.Stop();
            }

        }


    }
}

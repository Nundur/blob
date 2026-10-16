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


            if (!(main.Left + 10 >= maxLeft))
            {
                main.Left += 10;
                if (rnd.Next(0, 2) == 0) main.Top += 10;
                else main.Top -= 10;
            }
            else
            {
                if (!(main.Top + 10 >= maxTop)) main.Top += 10;
                else main.Top -= 10;
            }
            blobBokInt++;
            if (blobBokInt == 10)
            {
                blobBokInt = 0;
                blobBok.Stop();
            }
        }


    }
}

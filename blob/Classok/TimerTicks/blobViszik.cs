using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static blob.Classok.StaticBlobTextures;

namespace blob.Classok
{
    public partial class BlobTevekenysegek
    {
        int Xeger= System.Windows.Forms.Cursor.Position.X;
        public static int difference = 0;
        private void BlobViszik_Tick(object sender, EventArgs e)
        {
            
            
            //main.szoveg.Text = $"{difference}";

            blobotViszikInt++;
            

            var pos = System.Windows.Forms.Cursor.Position;
            int x = pos.X;
            int y = pos.Y;

            difference = Xeger - x;
            Xeger = System.Windows.Forms.Cursor.Position.X;

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

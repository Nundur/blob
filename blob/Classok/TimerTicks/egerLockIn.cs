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
        private void EgerLockIn_Tick(object sender, EventArgs e)
        {
            SetCursorPos(Convert.ToInt32(main.Left + 75), Convert.ToInt32(main.Top + 100));
        }
    }
}

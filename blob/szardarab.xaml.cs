using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static blob.Classok.StaticBlobTextures;


namespace blob
{
    /// <summary>
    /// Interaction logic for szardarab.xaml
    /// </summary>
    public partial class szardarab : Window
    {
        public szardarab()
        {
            InitializeComponent();
        }
        public void eldol()
        {
            this.Width = 60;
            this.Height = 30;
            this.szardarabKep.Source = new BitmapImage(new Uri(Pic("basic/szardarab/szardarab2.png")));
        }
    }
}

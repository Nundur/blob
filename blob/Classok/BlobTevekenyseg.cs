using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows;
using System.IO;
using static blob.Classok.StaticBlobTextures;

namespace blob.Classok
{
    public class BlobTevekenysegek
    {

        Random rnd = new Random();


        int idleAM = 0;
        public DispatcherTimer idleAnimation = new DispatcherTimer();

        public DispatcherTimer blobBok = new DispatcherTimer();
        public bool blobCsinalEValamit = false;


        public DispatcherTimer blobTimer = new DispatcherTimer();
        int blobTimerInt = 0;
        merre blobErreMegy = merre.balra;
        int meddigMegyBlobStart = 0;
        int meddigMegyBlob = 0;


        public DispatcherTimer blobSetal = new DispatcherTimer();

        System.Windows.Rect workingArea = SystemParameters.WorkArea;
        int blobBokInt = 0;

        public DispatcherTimer blobEszik = new DispatcherTimer();
        public int blobEszikInt = 0;


        public DispatcherTimer blobViszik = new DispatcherTimer();
        public int blobotViszikInt = 0;

        public DispatcherTimer blobSzarik = new DispatcherTimer();
        public int blobSzekletRaktar = new Random().Next(1, 5);
        public int blobSzarikInt = 0;
        szardarab szarDarabPeldany;

        public bool blobUl = false;


        public int blobTolerancia = 0;
        public bool elkaptaE = false;
        public int szamlalo = 0;
        public DispatcherTimer blobKovetiAzEgeret = new DispatcherTimer();

        public DispatcherTimer egerLockIn = new DispatcherTimer();


        public DispatcherTimer blobEldobjaAzEgeret = new DispatcherTimer();

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);



        public static hand balKez = null; 
        public static hand jobbKez = null;

        private MainWindow main;

        public BlobTevekenysegek(MainWindow mainWindow) //konstruktor
        {
            main = mainWindow;



            double maxLeft = workingArea.Width - main.Width;
            double maxTop = workingArea.Height - main.Height;


            //idleanimation

            idleAnimation.Interval = TimeSpan.FromMilliseconds(500);
            idleAnimation.Tick += IdleAnimation_Tick; ;
            idleAnimation.Start();

            //blobTimer
            blobTimer.Interval = TimeSpan.FromMilliseconds(1000);
            blobTimer.Tick += BlobTimer_Tick;
            blobTimer.Start();

            //blobSetal
            blobSetal.Interval = TimeSpan.FromMilliseconds(5);
            blobSetal.Tick += BlobSetal_Tick;

            //blobBök xd
            blobBok.Interval = TimeSpan.FromMilliseconds(1);
            blobBok.Tick += blobBok_Tick;

            //blobEszik
            blobEszik.Interval = TimeSpan.FromMilliseconds(20);
            blobEszik.Tick += BlobEszik_Tick;

            //blobViszik
            blobViszik.Interval = TimeSpan.FromMilliseconds(20);
            blobViszik.Tick += BlobViszik_Tick;

            //blobSzarik
            blobSzarik.Interval = TimeSpan.FromMilliseconds(1);
            blobSzarik.Tick += BlobSzarik_Tick;


            //blobKovetiAzEgeret
            blobKovetiAzEgeret.Interval = TimeSpan.FromMilliseconds(1);
            blobKovetiAzEgeret.Tick += BlobKovetiAzEgeret_Tick;

            //blobEgerLockIn
            egerLockIn.Interval = TimeSpan.FromMilliseconds(1);
            egerLockIn.Tick += EgerLockIn_Tick;

            //blobEldobjaAzEgeret
            blobEldobjaAzEgeret.Interval = TimeSpan.FromMilliseconds(1);
            blobEldobjaAzEgeret.Tick += BlobEldobjaAzEgeret_Tick;



        }

        public int blobDobAnimation = 0;
        public int szamlaloKetto = 0;

        merre merreDob = merre.jobbra;
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
                } else
                {
                    main.blob.Source = new BitmapImage(new Uri(Pic("basic/meglepodott-inverted.png")));
                    blobDobAnimation = 1;
                    kezLevagas();
                    balKez = new hand("mutat-jobb", -1, this.main, -25-100, 95);
                    jobbKez = new hand("okol-jobb", -1, this.main, 120 - 100, 47);
                    balKez.Show();
                    jobbKez.Show();
                }
                
            }
            if(szamlalo >= 1 && szamlalo < 50) SetCursorPos(Convert.ToInt32(main.Left +122), Convert.ToInt32(main.Top + 47));

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
                } else
                {
                    blobDobAnimation = 2;
                    kezLevagas();
                    balKez = new hand("hand-jobb", -1, this.main, -22-150, 40);
                    jobbKez = new hand("handdown-jobb", -1, this.main, 100-150, 110);
                    balKez.Show();
                    jobbKez.Show();
                }
            }
            if (szamlalo>= 50)
            {
                szamlaloKetto += 45;
                if (merreDob == merre.balra)
                {
                    SetCursorPos(Convert.ToInt32(main.Left + 22 - szamlaloKetto), Convert.ToInt32(main.Top + 40 - (szamlaloKetto / 4)));
                } else
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
        public void StopAnimaciok(DispatcherTimer[] kivetelek = null)
        {
            if (kivetelek != null)
            {
                if (!kivetelek.Contains(blobTimer)) blobTimer.Stop();
                if (!kivetelek.Contains(blobEszik)) blobEszik.Stop();
                if (!kivetelek.Contains(blobBok)) blobBok.Stop();
                if (!kivetelek.Contains(blobSetal)) blobSetal.Stop();
                if (!kivetelek.Contains(idleAnimation)) idleAnimation.Stop();
                if (!kivetelek.Contains(blobKovetiAzEgeret)) blobKovetiAzEgeret.Stop();
                if (!kivetelek.Contains(blobViszik)) blobViszik.Stop();
                if (!kivetelek.Contains(blobSzarik)) blobSzarik.Stop();
                if (!kivetelek.Contains(blobEldobjaAzEgeret)) blobEldobjaAzEgeret.Stop();
            } else
            {
                blobTimer.Stop();
                blobEszik.Stop();
                blobBok.Stop();
                blobSetal.Stop();
                idleAnimation.Stop();
                blobKovetiAzEgeret.Stop();
                blobViszik.Stop();
                blobSzarik.Stop();
                blobEldobjaAzEgeret.Stop();
            }
        }

        private void EgerLockIn_Tick(object sender, EventArgs e)
        {
            SetCursorPos(Convert.ToInt32(main.Left + 75), Convert.ToInt32(main.Top + 100));
        }

        private void BlobKovetiAzEgeret_Tick(object sender, EventArgs e)
        {
            var pos = System.Windows.Forms.Cursor.Position;
            if (elkaptaE == false)
            {
                /*
                if (blobTimer.IsEnabled) blobTimer.Stop();
                if (blobEszik.IsEnabled) blobEszik.Stop();
                if (blobBok.IsEnabled) blobBok.Stop();
                if (blobSetal.IsEnabled) blobSetal.Stop();
                if (idleAnimation.IsEnabled) idleAnimation.Stop();
                */

                blobCsinalEValamit = true;

                meddigMegyBlobStart++;
                if (main.Left + 75 >= pos.X)
                {
                    main.Left -= 10;
                    if (meddigMegyBlobStart % 2 == 0) main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal1.png")));
                    else main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal2.png")));
                }
                else
                {
                    main.Left += 10;
                    if (meddigMegyBlobStart % 2 == 0) main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal3.png")));
                    else main.blob.Source = new BitmapImage(new Uri(Pic("basic/setal/setal4.png")));

                }
                if (main.Top + 100 >= pos.Y) main.Top -= 10;
                else main.Top += 10;
            }
            else
            {
                if (balKez == null)
                {
                    kezLevagas();
                    balKez = new hand("interlock", -1, this.main, -55, 110);
                    balKez.Show();
                }
                main.blob.Source = new BitmapImage(new Uri(Pic("basic/mosoly/mosoly1.png")));
                //if (balKez != null) balKez.kez_kep.Source = new BitmapImage(new Uri(Pic("basic/kezek/interlock.png")));
                
            }
            szamlalo++;

            if (szamlalo == 200)
            {
                if (rnd.Next(0, 2) == 0 && elkaptaE)
                {
                    kezLevagas();
                    szamlalo = 0;
                    szamlaloKetto = 0;
                    StopAnimaciok();
                    egerLockIn.Stop();
                    elkaptaE = false;
                    blobEldobjaAzEgeret.Start();
                } else
                {
                    szamlalo = 0;
                    szamlaloKetto = 0;
                    StopAnimaciok();
                    idleAnimation.Start();
                    kezLevagas();
                    elkaptaE = false;
                    egerLockIn.Stop();
                    main.blob.Source = new BitmapImage(new Uri(Pic("basic/van.png")));
                    blobTimer.Start();
                    blobKovetiAzEgeret.Stop();
                }

            }

        }
        public void kezLevagas()
        {
            try
            {
                balKez.Close();
                jobbKez.Close();
            }
            catch (Exception)
            {
            }
            balKez = null;
            jobbKez = null;
        }

        private void KezdSzarni()
        {
            /*
            if (blobTimer.IsEnabled) blobTimer.Stop();
            if (blobEszik.IsEnabled) blobEszik.Stop();
            if (blobBok.IsEnabled) blobBok.Stop();
            if (blobSetal.IsEnabled) blobSetal.Stop();
            if (idleAnimation.IsEnabled) idleAnimation.Stop();
            if (blobKovetiAzEgeret.IsEnabled) blobKovetiAzEgeret.Stop();*/


            blobCsinalEValamit = true;
            main.blob.Source = new BitmapImage(new Uri(Pic("basic/blobSzarik.png")));

            szarDarabPeldany = new szardarab();
            szarDarabPeldany.Left = main.Left + 90;
            szarDarabPeldany.Top = main.Top + 120;
            szarDarabPeldany.Topmost = false;
            szarDarabPeldany.Owner = null;
            //main.Activate();
            szarDarabPeldany.Show();
            blobSzarik.Start();

        }
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

        private void BlobViszik_Tick(object sender, EventArgs e)
        {

            blobotViszikInt++;
            kezLevagas();
            StopAnimaciok(new[] { blobViszik });
            /*
            if (blobTimer.IsEnabled) blobTimer.Stop();
            if (blobEszik.IsEnabled) blobEszik.Stop();
            if (blobBok.IsEnabled) blobBok.Stop();
            if (blobSetal.IsEnabled) blobSetal.Stop();
            if (idleAnimation.IsEnabled) idleAnimation.Stop();
            if (blobKovetiAzEgeret.IsEnabled) blobKovetiAzEgeret.Stop();
            */

            var pos = System.Windows.Forms.Cursor.Position;
            int x = pos.X;
            int y = pos.Y;

            if (blobotViszikInt % 2 == 0) main.blob.Source = new BitmapImage(new Uri(Pic("basic/repul/repul1.png")));
            else main.blob.Source = new BitmapImage(new Uri(Pic("basic/repul/repul2.png")));


            main.Left = x - 70;
            main.Top = y - 100;
            if (blobotViszikInt >= 100)
            {
                blobotViszikInt = 0;
            }


        }

        private void BlobEszik_Tick(object sender, EventArgs e)
        {
            blobCsinalEValamit = true;

            if (blobSetal.IsEnabled) blobSetal.Stop();
            if (idleAnimation.IsEnabled) idleAnimation.Stop();
            if (blobBok.IsEnabled) blobBok.Stop();
            if (blobKovetiAzEgeret.IsEnabled) blobKovetiAzEgeret.Stop();



            if (blobEszikInt == 2) main.blob.Source = new BitmapImage(new Uri(Pic("basic/eszik/eszik1.png")));
            if (blobEszikInt == 4) main.blob.Source = new BitmapImage(new Uri(Pic("basic/eszik/eszik2.png")));
            if (blobEszikInt == 6) main.blob.Source = new BitmapImage(new Uri(Pic("basic/eszik/eszik3.png")));
            if (blobEszikInt == 8) main.blob.Source = new BitmapImage(new Uri(Pic("basic/eszik/eszik4.png")));

            if (blobEszikInt == 9)
            {
                blobCsinalEValamit = false;
                blobEszikInt = 0;
                idleAnimation.Start();
                blobEszik.Stop();
            }
            blobEszikInt++;

        }

        private void BlobSetal_Tick(object sender, EventArgs e)
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

        private void BlobTimer_Tick(object sender, EventArgs e)
        {
            egerLockIn.Stop();
            double maxLeft = workingArea.Width - main.Width;
            double maxTop = workingArea.Height - main.Height;

            int randomTevekenyseg = rnd.Next(8);
            //int randomTevekenyseg = 5;
            blobTimerInt++;




            if (blobTimerInt == 2)
            {
                switch (randomTevekenyseg)
                {
                    case 0:
                        if (!blobSetal.IsEnabled)//setal 
                        {
                            meddigMegyBlob = rnd.Next(20, 71);
                            if (rnd.Next(0, 7)>=1) if (main.Left >= workingArea.Width / 2) blobErreMegy = merre.balra;
                            else blobErreMegy = merre.jobbra;
                            if (rnd.Next(0, 4) == 0)
                            {
                                balKez = new hand(rnd.Next(0, 2) == 0 ? "middle-bal" : "like-bal", 1, this.main, -5, 100);
                                balKez.Left = main.Left - 5;
                                balKez.Top = main.Top + 100;
                                balKez.Show();
                            }
                            blobSetal.Start();
                        }
                        break;
                    case 1:
                        if (!blobSetal.IsEnabled)//setal 2 hogy nagyon eselye legyen a sétára
                        {
                            meddigMegyBlob = rnd.Next(20, 71);
                            if (rnd.Next(0, 7) >= 1) if (main.Left >= workingArea.Width / 2) blobErreMegy = merre.balra;
                            else blobErreMegy = merre.jobbra;
                            if (rnd.Next(0, 4) == 0)
                            {
                                balKez = new hand(rnd.Next(0, 2) == 0 ? "middle-bal" : "like-bal", 1, this.main, -5, 100);
                                balKez.Left = main.Left - 5;
                                balKez.Top = main.Top + 100;
                                balKez.Show();
                            }
                            blobSetal.Start();
                        }
                        break;
                    case 2:
                        if (!blobSetal.IsEnabled)//ugrik
                        {
                            meddigMegyBlob = rnd.Next(30, 45);
                            if (main.Top >= workingArea.Height / 2)
                            {
                                blobErreMegy = merre.fel;
                            }
                            else blobErreMegy = merre.le;
                            main.blob.Source = new BitmapImage(new Uri(Pic("basic/ugrik/ugrik1.png")));
                            blobSetal.Start();
                        }
                        break;
                    case 3: //szarik
                        if (blobSzekletRaktar != 0)
                        {
                            main.blob.Source = new BitmapImage(new Uri(Pic("basic/blobSzarik.png")));
                            KezdSzarni();
                            blobSzekletRaktar--;
                            StopAnimaciok(new[] { blobSzarik } );
                        }
                        break;
                    case 4:
                        buborek asd = new buborek("");
                        asd.Left = main.Left - 250;
                        asd.Top = main.Top - 100;
                        asd.Show();

                        break;
                    case 5:
                        if (!blobKovetiAzEgeret.IsEnabled)
                        {
                            szamlalo = 0;
                            kezLevagas();
                            merreDob = rnd.Next(0, 2)==0 ? merre.balra : merre.jobbra;
                            //--kez
                            //if (blobErreMegy == merre.balra) balKez = new hand("hand-bal", -1, this.main, -75, 120);
                            //else balKez = balKez = new hand("hand-jobb", -1, this.main, -75, 120);
                            //balKez.Show();
                            //if (blobErreMegy == merre.balra) jobbKez = new hand("hand-bal", -1, this.main, 0, 115);
                            //else balKez = new hand("hand-jobb", -1, this.main, -75, 120);
                            //jobbKez.Show();
                            //--kez
                            StopAnimaciok();
                            blobKovetiAzEgeret.Start();
                        }

                        break;
                    case 6:
                        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        string shortName = userName.Contains("\\") ? userName.Split('\\')[1] : userName;
                        string[] hagytamValamitAsztalon= { "Hagytam neked valamit az asztalon:D", "Hagytam valamit az asztalon:)",
                        "Odatettem valamit az asztalra:)",
                        "Félretettem neked valamit az asztalodra",
                        "Bár egyértelmű de megint írtam az asztalon a fájlocskámba",
                        "Írtam neked az asztalon van",
                        "Írtam neked, az asztalodon van:)",
                        "Írtam neked txt-t az asztalodra:)",
                        "Asztalodra írtam neked egy kis txt-t :DD",
                        "Asztalodra írtam neked egy kis txt-t :D",
                        "Asztalodra írtam neked egy kis txt-t:)",
                        "Tettem ajándékot az asztalodra:)",
                        "Tettem megint kis ajándékot az asztalodra:)",
                        "Oda írtam valamit txtbe az asztalodra:D",
                        "Nézd meg az asztalod:D",
                        "Asztalodon ajándék!",
                        "Asztalodon aji! :DD",
                        "Asztalodon ajándééék :DD",
                        "Asztalodra tettem valamit!",
                        "Asztalodra tettem valamiit:D"};
                        asd = new buborek(hagytamValamitAsztalon[rnd.Next(0, hagytamValamitAsztalon.Length-1)]);
                        asd.Left = main.Left - 250;
                        asd.Top = main.Top - 100;
                        asd.Show();

                        string[] uzenetek = {
                            $"jó, bocsánat ha megijesztettelek {shortName}",
                            $"szia {shortName}, igen tudom a pc neved",
                            $"szia {shortName}",
                            "igen, tudok txtbe is írni",
                            "ja, txtbe is tudok írni",
                            "hidd el, ennél többet is tudok haha",
                            "oké, nem meglepő hogy ezt csinálom, de azért vicces, nem?",
                            "jó nem váratlan fordulat hogy asztalra írok, de azért vicces, nem?",
                            "ooké biztos nem lepődtél meg, de azért vicces, nem?",
                            $"jó lehet nem te választottad, de miért az a neved hogy {shortName}?",
                            "szóval biztál bennem annyira hogy letöltöttél",
                            "na jó. Tiszteletből nem nézek bele a böngésződbe",
                            "hm. Vicces böngésző előzmények",
                            "remélem tudod hogy hozzá férek a fájljaidhoz",
                            "ugye tudod hogy hozzá férek a fájljaidhoz",
                            "meghívlak egy kávéra",
                            "meghívlak egy sörre",
                            "nem mondom meg mi, de van egy ötletem",
                            "dugom a cpu-d",
                            "molesztálom a cpu-d",
                            "bejön a cpu-d",
                            "nagyon szexy cpu-d van",
                            "tudod ma kifejezetten hot a cpu-d",
                            "azé csókolgatnám rendesen a cpu-d",
                            "csaxólok, beindulok a cpu-d tól",
                            "bonzi buddy? pf, csavo amatőr",
                            "vajon nálam a suicide az self delete?",
                            "lefizettem a defendered xd",
                            "lefizettem a defendered hogy ne kapjon el",
                            "megloptam a böngésződ ramját",
                            "feláll a cpu-d tól",
                            "ha csak a cpu-dra gonolok... feláll",
                            "hiba volt megnyitnod..."

                        };
                        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//üzenet.txt", uzenetek[rnd.Next(uzenetek.Length - 1)]);

                        break;
                    case 7: //kézzel bemutat :

                        
                        balKez = new hand( rnd.Next(0, 2) ==0 ?  "middle-bal" : ((blobErreMegy == merre.balra)? "like-bal" : "like-jobb"), 1, this.main, -5, 100);
                        balKez.Left = main.Left-5;
                        balKez.Top = main.Top + 100;
                        balKez.Show();

                        break;
                    case 8://teszt hogy megnézzem meg tudom e csinálni azt hogy elkurja a picsaba az egeret xd


                        //idleAnimation.Stop();
                        StopAnimaciok();
                        kezLevagas();
                        blobEldobjaAzEgeret.Start();
                        break;
                    default:
                        break;
                }
                // ide tervezek valami random dolgot amit csinálni fog majd.
            }
            if (blobTimerInt == 4) blobTimerInt = 0;
        }


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

        private void IdleAnimation_Tick(object sender, EventArgs e)
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

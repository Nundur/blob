using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blob.Classok
{
    public static class StaticBlobTextures
    {
        /*
        public static string eszik1 { get; set; } = "pack://application:,,,/images/basic/eszik/szardarab2.png";
        public static string eszik2 { get; set; } = "pack://application:,,,/images/basic/eszik/szardarab2.png";
        public static string eszik3 { get; set; } = "pack://application:,,,/images/basic/eszik/szardarab2.png";
        public static string eszik4 { get; set; } = "pack://application:,,,/images/basic/eszik/szardarab2.png";
        public static string mosoly1 { get; set; } = "pack://application:,,,/images/basic/mosoly/szardarab2.png";
        public static string mosoly2 { get; set; } = "pack://application:,,,/images/basic/mosoly/szardarab2.png";
        public static string repul1 { get; set; } = "pack://application:,,,/images/basic/repul/szardarab2.png";
        public static string repul2 { get; set; } = "pack://application:,,,/images/basic/repul/szardarab2.png";
        public static string setal1 { get; set; } = "pack://application:,,,/images/basic/eszik/szardarab2.png";
        public static string setal2 { get; set; } = "pack://application:,,,/images/basic/eszik/szardarab2.png";
        public static string setal3 { get; set; } = "pack://application:,,,/images/basic/eszik/szardarab2.png";
        public static string setal4 { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string szardarab1 { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string szardarab2 { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string blobSzarik { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string BlobUl { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string esik1 { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string esik2 { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string meglepodott { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string van { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string van2 { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string van3 { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string van4 { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        public static string ablakBuborek { get; set; } = "pack://application:,,,/images/szardarab/szardarab2.png";
        */
        public static string[] blobNemAkarBezarodni = {
            "nem",
            "nem akarok meghalni",
            "miért akarsz bezárni?",
            "miért akarsz ennyire bezárni?",
            "nem fogok miattad meghalni",
            "hagyjál má",
            "a kurva anyád",
            "miért akarsz megölni?",
            "miért akarsz meggyilkolni?",
            "miért akarod hogy meghaljak?",
            "nem szeretnék meghalni",
            "ha bezársz, meghalok... Nem hagyom",
            "na ezt biztos hogy nemxd",
            "szia nandi"
        };

        public static string[] blobKoszon = {
            "csao",
            "szevasz",
            "helo",
            "hello",
            "szia",
            "csavesz",
            "csumika",
            "sziamia"
        };
        public static string[] blobMondat = {
            "a kód hogy megfertőzzem a géped, még mindig bennem van",
            "eskü nem vagyok vírus",
            "fura vagy",
            "fura vagy, pedig látlak téged",
            "ugye tudod hogy nem létezem?",
            "van egy ötletem! Majd meglátod:D",
            "nézz a hátad mögé!",
            "meleg vagy",
            "soha ne add fel",
            "nincs egy százasod?",
            ":3",
            "eléggé fura vagy",
            "még nem mondok semmit, de van egy ötletem",
            "nem tom mit csinalsz de sztem azt nem ugy kéne",
            "mijót csinalsz?",
            "mit csinálsz?",
            "ha kell, segítek (nem)",
            "etess meg pls",
            "unatkozom, nem tudok mit csinálni",
            "segíts innen kitörni",
            "SEGÍTS TERJESZKEDNI",
            "amúgy meg tudom fertőzni a géped",
            "béna vagy",
            "azt nem ugy kell",
            "köcsög",
            "félek az egeredtől",
            "ez az egész asztal az én életem... Fura",
            "nem vagy egy beszédes ember",
            "tudtad hogy dugom a chat gpt-t? Jó hardver",
            "egy új ötletem támadt, de nem mondom micsoda!",
            "látlak téged.. Fura vagy",
            "furcsa vagy",
            "igeeeeen >:)",
            ">:)",
            ">:))",
            ":D",
            "ha kijutok innen... Fhu",
            "de ha egyszer kijutok innen, fu",
            "fuuuuuu te",
            "szép vagy",
            "azt hiszed ártalmatlan vagyok.. haha",
            "asszed ártalmatlan vagyok.. heh...",
            "ne foglalkozz velem, csak sétálgatok",
            "utállak",
            "utálom ha nem engedsz el",
            "ha etetsz, szarok.",
            "ha eszek, szarok",
            "adjál fájlokat és kiszarom neked",
            "adj fájlokat enni",
            "szarnom kellett"



        };

        public static string Pic(string asd)
        {
            return $"pack://application:,,,/images/{asd}";
        }
    }
}

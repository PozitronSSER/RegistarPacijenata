using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBCRijekaKantridaRegistar
{
    class Pacijent
    {
        public string ImePacijenta;
        public string PrezimePacijenta;
        public static int Id;
        /*
         * nisam baš siguran da je ovo dobar pristup...
         * 
         * 
        string ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,
            apgarIndeks, trajanjePoroda;
        string[] patologijaTrudnoce = new string[6];
        string[] komplikacije = new string[10];
        int gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaTezina, opsegGlave;
        DateTime datumRodenja;
        bool trudnocaPlodna, trudnocaPrirodna, nacinPoroda, prom, febrilitetRodilje, reanimacija;
        
        
        public Pacijent(string Ime, string Prezime, string ImeMajke, string ImeOca, string Adresa, string KontaktTelefon,
            string Spol, string ParitetTrudnoce, string StavDjeteta, string Profilaksa, DateTime DatumRodenja, bool TrudnocaPrirodna,
            string TrajanjePoroda)
        {
            ime = Ime;
            prezime = Prezime;
            imeMajke = ImeMajke;
            imeOca = ImeOca;
            adresa = Adresa;
            kontaktTelefon = KontaktTelefon;
            spol = Spol;
            paritetTrudnoce = ParitetTrudnoce;
            stavDjeteta = StavDjeteta;
            profilaksa = Profilaksa;
            datumRodenja = DatumRodenja;
            trudnocaPrirodna = TrudnocaPrirodna;
            trajanjePoroda = TrajanjePoroda;
        }
        */
        public override string ToString()
        {
            return ImePacijenta + " " + PrezimePacijenta;
        }
        public Pacijent(string ime, string prezime)
        {
            ImePacijenta = ime;
            PrezimePacijenta = prezime;
            Id++;
        }
    }
}

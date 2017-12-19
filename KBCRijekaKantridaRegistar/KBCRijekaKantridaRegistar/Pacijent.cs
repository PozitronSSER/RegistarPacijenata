// uklonio nepotrebne using

namespace KBCRijekaKantridaRegistar
{
    class Pacijent
    {
        public string imePacijenta;
        public string prezimePacijenta;
        public static int id;

        public override string ToString()
        {
            return imePacijenta + " " + prezimePacijenta + "Id: " + id;
        }

        // probni konstruktor

        public Pacijent(string ime, string prezime)
        {
            imePacijenta = ime;
            prezimePacijenta = prezime;
            id++;
        }

        /*
         * nisam baš siguran da je ovo dobar pristup...
         
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
        
    }
}

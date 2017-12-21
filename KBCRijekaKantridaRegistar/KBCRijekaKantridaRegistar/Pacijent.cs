// uklonio nepotrebne using

using System;

namespace KBCRijekaKantridaRegistar
{
    class Pacijent
    {
        // (1) provjeriti da li su sve varijable u redu

        int id, gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaTezina, opsegGlave;;
        string imePacijenta, prezimePacijenta, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,
            apgarIndeks, trajanjePoroda;
        
        // (2) provjeriti da li je dobro koristiti niz, ili ima bolje rješenje

        string[] patologijaTrudnoce = new string[6];
        string[] komplikacije = new string[10];

        DateTime datumRodenja;

        // (3) provjeriti da li je dobro koristiti bool, ili ima bolje rješenje

        bool trudnocaPlodna, trudnocaPrirodna, nacinPoroda, prom, febrilitetRodilje, reanimacija;
        
        // (4) napraviti konstruktor do kraja tako da kreira sve potrebne podatke u objektu
        public Pacijent(string Ime, string Prezime, string ImeMajke, string ImeOca, string Adresa, string KontaktTelefon,
            string Spol, string ParitetTrudnoce, string StavDjeteta, string Profilaksa, DateTime DatumRodenja, bool TrudnocaPrirodna,
            string TrajanjePoroda)
        {
            imePacijenta = Ime;
            prezimePacijenta = Prezime;
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
        
        
    }
}

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
            ImePacijenta = Ime;
            PrezimePacijenta = Prezime;
            this.ImeMajke = ImeMajke;
            this.ImeOca = ImeOca;
            this.Adresa = Adresa;
            this.KontaktTelefon = KontaktTelefon;
            this.Spol = Spol;
            this.ParitetTrudnoce = ParitetTrudnoce;
            this.StavDjeteta = StavDjeteta;
            this.Profilaksa = Profilaksa;
            this.DatumRodenja = DatumRodenja;
            this.TrudnocaPrirodna = TrudnocaPrirodna;
            this.TrajanjePoroda = TrajanjePoroda;
        }

        public int Id { get => id; set => id = value; }
        public int GestacijskaDobTjedana { get => gestacijskaDobTjedana; set => gestacijskaDobTjedana = value; }
        public int GestacijskaDobDana { get => gestacijskaDobDana; set => gestacijskaDobDana = value; }
        public int RodnaMasa { get => rodnaMasa; set => rodnaMasa = value; }
        public int RodnaTezina { get => rodnaTezina; set => rodnaTezina = value; }
        public int OpsegGlave { get => opsegGlave; set => opsegGlave = value; }
        public string ImePacijenta { get => imePacijenta; set => imePacijenta = value; }
        public string PrezimePacijenta { get => prezimePacijenta; set => prezimePacijenta = value; }
        public string ImeMajke { get => imeMajke; set => imeMajke = value; }
        public string ImeOca { get => imeOca; set => imeOca = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public string Spol { get => spol; set => spol = value; }
        public string ParitetTrudnoce { get => paritetTrudnoce; set => paritetTrudnoce = value; }
        public string StavDjeteta { get => stavDjeteta; set => stavDjeteta = value; }
        public string Profilaksa { get => profilaksa; set => profilaksa = value; }
        public string ApgarIndeks { get => apgarIndeks; set => apgarIndeks = value; }
        public string TrajanjePoroda { get => trajanjePoroda; set => trajanjePoroda = value; }
        public string[] PatologijaTrudnoce { get => patologijaTrudnoce; set => patologijaTrudnoce = value; }
        public string[] Komplikacije { get => komplikacije; set => komplikacije = value; }
        public DateTime DatumRodenja { get => datumRodenja; set => datumRodenja = value; }
        public bool TrudnocaPlodna { get => trudnocaPlodna; set => trudnocaPlodna = value; }
        public bool TrudnocaPrirodna { get => trudnocaPrirodna; set => trudnocaPrirodna = value; }
        public bool NacinPoroda { get => nacinPoroda; set => nacinPoroda = value; }
        public bool Prom { get => prom; set => prom = value; }
        public bool FebrilitetRodilje { get => febrilitetRodilje; set => febrilitetRodilje = value; }
        public bool Reanimacija { get => reanimacija; set => reanimacija = value; }
    }
}

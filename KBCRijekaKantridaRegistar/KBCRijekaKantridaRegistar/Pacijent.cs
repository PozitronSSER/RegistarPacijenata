// uklonio nepotrebne using

using System;

namespace KBCRijekaKantridaRegistar
{
    class Pacijent
    {
        // (1) provjeriti da li su sve varijable u redu

        int id, gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaTezina, opsegGlave;
        string Ime, Prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,
            apgarIndeks, trajanjePoroda,trudnocaPlodna, trudnocaPrirodna;
        
        // (2) provjeriti da li je dobro koristiti niz, ili ima bolje rješenje

       // string[] patologijaTrudnoce = new string[6];
       // string[] komplikacije = new string[10];

        DateTime datumRodenja;

        // (3) provjeriti da li je dobro koristiti bool, ili ima bolje rješenje

        bool prom, febrilitetRodilje, reanimacija,krvarenje, dijabetes, ppi,
            infekcije, hipertenzija, eph, ostaloPatologija;
        bool hipoglikemija, rds, mehaničkaventilacija, sepsa, hiperbilirubinemija, konvulzije, pvl, PV_IVH, NEC, ROP, ostaloKomplikacije;
        string nacinPoroda, ostaloTextKomplikacije;
       
/*      private string trudnocaPlodna1;
        private string trudnocaPlodna2;

        public bool OstaloKomplikacije { get; private set; }
        public string OstaloTextKomplikacije { get; private set; }
*/
        // (4) napraviti konstruktor do kraja tako da kreira sve potrebne podatke u objektu
        public Pacijent(string Ime, string Prezime, string ImeMajke, string ImeOca, string Adresa, string KontaktTelefon,
            string Spol, string ParitetTrudnoce, string StavDjeteta, string Profilaksa, DateTime DatumRodenja, string TrudnocaPrirodna,
            string TrajanjePoroda,string TrudnocaPlodna, bool Prom,string NacinPoroda, bool FebrilitetRoditelj, bool Reanimacija, bool Krvarenje,
            bool Dijabetes, bool PPI, bool Infekcije, bool Hipertenzija, bool EPH, bool OstaloPatologija, bool Hipoglikemija, bool RDS, 
            bool Mehaničkaventilacija,bool Sepsa, bool Hiperbilirubinemija, bool Konvulzije, bool PVL, bool PV_IVH, bool NEC, bool ROP, bool OstaloKomplikacije, 
            string OstaloTextKomplikacije)
        {
            this.Ime = Ime;
            this.Prezime = Prezime;
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
            this.TrudnocaPlodna = TrudnocaPlodna;
            this.NacinPoroda = NacinPoroda;
            this.Prom = Prom;
            this.FebrilitetRodilje = FebrilitetRodilje; // Zašto je potamnjena ? 
            this.Reanimacija = Reanimacija;
            this.Krvarenje = Krvarenje;
            this.Dijabetes = Dijabetes;
            this.PPI = PPI;
            this.Infekcije = Infekcije;
            this.Hipertenzija = Hipertenzija;
            this.EPH = EPH;

            this.OstaloPatologija = OstaloPatologija;
            this.Hipoglikemija = Hipoglikemija;
            this.RDS = RDS;
            this.Mehaničkaventilacija = Mehaničkaventilacija;
            this.Sepsa = Sepsa;
            this.Hiperbilirubinemija = Hiperbilirubinemija;
            this.Konvulzije = Konvulzije;
            this.PVL = PVL;
            this.PV_IVH = PV_IVH;
            this.NEC = NEC;
            this.ROP = ROP;
            this.OstaloKomplikacije = OstaloKomplikacije;
            this.OstaloTextKomplikacije = OstaloTextKomplikacije;
        }

    /*    public Pacijent(string ime, string prezime, string imeMajke, string imeOca, string adresa, string kontaktTelefon, string spol, string paritetTrudnoce, string stavDjeteta, string profilaksa, string apgarIndeks, string trajanjePoroda, string trudnocaPlodna1, string trudnocaPlodna2, bool checked1, string nacinPoroda, bool checked2, bool checked3, bool checked4, bool checked5, bool checked6, bool checked7, bool checked8, bool checked9, bool checked10, bool checked11, bool checked12, bool checked13, bool checked14, bool checked15, bool checked16, bool checked17, bool checked18, bool checked19, bool checked20, bool checked21, string text)
        {
            Ime = ime;
            Prezime = prezime;
            this.imeMajke = imeMajke;
            this.imeOca = imeOca;
            this.adresa = adresa;
            this.kontaktTelefon = kontaktTelefon;
            this.spol = spol;
            this.paritetTrudnoce = paritetTrudnoce;
            this.stavDjeteta = stavDjeteta;
            this.profilaksa = profilaksa;
            this.apgarIndeks = apgarIndeks;
            this.trajanjePoroda = trajanjePoroda;
            this.trudnocaPlodna1 = trudnocaPlodna1;
            this.trudnocaPlodna2 = trudnocaPlodna2;
            this.checked1 = checked1;
            this.nacinPoroda = nacinPoroda;
    
        }*/

        // skužio sam kako ovo napraviti automatski, podsjetite me da vam pokažem
        // @Lovro Šverko - ubacio sam ostale; kako sada automatski getere i setere ?

        public int Id { get => id; set => id = value; }
        public int GestacijskaDobTjedana { get => gestacijskaDobTjedana; set => gestacijskaDobTjedana = value; }
        public int GestacijskaDobDana { get => gestacijskaDobDana; set => gestacijskaDobDana = value; }
        public int RodnaMasa { get => rodnaMasa; set => rodnaMasa = value; }
        public int RodnaTezina { get => rodnaTezina; set => rodnaTezina = value; }
        public int OpsegGlave { get => opsegGlave; set => opsegGlave = value; }
        public string ImePacijenta { get => Ime; set => Ime = value; }
        public string PrezimePacijenta { get => Prezime; set => Prezime = value; }
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
        
        // public string[] PatologijaTrudnoce { get => patologijaTrudnoce; set => patologijaTrudnoce = value; }
        // public string[] Komplikacije { get => komplikacije; set => komplikacije = value; }
        public DateTime DatumRodenja { get => datumRodenja; set => datumRodenja = value; }
        public string TrudnocaPlodna { get => trudnocaPlodna; set => trudnocaPlodna = value; }
        public string TrudnocaPrirodna { get => trudnocaPrirodna; set => trudnocaPrirodna = value; }
        public string NacinPoroda { get => nacinPoroda; set => nacinPoroda = value; }
        public bool Prom { get => prom; set => prom = value; }
        public bool FebrilitetRodilje { get => febrilitetRodilje; set => febrilitetRodilje = value; }
        public bool Reanimacija { get => reanimacija; set => reanimacija = value; }
        public string OstaloTextKomplikacije { get => ostaloTextKomplikacije; set => ostaloTextKomplikacije = value;  }
        public bool OstaloKomplikacije { get => ostaloKomplikacije; set => ostaloKomplikacije = value; }
        public bool Krvarenje { get => krvarenje; set => krvarenje = value; }
        public bool Dijabetes { get => dijabetes; set => dijabetes = value; }
        public bool PPI { get => ppi; set => ppi = value; }
        public bool Infekcije { get => infekcije; set => infekcije = value; }
        public bool Hipertenzija { get => hipertenzija; set => hipertenzija = value; }
        public bool EPH { get => eph; set => eph = value; }
        public bool OstaloPatologija { get; }
        public bool Hipoglikemija { get; }
        public bool RDS { get; }
        public bool Mehaničkaventilacija { get; }
        public bool Sepsa { get; }
        public bool Hiperbilirubinemija { get; }
        public bool Konvulzije { get; private set; }
        public bool PVL { get => pvl; set => pvl = value; }

    } 
}

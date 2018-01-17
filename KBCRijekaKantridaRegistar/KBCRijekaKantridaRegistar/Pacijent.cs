

using System;

namespace KBCRijekaKantridaRegistar
{
    class Pacijent
    {
        //deklaracija varijabli

        int id, gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaTezina, opsegGlave;
        string Ime, Prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,
            apgarIndeks, trajanjePoroda,trudnocaPlodna, trudnocaPrirodna;


        DateTime datumRodenja;


        bool prom, febrilitetRodilje, reanimacija,krvarenje, dijabetes, ppi,
            infekcije, hipertenzija, eph, ostaloPatologija;
        bool hipoglikemija, rds, mehaničkaventilacija, sepsa, hiperbilirubinemija, konvulzije, pvl, PV_IVH, NEC, ROP, ostaloKomplikacije;
        string nacinPoroda, ostaloTextKomplikacije;
       
        //konstruktor sa svim podatcima
        public Pacijent(string Ime, string Prezime, string ImeMajke, string ImeOca, string Adresa, string KontaktTelefon,
            string Spol, string ParitetTrudnoce, string StavDjeteta, string Profilaksa, DateTime DatumRodenja, string TrudnocaPrirodna,
            string TrajanjePoroda,string TrudnocaPlodna, bool Prom,string NacinPoroda, bool FebrilitetRoditelj, bool Reanimacija, bool Krvarenje,
            bool Dijabetes, bool PPI, bool Infekcije, bool Hipertenzija, bool EPH, bool OstaloPatologija, bool Hipoglikemija, bool RDS, 
            bool Mehaničkaventilacija,bool Sepsa, bool Hiperbilirubinemija, bool Konvulzije, bool PVL, bool PV_IVH, bool NEC, bool ROP, bool OstaloKomplikacije, 
            string OstaloTextKomplikacije)
        {
            //pridodavanje vrijednosti
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
            this.FebrilitetRodilje = FebrilitetRodilje;
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


        //automatski generirani geteri i seteri
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

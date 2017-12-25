using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBCRijekaKantridaRegistar.GUI
{
    class Buffer
    {
        public static int sifraPacijenta = 0; // trebao bi čitati zadnju šifru iz xml dokumenta

        int id, gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaDuljina, opsegGlave;
        string ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa
        string apgarIndeks, trajanjePoroda;
        string naciPoroda2, promTekst, febrilitet;
        string plodnostTrudnoce;
        string nacinTrudnoce;
        string reanimacijaTekst;
        DateTime datumRodenja;
        bool trudnocaPlodna, trudnocaPrirodna, nacinPoroda, prom, febrilitetRodilje, reanimacija;
        string[] patologijaTrudnoce = new string[6];
        string[] komplikacije = new string[10];

        public int Id { get => id; set => id = value; }
        public int GestacijskaDobTjedana { get => gestacijskaDobTjedana; set => gestacijskaDobTjedana = value; }
        public int GestacijskaDobDana { get => gestacijskaDobDana; set => gestacijskaDobDana = value; }
        public int RodnaMasa { get => rodnaMasa; set => rodnaMasa = value; }
        public int RodnaDuljina { get => rodnaDuljina; set => rodnaDuljina = value; }
        public int OpsegGlave { get => opsegGlave; set => opsegGlave = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string ImeMajke { get => imeMajke; set => imeMajke = value; }
        public string ImeOca { get => imeOca; set => imeOca = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public string Spol { get => spol; set => spol = value; }
        public string ParitetTrudnoce { get => paritetTrudnoce; set => paritetTrudnoce = value; }
        public string StavDjeteta { get => stavDjeteta; set => stavDjeteta = value; }
        public string Profilaksa { get => profilaksa; set => profilaksa = value; }
        public DateTime DatumRodenja { get => datumRodenja; set => datumRodenja = value; }
        public bool TrudnocaPlodna { get => trudnocaPlodna; set => trudnocaPlodna = value; }
        public bool TrudnocaPrirodna { get => trudnocaPrirodna; set => trudnocaPrirodna = value; }
        public bool NacinPoroda { get => nacinPoroda; set => nacinPoroda = value; }
        public bool Prom { get => prom; set => prom = value; }
        public bool FebrilitetRodilje { get => febrilitetRodilje; set => febrilitetRodilje = value; }
        public bool Reanimacija { get => reanimacija; set => reanimacija = value; }
        public string[] PatologijaTrudnoce { get => patologijaTrudnoce; set => patologijaTrudnoce = value; }
        public string[] Komplikacije { get => komplikacije; set => komplikacije = value; }
        public string PlodnostTrudnoce { get => plodnostTrudnoce; set => plodnostTrudnoce = value; }
        public string NacinTrudnoce { get => nacinTrudnoce; set => nacinTrudnoce = value; }
        public string NaciPoroda2 { get => naciPoroda2; set => naciPoroda2 = value; }
        public string PromTekst { get => promTekst; set => promTekst = value; }
        public string Febrilitet { get => febrilitet; set => febrilitet = value; }
        public string ApgarIndeks { get => apgarIndeks; set => apgarIndeks = value; }
        public string TrajanjePoroda { get => trajanjePoroda; set => trajanjePoroda = value; }
        public string ReanimacijaTekst { get => reanimacijaTekst; set => reanimacijaTekst = value; }

        public Buffer()
        {
            
        }
    }
}

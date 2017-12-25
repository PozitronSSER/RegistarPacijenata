using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBCRijekaKantridaRegistar.GUI
{
    class Buffer
    {
        static int sifraPacijenta = 0;

        int id, gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaTezina, opsegGlave;
        string ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,
            apgarIndeks, trajanjePoroda;
        DateTime datumRodenja;
        bool trudnocaPlodna, trudnocaPrirodna, nacinPoroda, prom, febrilitetRodilje, reanimacija;
        string[] patologijaTrudnoce = new string[6];
        string[] komplikacije = new string[10];

        public int Id { get => id; set => id = value; }
        public int GestacijskaDobTjedana { get => gestacijskaDobTjedana; set => gestacijskaDobTjedana = value; }
        public int GestacijskaDobDana { get => gestacijskaDobDana; set => gestacijskaDobDana = value; }
        public int RodnaMasa { get => rodnaMasa; set => rodnaMasa = value; }
        public int RodnaTezina { get => rodnaTezina; set => rodnaTezina = value; }
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

        public Buffer()
        {
            
        }
    }
}

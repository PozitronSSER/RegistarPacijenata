using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace KBCRijekaKantridaRegistar

    /*      ***** RIJEŠENO *****
     @Karlo-Graf 
     Što se tiče prebacivanja podataka u XML, možda bi bilo dobro spremiti podatke sa forme u "prijelazne" varijable, 
     jer mi se čini da ćemo imati više formi za upis podataka, 
     pa da ne radimo akrobacije sa izradom objekta (npr. string imePacijentaUnos = txtOsnovnipodatciIme.Text;).
     Na taj način onda u konstruktoru koristimo te varijable kao argumente,
     umjesto Text svojstva neke kontrole na nekoj formi. 
     If you know what I mean.
    */
{
    public partial class Form1 : Form
    {
        int brojac = 0;

        // čemu ono ova varijabla? ne sjećam se
        public bool trudnocaPrirodnaSwitch;


        public Form1()
        {
            InitializeComponent();
        }

        
          // metoda za preuzimanje podataka iz ListCheckBoxa-a u string[]

       /* public string[] komplikacija()
        {
            string[] komplikacije = new string[chkListBoxNovorodenceKomplikacije.Items.Count];

            // korištenje List<> umjesto array
            List<string> komItems = new List<string>();

            foreach (string item in chkListBoxNovorodenceKomplikacije.CheckedItems)
            {

                komItems.Add(item);

            }
            if (chkBoxNovorođenčeKomplikacijeOstalo.Checked)
            {
                string komplikacijaOstalo = txtNovorođenčeKomplikacijeOstalo.Text;
                komItems.Add(komplikacijaOstalo);
            }

            // pretvaranje List<> u string[]
            komplikacije = komItems.ToArray();
            return komplikacije;

        } 
        
        public string[] patologija()
        {
            string[] patologije = new string[chkListBoxPatologijaTrudnoće.Items.Count];

            List<string> patItems = new List<string>();

            foreach (string item in chkListBoxPatologijaTrudnoće.CheckedItems)
            {
                patItems.Add(item);
            }
            if (chkBoxPatologijaTrudnoćeOstalo.Checked)
            {
                string patologijaOstalo = txtPatologijaTrudnoćeOstalo.Text;
                patItems.Add(patologijaOstalo);
            }

            patologije = patItems.ToArray();
            return patologije;

        }

        
        //nesto s neta za pretvaranje string array-a u string
        static string ConvertStringArrayToStringJoin(string[] array)
        {
            string result = string.Join(",", array);
            return result;
        }
        */

        // upis podataka nakon odabira opcije "Upiši"

        private void button1_Click(object sender, EventArgs e)
        {

            /********** PROVJERA UNOSA POČETAK **********/

            if (txtGestacijskadobTjedana.Text=="")
            {
                MessageBox.Show("Neispravni unos Gestacijska dob tjedana");
                goto Kraj;
            }
            
            if (txtGestacijskadobDana.Text == "")
            {
                MessageBox.Show("Neispravni unos Gestacijska dob dana");
                goto Kraj;
            }
            if (txtNovorodenceRodnamasa.Text == "")
            {
                MessageBox.Show("Neispravni unos rodne mase");
                goto Kraj;
            }
            if (txtNovorodenceRodnaduljina.Text == "")
            {
                MessageBox.Show("Neispravni unos rodne duljine");
                goto Kraj;
            }
            if (txtNovorodenceRodnaduljina.Text == "")
            {
                MessageBox.Show("Neispravni unos rodne duljine");
                goto Kraj;
            }
            if (txtNovorodenceOpsegglave.Text == "")
            {
                MessageBox.Show("Neispravni unos opsega glave");
                goto Kraj;
            }
            /*@Lovro Sverko da stavim ove ifove za sva polja ili samo za intove, ako da da stavim
             error samo ako je prazno  ili da bas nesto provjeravam
             (npr masa nemoze biti manja od 100)*/

            /* @Karlo Graf
             * 
             Napraviti ćemo provjeru podataka tako da će se provjeravati da li je sve potrebno unešeno
             i dobit ćemo krajnje vrijednosti za neke od podataka.
             */

            /********** PROVJERA UNOSA KRAJ **********/

            int id, gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaDuljina, opsegGlave;
            string ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,
                apgarIndeks, trajanjePoroda;

            string krvarenje, dijabetes, ppi, infekcije, hipertenzija, eph, ostaloPatologija, ostaloTextPatologija, trudnocaPlodna, trudnocaPrirodna, 
                nacinPoroda, prom, febrilitetRodilje, reanimacija; //stavio sam string umjesto bool jer ce se kasnije nesto mijenjati
            string hipoglikemija, rds, mehaničkaventilacija, sepsa, hiperbilirubinemija, konvulzije, pvl, pv_ivh, nec, rop, ostaloKomplikacije, ostaloTextKomplikacije; 
            // Ne koristimo više ChkBox List
            // string[] prijelazKomplikacije = new string[11];
            // string[] prijelazPatologija = new string[7];

            // (2) provjeriti da li je dobro koristiti niz, ili ima bolje rješenje



            DateTime datumRodenja;
            //korištenje prijelaznih varijabli

            
            gestacijskaDobTjedana = Convert.ToInt32(txtGestacijskadobTjedana.Text);
            gestacijskaDobDana = Convert.ToInt32(txtGestacijskadobDana.Text);
            rodnaMasa = Convert.ToInt32(txtNovorodenceRodnamasa.Text);
            rodnaDuljina = Convert.ToInt32(txtNovorodenceRodnaduljina.Text);
            opsegGlave = Convert.ToInt32(txtNovorodenceOpsegglave.Text);

    
            ime = txtOsnovnipodatciIme.Text;
            prezime = txtOsnovnipodatciPrezime.Text;
            imeMajke = txtOsnovnipodatciImemajke.Text;
            imeOca = txtOsnovnipodatciImeoca.Text;
            adresa = txtOsnovnipodatciAdresa.Text;
            kontaktTelefon = txtOsnovnipodatciKontakttelefon.Text;
            spol = txtOsnovnipodatciSpol.Text;
            paritetTrudnoce = txtTrudnoćaParitet.Text;
            stavDjeteta = txtPorodStavdjeteta.Text;
            profilaksa = txtPorodKortikosteroidnaprofilaksa.Text;
            apgarIndeks = txtNovorodenceApgarindeks.Text;
            trajanjePoroda = txtPorodTrajanjeporoda.Text;
            krvarenje = chkBoxPatologijatrudnoceKrvarenje.Text;
            dijabetes = chkBoxPatologijatrudnoceDijabetes.Text;
            ppi = chkBoxPatologijatrudnocePPI.Text;
            infekcije = chkBoxPatologijatrudnoceInfekcije.Text;
            hipertenzija = chkBoxPatologijatrudnoceHipertenzija.Text;
            eph = chkBoxPatologijatrudnoceEPH.Text;
            ostaloPatologija = chkBoxPatologijaTrudnoćeOstalo.Text;
            hipoglikemija = chkBoxNovorođenčeHipoglikemija.Text;
            rds = chkBoxNovorođenčeRDS.Text;
            mehaničkaventilacija = chkBoxNovorođenčeMehVentilacija.Text;
            sepsa = chkBoxNovorođenčeSepsa.Text;
            hiperbilirubinemija = chkBoxNovorođenčeHiperbilirubinemija.Text;
            konvulzije = chkBoxNovorođenčeKonvulzije.Text;
            pvl = chkBoxNovorođenčePVL.Text;
            pv_ivh = chkBoxNovorođenčePVIVH.Text;
            nec = chkBoxNovorođenčeNEC.Text;
            rop = chkBoxNovorođenčeROP.Text;
            ostaloKomplikacije = chkBoxNovorođenčeOstalo.Text;
            
            

            trudnocaPlodna = Convert.ToString(rbtnTrunocaJednoplodna.Checked);
            trudnocaPrirodna = Convert.ToString(rbtnTrunocaPrirodna.Checked);
            nacinPoroda = Convert.ToString(rbtnPorodCarskirez.Checked);
            prom = Convert.ToString(chkBoxPorodPROM.Checked);
            febrilitetRodilje = Convert.ToString(chkBoxPorodFebrilitetrodilje.Checked);
            reanimacija = Convert.ToString(chkBoxNovorodenceReanimacija.Checked);

           /* prijelazPatologija = patologija();
            prijelazKomplikacije = komplikacija();*/  //ovaj dio sam vjv bezveze zakomplicirao al nema veze

            datumRodenja = Convert.ToDateTime(txtOsnovnipodatciDatumrođenja.Text);


            //pretvaranje "true" u "da" ... ipak smo Hrvati


            //  svi "bool" podaci trebaju biti u obliku 1-true, 2-false, a kod izvoza u .xml dokument
            //  XElement će biti naslov chkBox kontrole 

            // Dodavanje chkBox-ova iz chkBoxListe 
             
            if (hipoglikemija == "True")
                hipoglikemija = "Da";
            else
                hipoglikemija = "Ne";

            if ( rds == "True")
                rds  = "Da";
            else
                rds = "Ne";

            if ( mehaničkaventilacija == "True")
                 mehaničkaventilacija= "Da";
            else
                 mehaničkaventilacija = "Ne";

            if ( sepsa == "True")
                 sepsa = "Da";
            else
                sepsa = "Ne";

            if ( hiperbilirubinemija == "True")
                 hiperbilirubinemija = "Da";
            else
                 hiperbilirubinemija = "Ne";

            if ( konvulzije == "True")
                 konvulzije = "Da";
            else
                 konvulzije = "Ne";

            if ( pvl == "True")
                pvl = "Da";
            else
                pvl = "Ne";

            if ( pv_ivh== "True")
                 pv_ivh = "Da";
            else
                 pv_ivh = "Ne";

            if ( nec== "True")
                 nec = "Da";
            else
                 nec = "Ne";

            if ( rop== "True")
                 rop= "Da";
            else
                 rop= "Ne";

            if ( ostaloKomplikacije == "True")
                 ostaloTextKomplikacije = "Da";
            else
                 ostaloTextKomplikacije = "Ne";


            if (ostaloPatologija == "True")
                ostaloTextPatologija = txtPatologijaTrudnoćeOstalo.Text;
            else
                ostaloTextPatologija = "";

            if (krvarenje == "True")
                krvarenje = "Da";
            else
                krvarenje = "Ne";

            if (dijabetes == "True")
                dijabetes = "Da";
            else
                dijabetes = "Ne";

            if (ppi == "True")
                ppi = "Da";
            else
                ppi = "Ne";

            if (infekcije == "True")
                infekcije = "Da";
            else
                infekcije = "Ne";

            if (hipertenzija == "True")
                hipertenzija = "Da";
            else
                hipertenzija = "Ne";

            if (eph == "True")
                eph = "Da";
            else
                eph = "Ne";

            if (trudnocaPlodna == "True")
                trudnocaPlodna = "Jednoplodna";
            else
                trudnocaPlodna = "Višeplodna";

            if (trudnocaPrirodna == "True")
                trudnocaPrirodna = "Prirodna";
            else
                trudnocaPrirodna = "Potpomognuta";

            if (nacinPoroda == "True")
                nacinPoroda = "Carski rez";
            else
                nacinPoroda = "Vaginalno";

            if (reanimacija == "True")
                reanimacija = "Da";
            else
                reanimacija = "Ne";


            if (febrilitetRodilje == "True")
                febrilitetRodilje = "Da";
            else
                febrilitetRodilje = "Ne";

            if (prom == "True")
                prom = "Da";
            else
                prom = "Ne";
            // kreiranje objekta pacijent

            // (1) napraviti objekt pomoću ispravnog konstruktora

            Pacijent pacijent = new Pacijent(ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,datumRodenja, trajanjePoroda,trudnocaPlodna, trudnocaPlodna, chkBoxPorodPROM.Checked,nacinPoroda, chkBoxPorodFebrilitetrodilje.Checked, chkBoxNovorodenceReanimacija.Checked, chkBoxPatologijatrudnoceKrvarenje.Checked, chkBoxPatologijatrudnoceDijabetes.Checked, chkBoxPatologijatrudnocePPI.Checked, chkBoxPatologijatrudnoceInfekcije.Checked, chkBoxPatologijatrudnoceHipertenzija.Checked, chkBoxPatologijatrudnoceEPH.Checked, chkBoxPatologijaTrudnoćeOstalo.Checked, chkBoxNovorođenčeHipoglikemija.Checked, chkBoxNovorođenčeRDS.Checked, chkBoxNovorođenčeMehVentilacija.Checked,chkBoxNovorođenčeSepsa.Checked, chkBoxNovorođenčeHiperbilirubinemija.Checked, chkBoxNovorođenčeKonvulzije.Checked,chkBoxNovorođenčePVL.Checked, chkBoxNovorođenčePVIVH.Checked, chkBoxNovorođenčeNEC.Checked, chkBoxNovorođenčeROP.Checked, chkBoxNovorođenčeOstalo.Checked, txtNovorođenčeOstalo.Text);

           /* Pacijent pacijent = new Pacijent(ime, prezime, imeMajke,
               imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa, datumRodenja,
               rbtnTrunocaPrirodna.Text/*trazi bool, a ja sam koristio string pa cu zasad ovako, trajanjePoroda, trudnocaPlodna, nacinPowroda,
               chkBoxPorodPROM.Checked, chkBoxPorodFebrilitetrodilje.Checked, chkBoxNovorodenceReanimacija.Checked, chkBoxPatologijatrudnoceKrvarenje.Checked, chkBoxPatologijatrudnoceDijabetes.Checked, chkBoxPatologijatrudnocePPI.Checked, chkBoxPatologijatrudnoceInfekcije.Checked, chkBoxPatologijatrudnoceHipertenzija.Checked, chkBoxPatologijatrudnoceEPH.Checked, chkBoxPatologijaTrudnoćeOstalo.Checked, chkBoxNovorođenčeHipoglikemija.Checked, chkBoxNovorođenčeRDS.Checked, chkBoxNovorođenčeMehVentilacija.Checked,
               chkBoxNovorođenčeSepsa.Checked, chkBoxNovorođenčeHiperbilirubinemija.Checked, chkBoxNovorođenčeKonvulzije.Checked, chkBoxNovorođenčePVL.Checked, chkBoxNovorođenčePVIVH.Checked, chkBoxNovorođenčeNEC.Checked, chkBoxNovorođenčeROP.Checked, chkBoxNovorođenčeOstalo.Checked, ostaloTextKomplikacije);
              */
               // samo ovo treba sredit do kraja

            //prebacivanje podataka u xml


            // (2) prebaciti sve podatke u xml

            if (!File.Exists("Registar.xml"))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create("Registar.xml", xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Registar");
                    xmlWriter.WriteStartElement("Pacijent");

                    xmlWriter.WriteElementString("Ime", ime);
                    xmlWriter.WriteElementString("Prezime", prezime);
                    xmlWriter.WriteElementString("Imemajke", imeMajke);
                    xmlWriter.WriteElementString("Imeoca",imeOca);
                    xmlWriter.WriteElementString("Adresa", adresa);
                    xmlWriter.WriteElementString("Kontakttelefon", kontaktTelefon);
                    xmlWriter.WriteElementString("Datumrođenja", Convert.ToString(datumRodenja));
                    xmlWriter.WriteElementString("Spol", spol);
                    xmlWriter.WriteElementString("Paritettrudnoće", paritetTrudnoce);
                    xmlWriter.WriteElementString("PlodnostTrudnoće", trudnocaPlodna); 
                    xmlWriter.WriteElementString("PrirodaTrudnoće", trudnocaPrirodna); 
                    xmlWriter.WriteElementString("NačinPoroda",nacinPoroda); 
                    xmlWriter.WriteElementString("Trajanjeporoda", trajanjePoroda);
                    xmlWriter.WriteElementString("Stavdjeteta", stavDjeteta);
                    xmlWriter.WriteElementString("Profilaksa", profilaksa);
                    xmlWriter.WriteElementString("PROM", prom); 
                    xmlWriter.WriteElementString("Ferbrilitet", febrilitetRodilje);
                    //  xmlWriter.WriteElementString("Patologijatrudnoće", ConvertStringArrayToStringJoin(prijelazPatologija));
                    xmlWriter.WriteElementString("Krvarenje", krvarenje);
                    xmlWriter.WriteElementString("Dijabetes", dijabetes);
                    xmlWriter.WriteElementString("PPI", ppi);
                    xmlWriter.WriteElementString("Infekcije", hipertenzija);
                    xmlWriter.WriteElementString("Hipertenzija", hipertenzija);
                    xmlWriter.WriteElementString("EPH", eph);
                    xmlWriter.WriteElementString("Ostalo", ostaloTextPatologija);
                    xmlWriter.WriteElementString("Gestacijskadobtjedni", Convert.ToString(gestacijskaDobTjedana));
                    xmlWriter.WriteElementString("Gestacijskadobdani", Convert.ToString(gestacijskaDobDana));
                    xmlWriter.WriteElementString("Rodnamasa", Convert.ToString(rodnaMasa));
                    xmlWriter.WriteElementString("Rodnaduljina", Convert.ToString(rodnaDuljina));
                    xmlWriter.WriteElementString("Opsegglave", Convert.ToString(opsegGlave));
                    xmlWriter.WriteElementString("Apgarindeks", apgarIndeks);
                    xmlWriter.WriteElementString("Reanimacija", reanimacija);
                    //  xmlWriter.WriteElementString("Komplikacije",ConvertStringArrayToStringJoin(prijelazKomplikacije));

                    

                    xmlWriter.WriteElementString("Hipoglikemija", hipoglikemija);
                    xmlWriter.WriteElementString("RDS", rds );
                    xmlWriter.WriteElementString("Mehanička ventilacija (>72h)", mehaničkaventilacija );
                    xmlWriter.WriteElementString("Sepsa",sepsa);
                    xmlWriter.WriteElementString("Hiperbilitubinemija",hiperbilirubinemija);
                    xmlWriter.WriteElementString("Konvulzije", konvulzije );
                    xmlWriter.WriteElementString("PVL", pvl);
                    xmlWriter.WriteElementString("PV-IVH",pv_ivh);
                    xmlWriter.WriteElementString("NEC", nec );
                    xmlWriter.WriteElementString("ROP",rop);
                    xmlWriter.WriteElementString("Ostalo komplikacije",ostaloTextKomplikacije);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load("Registar.xml");
                XElement root = xDocument.Element("Registar");
                IEnumerable<XElement> rows = root.Descendants("Pacijent"); //,new XElement()
                XElement firstRow = rows.First();

                firstRow.AddBeforeSelf(
                    new XElement("Pacijent",
                    new XElement("Ime", ime),
                    new XElement("Prezime", prezime),
                    new XElement("Imemajke", imeMajke),
                    new XElement("Imeoca", imeOca),
                    new XElement("Adresa", adresa),
                    new XElement("Kontakttelefon", kontaktTelefon),
                    new XElement("Datumrođenja", Convert.ToString(datumRodenja)),
                    new XElement("Spol", spol),
                    new XElement("Paritettrudnoće", paritetTrudnoce),
                    new XElement("PlodnostTrudnoće", trudnocaPlodna),
                    new XElement("Prirodatrudnće", trudnocaPrirodna),
                    new XElement("NačinPoroda", nacinPoroda),
                    new XElement("Trajanjeporoda", trajanjePoroda),
                    new XElement("Stavdjeteta", stavDjeteta),
                    new XElement("Profilaksa", profilaksa),
                    new XElement("PROM", prom),
                    new XElement("Krvarenje", krvarenje),
                    new XElement("Dijabetes", dijabetes),
                    new XElement("PPI", ppi),
                    new XElement("Infekcije", infekcije),
                    new XElement("Hipertenzija", hipertenzija),
                    new XElement("EPH", eph),
                    new XElement("Ostalo", ostaloTextPatologija),
                    new XElement("Ferbrilitet", febrilitetRodilje),
                    // new XElement("Patologijatrudnoće",ConvertStringArrayToStringJoin(prijelazPatologija)), 
                    new XElement("Gestacijskadobtjedni", gestacijskaDobTjedana),
                    new XElement("Gestacijskadobdani", gestacijskaDobDana),
                    new XElement("Rodnamasa", rodnaMasa),
                    new XElement("Rodnaduljina", rodnaDuljina),
                    new XElement("Opsegglave", opsegGlave),
                    new XElement("Apgarindeks", apgarIndeks),
                    new XElement("Reanimacija", reanimacija),
                    new XElement("Hipoglikemija", hipoglikemija),
                    new XElement("RDS", rds),
                    new XElement("Mehanička_ventilacija_72h", mehaničkaventilacija),
                    new XElement("Sepsa", sepsa),
                    new XElement("Hiperbilirubinemija", hiperbilirubinemija),
                    new XElement("Konvulzije", konvulzije),
                    new XElement("PVL", pvl),
                    new XElement("PV-IVH", pv_ivh),
                    new XElement("NEC", nec),
                    new XElement("ROP", rop),
                    new XElement("Ostalo_komplikacije", ostaloTextKomplikacije)));
                // new XElement("Komplikacije",ConvertStringArrayToStringJoin(prijelazKomplikacije))


                xDocument.Save("Registar6.xml");
            }


            //čistimo podatke nakon unosa

            txtGestacijskadobDana.Clear();
            txtGestacijskadobTjedana.Clear();
            txtNovorodenceApgarindeks.Text = "00 / 00 / 00";
            txtNovorodenceOpsegglave.Clear();
            txtNovorodenceRodnaduljina.Clear();
            txtNovorodenceRodnamasa.Clear();
            txtNovorođenčeOstalo.Clear();
            txtOsnovnipodatciAdresa.Clear();
            txtOsnovnipodatciDatumrođenja.ResetText();
            txtOsnovnipodatciIme.Clear();
            txtOsnovnipodatciImemajke.Clear();
            txtOsnovnipodatciImeoca.Clear();
            txtOsnovnipodatciKontakttelefon.Clear();
            txtOsnovnipodatciPrezime.Clear();
            txtOsnovnipodatciSpol.ResetText();
            txtPatologijaTrudnoćeOstalo.Clear();
            txtPorodKortikosteroidnaprofilaksa.ResetText();
            txtPorodStavdjeteta.ResetText();
            txtPorodTrajanjeporoda.Clear();
            // txtTestIspis.Clear();
            txtTrudnoćaParitet.ResetText();
            rbtnPorodCarskirez.Checked = false;
            rbtnTrunocaJednoplodna.Checked = false;
            rbtnTrunocaPotpomognuta.Checked = false;
            rbtnTrunocaPrirodna.Checked = false;
            rbtnTrunocaViseplodna.Checked = false;
            rbtnVaginalno.Checked = false;
            chkBoxNovorodenceReanimacija.Checked = false;
            chkBoxNovorođenčeOstalo.Checked = false;
            chkBoxPatologijaTrudnoćeOstalo.Checked = false;
            chkBoxPorodFebrilitetrodilje.Checked = false;
            chkBoxPorodPROM.Checked = false;
            chkBoxPatologijatrudnoceDijabetes.Checked = false;
            chkBoxPatologijatrudnoceEPH.Checked = false;
            chkBoxPatologijatrudnoceHipertenzija.Checked = false;
            chkBoxPatologijatrudnoceInfekcije.Checked = false;
            chkBoxPatologijatrudnoceKrvarenje.Checked = false;
            chkBoxPatologijatrudnocePPI.Checked = false;
            chkBoxPatologijaTrudnoćeOstalo.Checked = false;
            txtPatologijaTrudnoćeOstalo.Clear();
            chkBoxNovorođenčeHiperbilirubinemija.Checked = false;
            chkBoxNovorođenčeHipoglikemija.Checked = false;
            chkBoxNovorođenčeKonvulzije.Checked = false;
            chkBoxNovorođenčeMehVentilacija.Checked = false;
            chkBoxNovorođenčeNEC.Checked = false;
            chkBoxNovorođenčeOstalo.Checked = false;
            chkBoxNovorođenčePVIVH.Checked = false;
            chkBoxNovorođenčePVL.Checked = false;
            chkBoxNovorođenčeRDS.Checked = false;
            chkBoxNovorođenčeROP.Checked = false;
            chkBoxNovorođenčeSepsa.Checked = false;
            txtNovorođenčeOstalo.Clear();

            /*  
              foreach (int i in chkListBoxNovorodenceKomplikacije.CheckedIndices)
                {
                   chkListBoxNovorodenceKomplikacije.SetItemCheckState(i, CheckState.Unchecked);
                }



              foreach (int i in chkListBoxPatologijaTrudnoće.CheckedIndices)
                {
                    chkListBoxPatologijaTrudnoće.SetItemCheckState(i, CheckState.Unchecked);
                }*/
            Kraj: ;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxPatologijaTrudnoćeOstalo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBoxPatologijaTrudnoćeOstalo.Checked)
            {
                txtPatologijaTrudnoćeOstalo.Enabled = true;
            }
            else
            {
                txtPatologijaTrudnoćeOstalo.Enabled = false;
            }
        }

        private void chkBoxNovorođenčeKomplikacijeOstalo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxNovorođenčeOstalo.Checked)
            {
                txtNovorođenčeOstalo.Enabled = true;
            }
            else
            {
                txtNovorođenčeOstalo.Enabled = false;
            }
        }

        private void txtPatologijaTrudnoćeOstalo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOsnovnipodatciSpol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void txtTestIspis_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxPorodPROM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxNovorođenčeMehV_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtOsnovnipodatciDatumrođenja_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void txtPorodKortikosteroidnaprofilaksa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

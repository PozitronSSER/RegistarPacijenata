using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

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
            try
            {

                /********** PROVJERA UNOSA POČETAK **********/

                if (txtGestacijskadobTjedana.Text == "")
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
                    hipoglikemija = "1";
                else
                    hipoglikemija = "2";

                if (rds == "True")
                    rds = "1";
                else
                    rds = "2";

                if (mehaničkaventilacija == "True")
                    mehaničkaventilacija = "1";
                else
                    mehaničkaventilacija = "2";

                if (sepsa == "True")
                    sepsa = "1";
                else
                    sepsa = "2";

                if (hiperbilirubinemija == "True")
                    hiperbilirubinemija = "1";
                else
                    hiperbilirubinemija = "2";

                if (konvulzije == "True")
                    konvulzije = "1";
                else
                    konvulzije = "2";

                if (pvl == "True")
                    pvl = "1";
                else
                    pvl = "2";

                if (pv_ivh == "True")
                    pv_ivh = "1";
                else
                    pv_ivh = "2";

                if (nec == "True")
                    nec = "1";
                else
                    nec = "2";

                if (rop == "True")
                    rop = "1";
                else
                    rop = "2";

                if (ostaloKomplikacije == "True")
                    ostaloTextKomplikacije = "1";
                else
                    ostaloTextKomplikacije = "2";


                if (ostaloPatologija == "True")
                    ostaloTextPatologija = txtPatologijaTrudnoćeOstalo.Text;
                else
                    ostaloTextPatologija = "";

                if (krvarenje == "True")
                    krvarenje = "1";
                else
                    krvarenje = "2";

                if (dijabetes == "True")
                    dijabetes = "1";
                else
                    dijabetes = "2";

                if (ppi == "True")
                    ppi = "1";
                else
                    ppi = "2";

                if (infekcije == "True")
                    infekcije = "1";
                else
                    infekcije = "2";

                if (hipertenzija == "True")
                    hipertenzija = "1";
                else
                    hipertenzija = "2";

                if (eph == "True")
                    eph = "1";
                else
                    eph = "2";

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
                    reanimacija = "1";
                else
                    reanimacija = "2";


                if (febrilitetRodilje == "True")
                    febrilitetRodilje = "1";
                else
                    febrilitetRodilje = "2";

                if (prom == "True")
                    prom = "1";
                else
                    prom = "2";
                // kreiranje objekta pacijent

                // (1) napraviti objekt pomoću ispravnog konstruktora

                Pacijent pacijent = new Pacijent(ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa, datumRodenja, trajanjePoroda, trudnocaPlodna, trudnocaPlodna, chkBoxPorodPROM.Checked, nacinPoroda, chkBoxPorodFebrilitetrodilje.Checked, chkBoxNovorodenceReanimacija.Checked, chkBoxPatologijatrudnoceKrvarenje.Checked, chkBoxPatologijatrudnoceDijabetes.Checked, chkBoxPatologijatrudnocePPI.Checked, chkBoxPatologijatrudnoceInfekcije.Checked, chkBoxPatologijatrudnoceHipertenzija.Checked, chkBoxPatologijatrudnoceEPH.Checked, chkBoxPatologijaTrudnoćeOstalo.Checked, chkBoxNovorođenčeHipoglikemija.Checked, chkBoxNovorođenčeRDS.Checked, chkBoxNovorođenčeMehVentilacija.Checked, chkBoxNovorođenčeSepsa.Checked, chkBoxNovorođenčeHiperbilirubinemija.Checked, chkBoxNovorođenčeKonvulzije.Checked, chkBoxNovorođenčePVL.Checked, chkBoxNovorođenčePVIVH.Checked, chkBoxNovorođenčeNEC.Checked, chkBoxNovorođenčeROP.Checked, chkBoxNovorođenčeOstalo.Checked, txtNovorođenčeOstalo.Text);

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
                        xmlWriter.WriteElementString("Imeoca", imeOca);
                        xmlWriter.WriteElementString("Adresa", adresa);
                        xmlWriter.WriteElementString("Kontakt_telefon", kontaktTelefon);
                        xmlWriter.WriteElementString("Datum_rođenja", Convert.ToString(datumRodenja));
                        xmlWriter.WriteElementString("Spol", spol);
                        xmlWriter.WriteElementString("Paritet_trudnoće", paritetTrudnoce);
                        xmlWriter.WriteElementString("Plodnost_trudnoće", trudnocaPlodna);
                        xmlWriter.WriteElementString("Priroda_trudnoće", trudnocaPrirodna);
                        xmlWriter.WriteElementString("Način_poroda", nacinPoroda);
                        xmlWriter.WriteElementString("Trajanje_poroda", trajanjePoroda);
                        xmlWriter.WriteElementString("Stav_djeteta", stavDjeteta);
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
                        xmlWriter.WriteElementString("Gestacijska_dob_tjedni", Convert.ToString(gestacijskaDobTjedana));
                        xmlWriter.WriteElementString("Gestacijska_dob_dani", Convert.ToString(gestacijskaDobDana));
                        xmlWriter.WriteElementString("Rodna_masa", Convert.ToString(rodnaMasa));
                        xmlWriter.WriteElementString("Rodna_duljina", Convert.ToString(rodnaDuljina));
                        xmlWriter.WriteElementString("Opseg_glave", Convert.ToString(opsegGlave));
                        xmlWriter.WriteElementString("Apgar_indeks", apgarIndeks);
                        xmlWriter.WriteElementString("Reanimacija", reanimacija);
                        //  xmlWriter.WriteElementString("Komplikacije",ConvertStringArrayToStringJoin(prijelazKomplikacije));
                        xmlWriter.WriteElementString("Hipoglikemija", hipoglikemija);
                        xmlWriter.WriteElementString("RDS", rds);
                        xmlWriter.WriteElementString("Mehanička_ventilacija", mehaničkaventilacija);
                        xmlWriter.WriteElementString("Sepsa", sepsa);
                        xmlWriter.WriteElementString("Hiperbilirubinemija", hiperbilirubinemija);
                        xmlWriter.WriteElementString("Konvulzije", konvulzije);
                        xmlWriter.WriteElementString("PVL", pvl);
                        xmlWriter.WriteElementString("PV-IVH", pv_ivh);
                        xmlWriter.WriteElementString("NEC", nec);
                        xmlWriter.WriteElementString("ROP", rop);
                        xmlWriter.WriteElementString("Ostalo_komplikacije", ostaloTextKomplikacije);
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
                        new XElement("Kontakt_telefon", kontaktTelefon),
                        new XElement("Datum_rođenja", Convert.ToString(datumRodenja)),
                        new XElement("Spol", spol),
                        new XElement("Paritet_trudnoće", paritetTrudnoce),
                        new XElement("Plodnost_trudnoće", trudnocaPlodna),
                        new XElement("Priroda_trudnoće", trudnocaPrirodna),
                        new XElement("Način_poroda", nacinPoroda),
                        new XElement("Trajanje_poroda", trajanjePoroda),
                        new XElement("Stav_djeteta", stavDjeteta),
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
                        new XElement("Gestacijska_dob_tjedni", gestacijskaDobTjedana),
                        new XElement("Gestacijska_dob_dani", gestacijskaDobDana),
                        new XElement("Rodna_masa", rodnaMasa),
                        new XElement("Rodna_duljina", rodnaDuljina),
                        new XElement("Opseg_glave", opsegGlave),
                        new XElement("Apgar_indeks", apgarIndeks),
                        new XElement("Reanimacija", reanimacija),
                        new XElement("Hipoglikemija", hipoglikemija),
                        new XElement("RDS", rds),
                        new XElement("Mehanička_ventilacija", mehaničkaventilacija),
                        new XElement("Sepsa", sepsa),
                        new XElement("Hiperbilirubinemija", hiperbilirubinemija),
                        new XElement("Konvulzije", konvulzije),
                        new XElement("PVL", pvl),
                        new XElement("PV-IVH", pv_ivh),
                        new XElement("NEC", nec),
                        new XElement("ROP", rop),
                        new XElement("Ostalo_komplikacije", ostaloTextKomplikacije)));
                    // new XElement("Komplikacije",ConvertStringArrayToStringJoin(prijelazKomplikacije))


                    xDocument.Save("Registar.xml"); 
                }
                ResetVarijabli();
                
               

                /*  
                  foreach (int i in chkListBoxNovorodenceKomplikacije.CheckedIndices)
                    {
                       chkListBoxNovorodenceKomplikacije.SetItemCheckState(i, CheckState.Unchecked);
                    }



                  foreach (int i in chkListBoxPatologijaTrudnoće.CheckedIndices)
                    {
                        chkListBoxPatologijaTrudnoće.SetItemCheckState(i, CheckState.Unchecked);
                    }*/
            }
            catch (Exception d)
            {
                MessageBox.Show("Neispravan unos");
            }

            Kraj:;
            }
                public void ResetVarijabli()
                {
                txtGestacijskadobTjedana.Text = "";
                txtGestacijskadobTjedana_Leave(null, null);
                txtPorodStavdjeteta.Text = "";
                txtPorodStavdjeteta_Leave(null, null);
                txtPorodKortikosteroidnaprofilaksa.Text = "";
                txtPorodKortikosteroidnaprofilaksa_Leave(null, null);
                txtTrudnoćaParitet.Text = "";
                txtTrudnocaParitet_Leave(null, null);
                txtPorodStavdjeteta.Text = "";
                txtPorodStavdjeteta_Leave(null, null);
                txtPorodTrajanjeporoda.Text = "";
                txtPorodTrajanjeporoda_Leave(null, null);
                txtGestacijskadobDana.Text = "";
                txtGestacijskadobDana_Leave(null,null);
                txtNovorodenceApgarindeks.Text = "";
                txtNovorodenceApgarindeks_Leave(null, null);
                txtNovorodenceOpsegglave.Text = "";
                txtNovorodenceOpsegglave_Leave(null, null);
                txtNovorodenceRodnaduljina.Text = "";
                txtNovorodenceRodnaduljina_Leave(null, null);
                txtNovorodenceRodnamasa.Text = "";
                txtNovorodenceRodnamasa_Leave(null, null);
                txtNovorođenčeOstalo.Clear();               
                txtOsnovnipodatciAdresa.Text = "";
                txtOsnovnipodatciAdresa_Leave(null, null);
                txtOsnovnipodatciDatumrođenja.ResetText();
                txtOsnovnipodatciIme.Text = "";
                txtOsnovnipodatciIme_Leave(null, null);
                txtOsnovnipodatciImemajke.Text = "";
                txtOsnovnipodatciImeMajke_Leave(null, null);
                txtOsnovnipodatciImeoca.Text = "";
                txtOsnovnipodatciImeOca_Leave(null, null);
                txtOsnovnipodatciKontakttelefon.Text = "";
                txtOsnovnipodatciKontakttelefon_Leave(null, null);
                txtOsnovnipodatciPrezime.Text = "";
                txtOsnovnipodatciPrezime_Leave(null, null);
                txtOsnovnipodatciSpol.ResetText();
                txtOsnovnipodatciSpol_Leave(null, null);
                txtPatologijaTrudnoćeOstalo.Clear();
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
            
                PregledPodataka f2 = new PregledPodataka();
                f2.ShowDialog();
            
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

        private void txtOsnovnipodatciIme_TextChanged(object sender, EventArgs e)
        {
            
        }

        //----------------------------------------Enter - Leave ----------------------------------------

        // Ime
        

        private void txtOsnovnipodatciIme_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciIme.Text == "Ime")
            {
                txtOsnovnipodatciIme.Text = "";
                txtOsnovnipodatciIme.ForeColor = Color.Black;
            }
        }
       
        private void txtOsnovnipodatciIme_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciIme.Text == "")
            {
                txtOsnovnipodatciIme.Text = "Ime";
                txtOsnovnipodatciIme.ForeColor = Color.Gray;
            }
        }
        // Prezime
        private void txtOsnovnipodatciPrezime_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciPrezime.Text == "Prezime")
            {
                txtOsnovnipodatciPrezime.Text = "";
                txtOsnovnipodatciPrezime.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciPrezime_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciPrezime.Text == "")
            {
                txtOsnovnipodatciPrezime.Text = "Prezime";
                txtOsnovnipodatciPrezime.ForeColor = Color.Gray;
            }
        }
        // Spol

        private void txtOsnovnipodatciSpol_Enter(object sender, EventArgs e)
        {

            if (txtOsnovnipodatciSpol.Text == "Spol")
            {
                txtOsnovnipodatciSpol.Text = "";
                txtOsnovnipodatciSpol.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciSpol_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciSpol.Text == "")
            {
                txtOsnovnipodatciSpol.Text = "Spol";
                txtOsnovnipodatciSpol.ForeColor = Color.Gray;
            }
        }
        // Ime oca
        private void txtOsnovnipodatciImeOca_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciImeoca.Text == "Ime oca")
            {
                txtOsnovnipodatciImeoca.Text = "";
                txtOsnovnipodatciImeoca.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciImeOca_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciImeoca.Text == "")
            {
                txtOsnovnipodatciImeoca.Text = "Ime oca";
                txtOsnovnipodatciImeoca.ForeColor = Color.Gray;
            }
        }
        // IME MAJKE
        private void txtOsnovnipodatciImeMajke_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciImemajke.Text == "Ime majke")
            {
                txtOsnovnipodatciImemajke.Text = "";
                txtOsnovnipodatciImemajke.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciImeMajke_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciImemajke.Text == "")
            {
                txtOsnovnipodatciImemajke.Text = "Ime majke";
                txtOsnovnipodatciImemajke.ForeColor = Color.Gray;
            }
        }
        // Adresa
        private void txtOsnovnipodatciAdresa_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciAdresa.Text == "Adresa")
            {
                txtOsnovnipodatciAdresa.Text = "";
                txtOsnovnipodatciAdresa.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciAdresa_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciAdresa.Text == "")
            {
                txtOsnovnipodatciAdresa.Text = "Adresa";
                txtOsnovnipodatciAdresa.ForeColor = Color.Gray;
            }
        }
        // Kontakt telefon
        private void txtOsnovnipodatciKontakttelefon_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciKontakttelefon.Text == "Kontakt telefon")
            {
                txtOsnovnipodatciKontakttelefon.Text = "";
                txtOsnovnipodatciKontakttelefon.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciKontakttelefon_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciKontakttelefon.Text == "")
            {
                txtOsnovnipodatciKontakttelefon.Text = "Kontakt telefon";
                txtOsnovnipodatciKontakttelefon.ForeColor = Color.Gray;
            }
        }
        // Gestacijska dob - Tjedana
        private void txtGestacijskadobTjedana_Enter(object sender, EventArgs e)
        {
            if (txtGestacijskadobTjedana.Text == "Tjedana")
            {

                txtGestacijskadobTjedana.Text = "";
                txtGestacijskadobTjedana.ForeColor = Color.Black;
            }
        }
        private void txtGestacijskadobTjedana_Leave(object sender, EventArgs e)
        {
            if (txtGestacijskadobTjedana.Text == "")
            {
                txtGestacijskadobTjedana.Text = "Tjedana";
                txtGestacijskadobTjedana.ForeColor = Color.Gray;
            }
        }
        // Gestacijska dob - Dana
        private void txtGestacijskadobDana_Enter(object sender, EventArgs e)
        {
            if (txtGestacijskadobDana.Text == "Dana")
            {

                txtGestacijskadobDana.Text = "";
                txtGestacijskadobDana.ForeColor = Color.Black;
            }
        }
        private void txtGestacijskadobDana_Leave(object sender, EventArgs e)
        {
            if (txtGestacijskadobDana.Text == "")
            {
                txtGestacijskadobDana.Text = "Dana";
                txtGestacijskadobDana.ForeColor = Color.Gray;
            }
        }
        // Rodna masa
        private void txtNovorodenceRodnamasa_Enter(object sender, EventArgs e)
        {
            if (txtNovorodenceRodnamasa.Text == "Rodna masa (RM/g)")
            {

                txtNovorodenceRodnamasa.Text = "";
                txtNovorodenceRodnamasa.ForeColor = Color.Black;
            }
        }
        private void txtNovorodenceRodnamasa_Leave(object sender, EventArgs e)
        {
            if (txtNovorodenceRodnamasa.Text == "")
            {
                txtNovorodenceRodnamasa.Text = "Rodna masa (RM/g)";
                txtNovorodenceRodnamasa.ForeColor = Color.Gray;
            }
        }

        // Rodna duljina
        private void txtNovorodenceRodnaduljina_Enter(object sender, EventArgs e)
        {
            if (txtNovorodenceRodnaduljina.Text == "Rodna duljina (RD/cm)")
            {

                txtNovorodenceRodnaduljina.Text = "";
                txtNovorodenceRodnaduljina.ForeColor = Color.Black;
            }
        }
        private void txtNovorodenceRodnaduljina_Leave(object sender, EventArgs e)
        {
            if (txtNovorodenceRodnaduljina.Text == "")
            {

                txtNovorodenceRodnaduljina.Text = "Rodna duljina (RD/cm)";
                txtNovorodenceRodnaduljina.ForeColor = Color.Gray;
            }
        }

        // Opseg glave
        private void txtNovorodenceOpsegglave_Enter(object sender, EventArgs e)
        {
            if (txtNovorodenceOpsegglave.Text == "Opseg glave (OG/cm)")
            {
                txtNovorodenceOpsegglave.Text = "";
                txtNovorodenceOpsegglave.ForeColor = Color.Black;
            }
        }
        private void txtNovorodenceOpsegglave_Leave(object sender, EventArgs e)
        {
            if (txtNovorodenceOpsegglave.Text == "")
            {
                txtNovorodenceOpsegglave.Text = "Opseg glave (OG/cm)";
                txtNovorodenceOpsegglave.ForeColor = Color.Gray;
            }
        }

        // Apgar indeks
        private void txtNovorodenceApgarindeks_Enter(object sender, EventArgs e)
        {

            if (txtNovorodenceApgarindeks.Text == "Apgar indeks")
            {
                txtNovorodenceApgarindeks.Text = "";
                txtNovorodenceApgarindeks.ForeColor = Color.Black;
            }
        }
        private void txtNovorodenceApgarindeks_Leave(object sender, EventArgs e)
        {
            if (txtNovorodenceApgarindeks.Text == "")
            {
                txtNovorodenceApgarindeks.Text = "Apgar indeks";
                txtNovorodenceApgarindeks.ForeColor = Color.Gray;
            }
        }

        // Paritet
        private void txtTrudnocaParitet_Enter(object sender, EventArgs e)
        {
            if (txtTrudnoćaParitet.Text == "Paritet")
            {

                txtTrudnoćaParitet.Text = "";
                txtTrudnoćaParitet.ForeColor = Color.Black;
            }
        }
        private void txtTrudnocaParitet_Leave(object sender, EventArgs e)
        {
            if (txtTrudnoćaParitet.Text == "")
            {
                txtTrudnoćaParitet.Text = "Paritet";
                txtTrudnoćaParitet.ForeColor = Color.Gray;
            }
        }

        // Kortikosteroidna profilaksa
        private void txtPorodKortikosteroidnaprofilaksa_Enter(object sender, EventArgs e)
        {

            if (txtPorodKortikosteroidnaprofilaksa.Text == "Kortikosteroidna profilaksa")
            {

                txtPorodKortikosteroidnaprofilaksa.Text = "";
                txtPorodKortikosteroidnaprofilaksa.ForeColor = Color.Black;
            }
        }
        private void txtPorodKortikosteroidnaprofilaksa_Leave(object sender, EventArgs e)
        {
            if (txtPorodKortikosteroidnaprofilaksa.Text == "")
            {
                txtPorodKortikosteroidnaprofilaksa.Text = "Kortikosteroidna profilaksa";
                txtPorodKortikosteroidnaprofilaksa.ForeColor = Color.Gray;
            }
        }

        // Stav djeteta
        private void txtPorodStavdjeteta_Enter(object sender, EventArgs e)
        {
            if (txtPorodStavdjeteta.Text == "Stav djeteta")
            {

                txtPorodStavdjeteta.Text = "";
                txtPorodStavdjeteta.ForeColor = Color.Black;
            }
        }
        private void txtPorodStavdjeteta_Leave(object sender, EventArgs e)
        {
            if (txtPorodStavdjeteta.Text == "")
            {

                txtPorodStavdjeteta.Text = "Stav djeteta";
                txtPorodStavdjeteta.ForeColor = Color.Gray;
            }

        }

        // Trajanje poroda
        private void txtPorodTrajanjeporoda_Enter(object sender, EventArgs e)
        {

            if (txtPorodTrajanjeporoda.Text == "Trajanje poroda")
            {

                txtPorodTrajanjeporoda.Text = "";
                txtPorodTrajanjeporoda.ForeColor = Color.Black;
            }
        }
        private void txtPorodTrajanjeporoda_Leave(object sender, EventArgs e)
        {
            if (txtPorodTrajanjeporoda.Text == "")
            {
                txtPorodTrajanjeporoda.Text = "Trajanje poroda";
                txtPorodTrajanjeporoda.ForeColor = Color.Gray;
            }
        }




        private void txtNovorodenceRodnamasa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTrudnoćaParitet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPorodStavdjeteta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetVarijabli();
        }

        private void txtOsnovnipodatciImeoca_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnVaginalno_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

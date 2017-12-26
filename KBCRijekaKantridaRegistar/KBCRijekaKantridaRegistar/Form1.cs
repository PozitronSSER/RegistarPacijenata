using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace KBCRijekaKantridaRegistar

    /*
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

        public string[] komplikacija()
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
        /*
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
            //copy-paste iz Pacijent.cs(uz neke male promjene)

            // (1) provjeriti da li su sve varijable u redu

            int id, gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaDuljina, opsegGlave;
            string ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,
                apgarIndeks, trajanjePoroda;

            string trudnocaPlodna, trudnocaPrirodna, nacinPoroda, prom, febrilitetRodilje, reanimacija; //stavio sam string umjesto bool jer ce se kasnije nesto mijenjati

            // (2) provjeriti da li je dobro koristiti niz, ili ima bolje rješenje

            //gledamo ako je ostalo izabrano, ako je dodajemo +1 u string
            int ostaloPatologija = 0;
            int ostaloKomplikacije = 0;
            if (chkBoxNovorođenčeKomplikacijeOstalo.Checked)
                ostaloKomplikacije = 1;

            if (chkBoxPatologijaTrudnoćeOstalo.Checked)
                ostaloPatologija = 1;

            string[] patologijaTrudnoce = new string[chkListBoxPatologijaTrudnoće.SelectedItems.Count + ostaloPatologija]; //ne radi kako treba
            string[] komplikacije = new string[chkListBoxNovorodenceKomplikacije.SelectedItems.Count + ostaloKomplikacije]; //ne raid kako treba

            DateTime datumRodenja;
            //korištenje prijelaznih varijabli

            // "ubacivanje" podataka u array
            komplikacije = komplikacija();

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
            trudnocaPlodna = Convert.ToString(rbtnTrunocaJednoplodna.Checked);
            trudnocaPrirodna = Convert.ToString(rbtnTrunocaPrirodna.Checked);
            nacinPoroda = Convert.ToString(rbtnPorodCarskirez.Checked);
            prom = Convert.ToString(chkBoxPorodPROM.Checked);
            febrilitetRodilje = Convert.ToString(chkBoxPorodFebrilitetrodilje.Checked);
            reanimacija = Convert.ToString(chkBoxNovorodenceReanimacija.Checked);

            /*
             * for (int i = 0; i < komplikacije.Length; i++)
                //neznam ovaj dio
                */



            if (ostaloPatologija == 1)
            {
                patologijaTrudnoce[patologijaTrudnoce.Length - 1] = txtPatologijaTrudnoćeOstalo.Text;
            }
            if(ostaloKomplikacije == 1)
            {
                komplikacije[komplikacije.Length - 1] = txtNovorođenčeKomplikacijeOstalo.Text;
            }

            datumRodenja = Convert.ToDateTime(txtOsnovnipodatciDatumrođenja.Text);
         
          

            //pretvaranje "true" u "da" ... ipak smo hrvati

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

            Pacijent pacijent = new Pacijent(ime, prezime, imeMajke,
               imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,datumRodenja, 
               rbtnTrunocaPrirodna.Checked/*trazi bool, a ja sam koristio string pa cu zasad ovako */, trajanjePoroda);

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
                    xmlWriter.WriteElementString("Patologijatrudnoće",ConvertStringArrayToStringJoin(patologijaTrudnoce));
                    xmlWriter.WriteElementString("Gestacijskadobtjedni", Convert.ToString(gestacijskaDobTjedana));
                    xmlWriter.WriteElementString("Gestacijskadobdani", Convert.ToString(gestacijskaDobDana));
                    xmlWriter.WriteElementString("Rodnamasa", Convert.ToString(rodnaMasa));
                    xmlWriter.WriteElementString("Rodnaduljina", Convert.ToString(rodnaDuljina));
                    xmlWriter.WriteElementString("Opsegglave", Convert.ToString(opsegGlave));
                    xmlWriter.WriteElementString("Apgarindeks", apgarIndeks);
                    xmlWriter.WriteElementString("Reanimacija", reanimacija);
                    xmlWriter.WriteElementString("Komplikacije",ConvertStringArrayToStringJoin(komplikacije));

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
                    new XElement("Imeoca",imeOca),
                    new XElement("Adresa", adresa),
                    new XElement("Kontakttelefon", kontaktTelefon),
                    new XElement("Datumrođenja", Convert.ToString(datumRodenja)),
                    new XElement("Spol", spol),
                    new XElement("Paritettrudnoće", paritetTrudnoce),
                    new XElement("PlodnostTrudnoće", trudnocaPlodna), 
                    new XElement("Prirodatrudnće",trudnocaPrirodna),
                    new XElement("NačinPoroda", nacinPoroda),
                    new XElement("Trajanjeporoda", trajanjePoroda),
                    new XElement("Stavdjeteta", stavDjeteta),
                    new XElement("Profilaksa", profilaksa),
                    new XElement("PROM", prom), 
                    new XElement("Ferbrilitet", febrilitetRodilje), 
                    new XElement("Patologijatrudnoće",ConvertStringArrayToStringJoin(patologijaTrudnoce)), 
                    new XElement("Gestacijskadobtjedni",gestacijskaDobTjedana), 
                    new XElement("Gestacijskadobdani", gestacijskaDobDana), 
                    new XElement("Rodnamasa", rodnaMasa), 
                    new XElement("Rodnaduljina", rodnaDuljina), 
                    new XElement("Opsegglave", opsegGlave),
                    new XElement("Apgarindeks", apgarIndeks),            
                    new XElement("Reanimacija",reanimacija), 
                    new XElement("Komplikacije",ConvertStringArrayToStringJoin(komplikacije)))); 

                xDocument.Save("Registar.xml");
            }


            /* ovo je stari kod koji ste napravili prije
             
            doc.LoadXml("<Registar></Registar>");

            XmlElement newElem = doc.CreateElement(txtOsnovnipodatciIme.Text);
            newElem.InnerText = Convert.ToString(Pacijent.Id);
            doc.DocumentElement.AppendChild(newElem);

            doc.PreserveWhitespace = true;
            doc.Save(txtOsnovnipodatciIme.Text+".xml");

            */


            //čistimo podatke nakon unosa

            txtGestacijskadobDana.Clear();
            txtGestacijskadobTjedana.Clear();
            txtNovorodenceApgarindeks.Text = "00 / 00 / 00";
            txtNovorodenceOpsegglave.Clear();
            txtNovorodenceRodnaduljina.Clear();
            txtNovorodenceRodnamasa.Clear();
            txtNovorođenčeKomplikacijeOstalo.Clear();
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
            txtTestIspis.Clear();
            txtTrudnoćaParitet.ResetText();
            rbtnPorodCarskirez.Checked = false;
            rbtnTrunocaJednoplodna.Checked = false;
            rbtnTrunocaPotpomognuta.Checked = false;
            rbtnTrunocaPrirodna.Checked = false;
            rbtnTrunocaViseplodna.Checked = false;
            rbtnVaginalno.Checked = false;
            chkBoxNovorodenceReanimacija.Checked = false;
            chkBoxNovorođenčeKomplikacijeOstalo.Checked = false;
            chkBoxPatologijaTrudnoćeOstalo.Checked = false;
            chkBoxPorodFebrilitetrodilje.Checked = false;
            chkBoxPorodPROM.Checked = false;
             //nikako nemogu ocistit listboxove

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
            if (chkBoxNovorođenčeKomplikacijeOstalo.Checked)
            {
                txtNovorođenčeKomplikacijeOstalo.Enabled = true;
            }
            else
            {
                txtNovorođenčeKomplikacijeOstalo.Enabled = false;
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
    }
}

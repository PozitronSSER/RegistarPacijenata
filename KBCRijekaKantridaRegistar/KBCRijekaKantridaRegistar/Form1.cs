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

        // upis podataka nakon odabira opcije "Upiši"

        private void button1_Click(object sender, EventArgs e)
        {
            //pretvaranje "true" u "da" ... ipak smo hrvati
            string jednoplodna, carskirez, prirodna, ferbrilitet, PROM, Reanimacija;
            if (rbtnTrunocaJednoplodna.Checked == true)
                jednoplodna = "Da";
            else
                jednoplodna = "Ne";

            if (rbtnTrunocaPrirodna.Checked == true)
                prirodna = "Da";
            else
                prirodna = "Ne";

            if (rbtnPorodCarskirez.Checked == true)
                carskirez = "Da";
            else
                carskirez = "Ne";

            if (chkBoxNovorodenceReanimacija.Checked == true)
                Reanimacija = "Da";
            else
                Reanimacija = "Ne";

            if (chkBoxPorodFebrilitetrodilje.Checked == true)
                ferbrilitet = "Da";
            else
                ferbrilitet = "Ne";

            if (chkBoxPorodPROM.Checked == true)
                PROM = "Da";
            else
                PROM = "Ne";
            // kreiranje objekta pacijent

            // (1) napraviti objekt pomoću ispravnog konstruktora

            Pacijent pacijent = new Pacijent(txtOsnovnipodatciIme.Text, txtOsnovnipodatciPrezime.Text, txtOsnovnipodatciImemajke.Text,
                txtOsnovnipodatciImeoca.Text, txtOsnovnipodatciAdresa.Text, txtOsnovnipodatciKontakttelefon.Text,
                txtOsnovnipodatciSpol.Text, txtTrudnoćaParitet.Text, txtPorodStavdjeteta.Text, txtPorodKortikosteroidnaprofilaksa.Text,
                Convert.ToDateTime(txtOsnovnipodatciDatumrođenja.Text), rbtnTrunocaPrirodna.Checked, txtPorodTrajanjeporoda.Text);

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

                    xmlWriter.WriteElementString("Ime", pacijent.ImePacijenta);
                    xmlWriter.WriteElementString("Prezime", pacijent.PrezimePacijenta);
                    xmlWriter.WriteElementString("Imemajke", pacijent.ImeMajke);
                    xmlWriter.WriteElementString("Imeoca", pacijent.ImeOca);
                    xmlWriter.WriteElementString("Adresa", pacijent.Adresa);
                    xmlWriter.WriteElementString("Kontakttelefon", pacijent.KontaktTelefon);
                    xmlWriter.WriteElementString("Datumrođenja", pacijent.DatumRodenja.ToShortDateString());
                    xmlWriter.WriteElementString("Spol", pacijent.Spol);
                    xmlWriter.WriteElementString("Paritettrudnoće", pacijent.ParitetTrudnoce);
                    xmlWriter.WriteElementString("Jednoplodnatrudnoća", jednoplodna); //zasad
                    xmlWriter.WriteElementString("Prirodnatrudnoca", prirodna); //zasad
                    xmlWriter.WriteElementString("Carskirez", carskirez); //zasad
                    xmlWriter.WriteElementString("Trajanjeporoda", pacijent.TrajanjePoroda);
                    xmlWriter.WriteElementString("Stavdjeteta", pacijent.StavDjeteta);
                    xmlWriter.WriteElementString("Profilaksa", pacijent.Profilaksa);
                    xmlWriter.WriteElementString("PROM", PROM); //zasad
                    xmlWriter.WriteElementString("Ferbrilitet", ferbrilitet);//zasad
                    xmlWriter.WriteElementString("Patologijatrudnoće", chkListBoxPatologijaTrudnoće.Text + txtPatologijaTrudnoćeOstalo.Text);//zasad
                    xmlWriter.WriteElementString("Gestacijskadobtjedni", txtGestacijskadobTjedana.Text);//zasad
                    xmlWriter.WriteElementString("Gestacijskadobdani", txtGestacijskadobDana.Text);//zasad
                    xmlWriter.WriteElementString("Rodnamasa", txtNovorodenceRodnamasa.Text);//zasad
                    xmlWriter.WriteElementString("Rodnaduljina", txtNovorodenceRodnaduljina.Text);//zasad
                    xmlWriter.WriteElementString("Opsegglave", txtNovorodenceOpsegglave.Text);//zasad
                    xmlWriter.WriteElementString("Agarindeks", txtNovorodenceApgarindeks.Text);//zasad
                    xmlWriter.WriteElementString("Reanimacija", Reanimacija);//zasad
                    xmlWriter.WriteElementString("Komplikacije", chkListBoxNovorodenceKomplikacije.Text + txtNovorođenčeKomplikacijeOstalo.Text);//zasad

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
                    new XElement("Ime", pacijent.ImePacijenta),
                    new XElement("Prezime", pacijent.PrezimePacijenta),
                    new XElement("Imemajke", pacijent.ImeMajke),
                    new XElement("Imeoca", pacijent.ImeOca),
                    new XElement("Adresa", pacijent.Adresa),
                    new XElement("Kontakttelefon", pacijent.KontaktTelefon),
                    new XElement("Datumrođenja", pacijent.DatumRodenja.ToShortDateString()),
                    new XElement("Spol", pacijent.Spol),
                    new XElement("Paritettrudnoće", pacijent.ParitetTrudnoce),
                    new XElement("Jednoplodnatrudnoća", jednoplodna), //zasad
                    new XElement("Prirodnatrudnoca", pacijent.TrudnocaPrirodna.ToString()),
                    new XElement("Carskirez", carskirez), //zasad 
                    new XElement("Trajanjeporoda", pacijent.TrajanjePoroda),
                    new XElement("Stavdjeteta", pacijent.StavDjeteta),
                    new XElement("Profilaksa", pacijent.Profilaksa),
                    new XElement("PROM", PROM), //zasad 
                    new XElement("Ferbrilitet", ferbrilitet), //zasad 
                    new XElement("Patologijatrudnoće", chkListBoxPatologijaTrudnoće.Text + txtPatologijaTrudnoćeOstalo.Text), //zasad 
                    new XElement("Gestacijskadobtjedni", txtGestacijskadobTjedana.Text), //zasad 
                    new XElement("Gestacijskadobdani", txtGestacijskadobDana.Text), //zasad 
                    new XElement("Rodnamasa", txtNovorodenceRodnamasa.Text), //zasad 
                    new XElement("Rodnaduljina", txtNovorodenceRodnaduljina.Text), //zasad  
                    new XElement("Opsegglave", txtNovorodenceOpsegglave.Text), //zasad 
                    new XElement("Agarindeks", txtNovorodenceApgarindeks.Text), //zasad  
                    new XElement("Reanimacija", Reanimacija), //zasad 
                    new XElement("Komplikacije", chkListBoxNovorodenceKomplikacije.Text + txtNovorođenčeKomplikacijeOstalo.Text))); //zasad 

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

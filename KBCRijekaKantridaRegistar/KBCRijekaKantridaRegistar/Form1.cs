using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace KBCRijekaKantridaRegistar
{
    public partial class Form1 : Form
    {
        int brojac = 0;

        public bool trudnocaPrirodnaSwitch;


        public Form1()
        {
            InitializeComponent();
        }

        // upis podataka nakon odabira opcije "Upiši"

        private void button1_Click(object sender, EventArgs e)
        {
            // kreiranje objekta pacijent

            Pacijent pacijent = new Pacijent(txtOsnovnipodatciIme.Text, txtOsnovnipodatciPrezime.Text);

            /* kontrola ispisa u testni txtBox
            txtTestIspis.Text = pacijent.ToString();
            */

            //prebacivanje podataka u xml


            /*
             * mislim da bi trebali napraviti provjeru da li postoji "naš" XML dokument
             *  if (!exists)
             *      napravi dokument "Registar.xml"
             *  else
             *      ne diraj ništa i nahrani kerove
             */

            ///////////////////////////////////////////////////////////
            
            /* ovo je neki primjer sa StackOverFlow-a */

            // izmjenio podatke (naziv xml dokumenta, root element i ostale elemente
            
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
                        xmlWriter.WriteElementString("Ime", pacijent.imePacijenta);
                        xmlWriter.WriteElementString("Prezime", pacijent.prezimePacijenta);
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
                XElement root= xDocument.Element("Registar");
                IEnumerable <XElement> rows = root.Descendants("Pacijent");
                XElement firstRow= rows.First();
                firstRow.AddBeforeSelf(
                    new XElement("Pacijent",
                    new XElement("Ime", pacijent.imePacijenta),
                    new XElement("Prezime", pacijent.prezimePacijenta)));
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

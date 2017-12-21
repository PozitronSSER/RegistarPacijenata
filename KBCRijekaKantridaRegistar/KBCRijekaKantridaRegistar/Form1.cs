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

            // (1) napraviti objekt pomoću ispravnog konstruktora

            Pacijent pacijent = new Pacijent(txtOsnovnipodatciIme.Text, txtOsnovnipodatciPrezime.Text);

            
            //prebacivanje podataka u xml
            
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
                    new XElement("Ime", pacijent.ImePacijenta),
                    new XElement("Prezime", pacijent.PrezimePacijenta)));
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

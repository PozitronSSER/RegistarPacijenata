using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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


            XmlDocument doc = new XmlDocument(); 

            /*
             * mislim da bi trebali napraviti provjeru da li postoji "naš" XML dokument
             *  if (!exists)
             *      napravi dokument "Registar.xml"
             *  else
             *      ne diraj ništa i nahrani kerove
             */

            ///////////////////////////////////////////////////////////
            
            /* ovo je neki primjer sa StackOverFlow-a
            
            if (!File.Exists("Test.xml"))
               {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;
                    xmlWriterSettings.NewLineOnAttributes = true;
                    using (XmlWriter xmlWriter = XmlWriter.Create("Test.xml", xmlWriterSettings))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("School");

                        xmlWriter.WriteStartElement("Student");
                        xmlWriter.WriteElementString("FirstName", firstName);
                        xmlWriter.WriteElementString("LastName", lastName);
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
            }
            else
            {
                XDocument xDocument = XDocument.Load("Test.xml");
                XElement root= xDocument.Element("School");
                IEnumerable<XElement> rows = root.Descendants("Student");
                XElement firstRow= rows.First();
                firstRow.AddBeforeSelf(
                    new XElement("Student",
                    new XElement("FirstName", firstName),
                    new XElement("LastName", lastName)));
                xDocument.Save("Test.xml");
            }
            */
            ////////////////////////////////////////////////////////////////////

            doc.LoadXml("<Registar></Registar>");

            XmlElement newElem = doc.CreateElement(txtOsnovnipodatciIme.Text);
            newElem.InnerText = Convert.ToString(Pacijent.Id);
            doc.DocumentElement.AppendChild(newElem);

            doc.PreserveWhitespace = true;
            doc.Save(txtOsnovnipodatciIme.Text+".xml");

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

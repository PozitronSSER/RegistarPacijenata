using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Pacijent pacijent = new Pacijent(txtOsnovnipodatciIme.Text, txtOsnovnipodatciPrezime.Text);

            //txtTestIspis.Text = pacijent.ToString();

            //prebacivanje podataka u xml

            XmlDocument doc = new XmlDocument();

            doc.LoadXml("<Registar></Registar>");


            XmlElement newElem = doc.CreateElement(txtOsnovnipodatciIme.Text);
            newElem.InnerText = Convert.ToString(Pacijent.Id);
            doc.DocumentElement.AppendChild(newElem);

            doc.PreserveWhitespace = true;
            doc.Save(txtOsnovnipodatciIme.Text+".xml");

        }


        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

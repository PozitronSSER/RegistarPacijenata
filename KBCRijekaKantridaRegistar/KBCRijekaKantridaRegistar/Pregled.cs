﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KBCRijekaKantridaRegistar
{
    public partial class Pregled : Form
    {
        public Pregled()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string da = "";
            XDocument doc = XDocument.Load("Registar.xml");
            var pacijenti = from pacijent in doc.Root.Elements("Pacijent")
                            where pacijent.Element("Prezime").Value.Equals(textBox1.Text)
                            select pacijent;
            foreach(object a in pacijenti)
            {
                string test = Convert.ToString(a);
                string output = Regex.Replace(test, "</.*?>", string.Empty);
                output = output.Replace('<',' ');
                output = output.Replace(">",": ");
                output = output.Replace("Pacijent:", "");
                MessageBox.Show(output);

            }
           
            
        }
    }
}

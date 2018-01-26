using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            XDocument doc = XDocument.Load("Registar.xml");
            var pacijenti = from pacijent in doc.Root.Elements("Pacijent")
                            where pacijent.Element("Prezime").Value.Contains(textBox1.Text)
                            select pacijent;

            foreach (object o in pacijenti)
            {
                MessageBox.Show(Convert.ToString(o));
            }
            string pacent = String.Join(",", pacijenti);
            MessageBox.Show(pacent);

        }
    }
}

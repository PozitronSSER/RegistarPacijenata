using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBCRijekaKantridaRegistar
{
    public partial class PregledPodataka : Form
    {
        public PregledPodataka()
        {
            InitializeComponent();
        }

        private void PregledPodataka_Load(object sender, EventArgs e)
        {
            string filePath = Application.StartupPath + "/Registar.xml";

            PacijentData.ReadXml(filePath);

            dataGridView1.DataSource = PacijentData;
            dataGridView1.DataMember = "Pacijent";
        }
    }
}

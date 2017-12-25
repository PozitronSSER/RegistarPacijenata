using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBCRijekaKantridaRegistar.GUI
{
    public partial class Pocetna : Form
    {
        

        public Pocetna()
        {
            InitializeComponent();
            
        }

        public void btnUnosPacijenta_Click(object sender, EventArgs e)
        {
            OsnovniPodaci unosPodataka = new OsnovniPodaci();
            unosPodataka.Show();
            
        }
    }
}

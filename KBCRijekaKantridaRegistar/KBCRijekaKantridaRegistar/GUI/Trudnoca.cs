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
    public partial class Trudnoca : Form
    {
        public Trudnoca()
        {
            InitializeComponent();
        }

        public string[] odabirPatologije()
        {
            string[] patologija = new string[chkListBoxPatologijaTrudnoće.Items.Count];
            List<string> patItems = new List<string>();

            foreach (string item in chkListBoxPatologijaTrudnoće.CheckedItems)
            {

                patItems.Add(item);
                
            }
            if (chkBoxPatologijaTrudnoćeOstalo.Checked)
            {
                string patologijaOstalo = txtPatologijaTrudnoćeOstalo.Text;
                patItems.Add(patologijaOstalo);
            }
            
            patologija = patItems.ToArray();
            return patologija;

        }

        private void btnDaljeTrudnoca_Click(object sender, EventArgs e)
        {
            
            Buffer unos = new Buffer();
            unos.ParitetTrudnoce = txtTrudnoćaParitet.Text;
            if (rbtnTrunocaJednoplodna.Checked)
            {
                unos.PlodnostTrudnoce = "Jednoplodna";
            }
            if (rbtnTrunocaViseplodna.Checked)
            {
                unos.PlodnostTrudnoce = "Višeplodna";
            }
            if (rbtnTrunocaPrirodna.Checked)
            {
                unos.NacinTrudnoce = "Prirodna";
            }
            if (rbtnTrunocaPotpomognuta.Checked)
            {
                unos.NacinTrudnoce = "Potpomognuta";
            }
            unos.GestacijskaDobDana = Convert.ToInt32(txtGestacijskadobDana.Text);
            unos.GestacijskaDobTjedana = Convert.ToInt32(txtGestacijskadobTjedana.Text);

            unos.PatologijaTrudnoce = odabirPatologije();

            this.Hide();
            Porod porod = new Porod();
            porod.Show();
            
        }

        private void chkBoxPatologijaTrudnoćeOstalo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxPatologijaTrudnoćeOstalo.Checked)
            { txtPatologijaTrudnoćeOstalo.Enabled = true; }
            else { txtPatologijaTrudnoćeOstalo.Enabled = false; }
        }
    }
}

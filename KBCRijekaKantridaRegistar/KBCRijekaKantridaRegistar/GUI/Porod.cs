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
    public partial class Porod : Form
    {
        public Porod()
        {
            InitializeComponent();
        }

        public string[] komplikacije()
        {
            string[] komplikacije = new string[chkListBoxNovorodenceKomplikacije.Items.Count];
            List<string> komItems = new List<string>();

            foreach (string item in chkListBoxNovorodenceKomplikacije.CheckedItems)
            {

                komItems.Add(item);

            }
            if (chkBoxNovorođenčeKomplikacijeOstalo.Checked)
            {
                string komplikacijaOstalo = txtNovorođenčeKomplikacijeOstalo.Text;
                komItems.Add(komplikacijaOstalo);
            }

            komplikacije = komItems.ToArray();
            return komplikacije;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Buffer unos = new Buffer();

            unos.Id = Buffer.sifraPacijenta;
            Buffer.sifraPacijenta++;
            if (rbtnVaginalno.Checked)
            {
                unos.NaciPoroda2 = "Vaginalno";
            }
            if (rbtnPorodCarskirez.Checked)
            {
                unos.NaciPoroda2 = "Carski rez";
            }
            unos.TrajanjePoroda = txtPorodTrajanjeporoda.Text;
            unos.StavDjeteta = txtPorodStavdjeteta.Text;
            unos.Profilaksa = txtPorodKortikosteroidnaprofilaksa.Text;
            if (chkBoxPorodPROM.Checked)
            {
                unos.PromTekst = "DA";
            }
            else { unos.PromTekst = "NE"; }
            if (chkBoxPorodFebrilitetrodilje.Checked)
            {
                unos.Febrilitet = "Febrilitet";
            }
            else { unos.Febrilitet = "Bez febriliteta"; }
            unos.RodnaMasa = Convert.ToInt16(txtNovorodenceRodnamasa.Text);
            unos.RodnaDuljina = Convert.ToInt16(txtNovorodenceRodnaduljina.Text);
            unos.OpsegGlave = Convert.ToInt16(txtNovorodenceOpsegglave.Text);
            unos.ApgarIndeks = txtNovorodenceApgarindeks.Text;
            if (chkBoxNovorodenceReanimacija.Checked)
            {
                unos.ReanimacijaTekst = "DA";
            } else
            {
                unos.ReanimacijaTekst = "NE";
            }
            unos.Komplikacije = komplikacije();

            // izvoz u XML


            // zatvaranje prozora i povratak na početni ekran
            this.Hide();
            
            

        }

        private void chkBoxNovorođenčeKomplikacijeOstalo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxNovorođenčeKomplikacijeOstalo.Checked)
            { txtNovorođenčeKomplikacijeOstalo.Enabled = true; }
            else { txtNovorođenčeKomplikacijeOstalo.Enabled = false; }
        }
    }
}

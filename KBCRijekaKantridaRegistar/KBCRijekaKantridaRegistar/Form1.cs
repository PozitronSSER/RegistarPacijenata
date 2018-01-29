using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace KBCRijekaKantridaRegistar

{
    public partial class Form1 : Form
    {


    
        public bool trudnocaPrirodnaSwitch;


        public Form1()
        {
            InitializeComponent();
        }



        // upis podataka nakon odabira opcije "Upiši"

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //deklaracija prijelaznih varijabli
                int id, gestacijskaDobTjedana, gestacijskaDobDana, rodnaMasa, rodnaDuljina, opsegGlave;
                string ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa,
                    apgarIndeks, trajanjePoroda;
                string krvarenje, dijabetes, ppi, infekcije, hipertenzija, eph, ostaloPatologija, ostaloTextPatologija, trudnocaPlodna, trudnocaPrirodna,
                    nacinPoroda, prom, febrilitetRodilje, reanimacija; 
                string hipoglikemija, rds, mehaničkaventilacija, sepsa, hiperbilirubinemija, konvulzije, pvl, pv_ivh, nec, rop, ostaloKomplikacije, ostaloTextKomplikacije;
                DateTime datumRodenja;



                //Provjera podataka početak

                if(txtOsnovnipodatciIme.Text == "Ime")
                {
                    MessageBox.Show("Ime mora biti uneseno");
                    goto Kraj;
                }
                if (txtOsnovnipodatciPrezime.Text == "Prezime")
                {
                    MessageBox.Show("Prezime mora biti uneseno");
                    goto Kraj;
                }
                if (txtOsnovnipodatciSpol.Text == "Spol")
                {
                    MessageBox.Show("Spol mora biti odabran");
                    goto Kraj;
                }
                if (txtOsnovnipodatciAdresa.Text == "Adresa")
                {
                    MessageBox.Show("Adresa mora biti unesena");
                    goto Kraj;
                }
                if (txtOsnovnipodatciImemajke.Text == "Ime majke")
                {
                    MessageBox.Show("Ime majke mora biti uneseno");
                    goto Kraj;
                }
                if (txtOsnovnipodatciImeoca.Text == "Ime oca")
                {
                    MessageBox.Show("Ime oca mora biti uneseno");
                    goto Kraj;
                }
                if (txtOsnovnipodatciKontakttelefon.Text == "Kontakt telefon")
                {
                    MessageBox.Show("Telefon mora biti unesen");
                    goto Kraj;
                }
                if (txtTrudnoćaParitet.Text == "Paritet")
                {
                    MessageBox.Show("Paritet mora biti unesen");
                    goto Kraj;
                }
                if (txtPorodTrajanjeporoda.Text == "Trajanje poroda")
                {
                    MessageBox.Show("Trajanje poroda mora biti uneseno");
                    goto Kraj;
                }
                if (txtPorodKortikosteroidnaprofilaksa.Text == "Kortikosteroidna profilaksa")
                {
                    MessageBox.Show("Kortikosteroidna profilaksa mora biti unesena");
                    goto Kraj;
                }
                if (txtGestacijskadobTjedana.Text == "Tjedana")
                {
                    MessageBox.Show("Gestacijska dob tjedni mora biti unesena");
                    goto Kraj;
                }
                if (txtGestacijskadobDana.Text == "Dana")
                {
                    MessageBox.Show("Gestacijska dob dani mora biti unesena");
                    goto Kraj;
                }
                if (txtNovorodenceRodnamasa.Text == "Rodna masa (RM/g)")
                {
                    MessageBox.Show("Rodna masa mora biti unesena");
                    goto Kraj;
                }
                if (txtNovorodenceRodnaduljina.Text == "Rodna duljina (RD/cm)")
                {
                    MessageBox.Show("Rodna duljina mora biti unesena");
                    goto Kraj;
                }
                if (txtNovorodenceOpsegglave.Text == "Opseg glave (OG/cm)")
                {
                    MessageBox.Show("Opseg glave mora biti unesen");
                    goto Kraj;
                }
                if (txtNovorodenceApgarindeks.Text == "Apgar indeks")
                {
                    MessageBox.Show("Apgar indeks mora biti unesen");
                    goto Kraj;
                }
                if (txtPorodStavdjeteta.Text == "Stav djeteta")
                {
                    MessageBox.Show("Stav djeteta mora biti unesen");
                    goto Kraj;
                }
                if (!rbtnTrunocaJednoplodna.Checked && !rbtnTrunocaViseplodna.Checked)
                {
                    MessageBox.Show("Plodnost trudnoće mora biti odabrana");
                    goto Kraj;
                }
                if (!rbtnVaginalno.Checked && !rbtnPorodCarskirez.Checked)
                {
                    MessageBox.Show("Način poroda mora biti odabran");
                    goto Kraj;
                }
                if (!rbtnTrunocaPotpomognuta.Checked && !rbtnTrunocaPrirodna.Checked)
                {
                    MessageBox.Show("Priroda trudnoće mora biti odabrana");
                    goto Kraj;
                }



                //PROVJERA CONVERTOVA
                try
                {
                    gestacijskaDobTjedana = Convert.ToInt32(txtGestacijskadobTjedana.Text);
                }
                catch (Exception s)
                {
                    MessageBox.Show("Gestacijska dob tjedni ne može sadržavati slova.");
                    goto Kraj;
                }
                try
                {
                    gestacijskaDobDana = Convert.ToInt32(txtGestacijskadobDana.Text);
                }
                catch (Exception s)
                {
                    MessageBox.Show("Gestacijska dob dani ne može sadržavati slova.");
                    goto Kraj;
                }
                try
                {
                    rodnaMasa = Convert.ToInt32(txtNovorodenceRodnamasa.Text);
                }
                catch (Exception s)
                {
                    MessageBox.Show("Rodna masa ne može sadržavati slova.");
                    goto Kraj;
                }
                try
                {
                    rodnaDuljina = Convert.ToInt32(txtNovorodenceRodnaduljina.Text);
                }
                catch (Exception s)
                {
                    MessageBox.Show("Rodna duljina ne može sadržavati slova.");
                    goto Kraj;
                }
                try
                {
                    opsegGlave = Convert.ToInt32(txtNovorodenceOpsegglave.Text);
                }
                catch (Exception s)
                {
                    MessageBox.Show("Opseg glave ne može sadržavati slova.");
                    goto Kraj;
                }



                //Dodjela vrijednosti prijelaznim varijablama
                gestacijskaDobTjedana = Convert.ToInt32(txtGestacijskadobTjedana.Text);
                gestacijskaDobDana = Convert.ToInt32(txtGestacijskadobDana.Text);
                rodnaMasa = Convert.ToInt32(txtNovorodenceRodnamasa.Text);
                rodnaDuljina = Convert.ToInt32(txtNovorodenceRodnaduljina.Text);
                opsegGlave = Convert.ToInt32(txtNovorodenceOpsegglave.Text);

                ime = txtOsnovnipodatciIme.Text;
                prezime = txtOsnovnipodatciPrezime.Text;
                imeMajke = txtOsnovnipodatciImemajke.Text;
                imeOca = txtOsnovnipodatciImeoca.Text;
                adresa = txtOsnovnipodatciAdresa.Text;
                kontaktTelefon = txtOsnovnipodatciKontakttelefon.Text;
                spol = txtOsnovnipodatciSpol.Text;
                paritetTrudnoce = txtTrudnoćaParitet.Text;
                stavDjeteta = txtPorodStavdjeteta.Text;
                profilaksa = txtPorodKortikosteroidnaprofilaksa.Text;
                apgarIndeks = txtNovorodenceApgarindeks.Text;
                trajanjePoroda = txtPorodTrajanjeporoda.Text;
                krvarenje = chkBoxPatologijatrudnoceKrvarenje.Text;
                dijabetes = chkBoxPatologijatrudnoceDijabetes.Text;
                ppi = chkBoxPatologijatrudnocePPI.Text;
                infekcije = chkBoxPatologijatrudnoceInfekcije.Text;
                hipertenzija = chkBoxPatologijatrudnoceHipertenzija.Text;
                eph = chkBoxPatologijatrudnoceEPH.Text;
                ostaloPatologija = chkBoxPatologijaTrudnoćeOstalo.Text;
                hipoglikemija = chkBoxNovorođenčeHipoglikemija.Text;
                rds = chkBoxNovorođenčeRDS.Text;
                mehaničkaventilacija = chkBoxNovorođenčeMehVentilacija.Text;
                sepsa = chkBoxNovorođenčeSepsa.Text;
                hiperbilirubinemija = chkBoxNovorođenčeHiperbilirubinemija.Text;
                konvulzije = chkBoxNovorođenčeKonvulzije.Text;
                pvl = chkBoxNovorođenčePVL.Text;
                pv_ivh = chkBoxNovorođenčePVIVH.Text;
                nec = chkBoxNovorođenčeNEC.Text;
                rop = chkBoxNovorođenčeROP.Text;
                ostaloKomplikacije = chkBoxNovorođenčeOstalo.Text;

                trudnocaPlodna = Convert.ToString(rbtnTrunocaJednoplodna.Checked);
                trudnocaPrirodna = Convert.ToString(rbtnTrunocaPrirodna.Checked);
                nacinPoroda = Convert.ToString(rbtnPorodCarskirez.Checked);
                prom = Convert.ToString(chkBoxPorodPROM.Checked);
                febrilitetRodilje = Convert.ToString(chkBoxPorodFebrilitetrodilje.Checked);
                reanimacija = Convert.ToString(chkBoxNovorodenceReanimacija.Checked);

                datumRodenja = Convert.ToDateTime(txtOsnovnipodatciDatumrođenja.Text);
                



                // -----------------------------------PRETVARANJE BOOLOVA POČETAK------------------------------------------------------//
                //True == 1   False == 2 jer je tako zatražio klijent(DA = 1 , NE = 2)
                if (hipoglikemija == "True")
                    hipoglikemija = "1";
                else
                    hipoglikemija = "2";

                if (rds == "True")
                    rds = "1";
                else
                    rds = "2";

                if (mehaničkaventilacija == "True")
                    mehaničkaventilacija = "1";
                else
                    mehaničkaventilacija = "2";

                if (sepsa == "True")
                    sepsa = "1";
                else
                    sepsa = "2";

                if (hiperbilirubinemija == "True")
                    hiperbilirubinemija = "1";
                else
                    hiperbilirubinemija = "2";

                if (konvulzije == "True")
                    konvulzije = "1";
                else
                    konvulzije = "2";

                if (pvl == "True")
                    pvl = "1";
                else
                    pvl = "2";

                if (pv_ivh == "True")
                    pv_ivh = "1";
                else
                    pv_ivh = "2";

                if (nec == "True")
                    nec = "1";
                else
                    nec = "2";

                if (rop == "True")
                    rop = "1";
                else
                    rop = "2";

                if (ostaloKomplikacije == "True")
                    ostaloTextKomplikacije = txtNovorođenčeOstalo.Text;
                else
                    ostaloTextKomplikacije = " ";


                if (ostaloPatologija == "True")
                    ostaloTextPatologija = txtPatologijaTrudnoćeOstalo.Text;
                else
                    ostaloTextPatologija = "";

                if (krvarenje == "True")
                    krvarenje = "1";
                else
                    krvarenje = "2";

                if (dijabetes == "True")
                    dijabetes = "1";
                else
                    dijabetes = "2";

                if (ppi == "True")
                    ppi = "1";
                else
                    ppi = "2";

                if (infekcije == "True")
                    infekcije = "1";
                else
                    infekcije = "2";

                if (hipertenzija == "True")
                    hipertenzija = "1";
                else
                    hipertenzija = "2";

                if (eph == "True")
                    eph = "1";
                else
                    eph = "2";

                if (trudnocaPlodna == "True")
                    trudnocaPlodna = "Jednoplodna";
                else
                    trudnocaPlodna = "Višeplodna";

                if (trudnocaPrirodna == "True")
                    trudnocaPrirodna = "Prirodna";
                else
                    trudnocaPrirodna = "Potpomognuta";

                if (nacinPoroda == "True")
                    nacinPoroda = "Carski rez";
                else
                    nacinPoroda = "Vaginalno";

                if (reanimacija == "True")
                    reanimacija = "1";
                else
                    reanimacija = "2";


                if (febrilitetRodilje == "True")
                    febrilitetRodilje = "1";
                else
                    febrilitetRodilje = "2";

                if (prom == "True")
                    prom = "1";
                else
                    prom = "2";
                // -----------------------------------PRETVARANJE BOOLOVA KRAJ------------------------------------------------------//


                // kreiranje objekta pacijent(koji za sad ne koristimo)
                Pacijent pacijent = new Pacijent(ime, prezime, imeMajke, imeOca, adresa, kontaktTelefon, spol, paritetTrudnoce, stavDjeteta, profilaksa, datumRodenja, 
                    trajanjePoroda, trudnocaPlodna, trudnocaPlodna, chkBoxPorodPROM.Checked, nacinPoroda, chkBoxPorodFebrilitetrodilje.Checked, 
                    chkBoxNovorodenceReanimacija.Checked, chkBoxPatologijatrudnoceKrvarenje.Checked, chkBoxPatologijatrudnoceDijabetes.Checked, 
                    chkBoxPatologijatrudnocePPI.Checked, chkBoxPatologijatrudnoceInfekcije.Checked, chkBoxPatologijatrudnoceHipertenzija.Checked, 
                    chkBoxPatologijatrudnoceEPH.Checked, chkBoxPatologijaTrudnoćeOstalo.Checked, chkBoxNovorođenčeHipoglikemija.Checked, chkBoxNovorođenčeRDS.Checked, 
                    chkBoxNovorođenčeMehVentilacija.Checked, chkBoxNovorođenčeSepsa.Checked, chkBoxNovorođenčeHiperbilirubinemija.Checked, chkBoxNovorođenčeKonvulzije.Checked, 
                    chkBoxNovorođenčePVL.Checked, chkBoxNovorođenčePVIVH.Checked, chkBoxNovorođenčeNEC.Checked, chkBoxNovorođenčeROP.Checked, chkBoxNovorođenčeOstalo.Checked, 
                    txtNovorođenčeOstalo.Text);



                //prebacivanje podataka u xml
                //provjera ako XML vec postoji, ako ne radi se XML datoteka
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

                        xmlWriter.WriteElementString("Ime", ime);
                        xmlWriter.WriteElementString("Prezime", prezime);
                        xmlWriter.WriteElementString("Imemajke", imeMajke);
                        xmlWriter.WriteElementString("Imeoca", imeOca);
                        xmlWriter.WriteElementString("Adresa", adresa);
                        xmlWriter.WriteElementString("Kontakt_telefon", kontaktTelefon);
                        xmlWriter.WriteElementString("Datum_rođenja", Convert.ToString(datumRodenja));
                        xmlWriter.WriteElementString("Spol", spol);
                        xmlWriter.WriteElementString("Paritet_trudnoće", paritetTrudnoce);
                        xmlWriter.WriteElementString("Plodnost_trudnoće", trudnocaPlodna);
                        xmlWriter.WriteElementString("Priroda_trudnoće", trudnocaPrirodna);
                        xmlWriter.WriteElementString("Način_poroda", nacinPoroda);
                        xmlWriter.WriteElementString("Trajanje_poroda", trajanjePoroda);
                        xmlWriter.WriteElementString("Stav_djeteta", stavDjeteta);
                        xmlWriter.WriteElementString("Profilaksa", profilaksa);
                        xmlWriter.WriteElementString("PROM", prom);
                        xmlWriter.WriteElementString("Ferbrilitet", febrilitetRodilje);
                        xmlWriter.WriteElementString("Krvarenje", krvarenje);
                        xmlWriter.WriteElementString("Dijabetes", dijabetes);
                        xmlWriter.WriteElementString("PPI", ppi);
                        xmlWriter.WriteElementString("Infekcije", hipertenzija);
                        xmlWriter.WriteElementString("Hipertenzija", hipertenzija);
                        xmlWriter.WriteElementString("EPH", eph);
                        xmlWriter.WriteElementString("Ostalo", ostaloTextPatologija);
                        xmlWriter.WriteElementString("Gestacijska_dob_tjedni", Convert.ToString(gestacijskaDobTjedana));
                        xmlWriter.WriteElementString("Gestacijska_dob_dani", Convert.ToString(gestacijskaDobDana));
                        xmlWriter.WriteElementString("Rodna_masa", Convert.ToString(rodnaMasa));
                        xmlWriter.WriteElementString("Rodna_duljina", Convert.ToString(rodnaDuljina));
                        xmlWriter.WriteElementString("Opseg_glave", Convert.ToString(opsegGlave));
                        xmlWriter.WriteElementString("Apgar_indeks", apgarIndeks);
                        xmlWriter.WriteElementString("Reanimacija", reanimacija);
                        xmlWriter.WriteElementString("Hipoglikemija", hipoglikemija);
                        xmlWriter.WriteElementString("RDS", rds);
                        xmlWriter.WriteElementString("Mehanička_ventilacija", mehaničkaventilacija);
                        xmlWriter.WriteElementString("Sepsa", sepsa);
                        xmlWriter.WriteElementString("Hiperbilirubinemija", hiperbilirubinemija);
                        xmlWriter.WriteElementString("Konvulzije", konvulzije);
                        xmlWriter.WriteElementString("PVL", pvl);
                        xmlWriter.WriteElementString("PV-IVH", pv_ivh);
                        xmlWriter.WriteElementString("NEC", nec);
                        xmlWriter.WriteElementString("ROP", rop);
                        xmlWriter.WriteElementString("Ostalo_komplikacije", ostaloTextKomplikacije);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
                }



                //ako datoteka vec postoji onda samo dodavamo podatke, ne radimo novu datoteku
                else
                {   
                    XDocument xDocument = XDocument.Load("Registar.xml");
                    XElement root = xDocument.Element("Registar");
                    IEnumerable<XElement> rows = root.Descendants("Pacijent"); 
                    XElement firstRow = rows.First();

                    firstRow.AddBeforeSelf(
                        new XElement("Pacijent",
                        new XElement("Ime", ime),
                        new XElement("Prezime", prezime),
                        new XElement("Imemajke", imeMajke),
                        new XElement("Imeoca", imeOca),
                        new XElement("Adresa", adresa),
                        new XElement("Kontakt_telefon", kontaktTelefon),
                        new XElement("Datum_rođenja", Convert.ToString(datumRodenja)),
                        new XElement("Spol", spol),
                        new XElement("Paritet_trudnoće", paritetTrudnoce),
                        new XElement("Plodnost_trudnoće", trudnocaPlodna),
                        new XElement("Priroda_trudnoće", trudnocaPrirodna),
                        new XElement("Način_poroda", nacinPoroda),
                        new XElement("Trajanje_poroda", trajanjePoroda),
                        new XElement("Stav_djeteta", stavDjeteta),
                        new XElement("Profilaksa", profilaksa),
                        new XElement("PROM", prom),
                        new XElement("Krvarenje", krvarenje),
                        new XElement("Dijabetes", dijabetes),
                        new XElement("PPI", ppi),
                        new XElement("Infekcije", infekcije),
                        new XElement("Hipertenzija", hipertenzija),
                        new XElement("EPH", eph),
                        new XElement("Ostalo", ostaloTextPatologija),
                        new XElement("Ferbrilitet", febrilitetRodilje),
                        new XElement("Gestacijska_dob_tjedni", gestacijskaDobTjedana),
                        new XElement("Gestacijska_dob_dani", gestacijskaDobDana),
                        new XElement("Rodna_masa", rodnaMasa),
                        new XElement("Rodna_duljina", rodnaDuljina),
                        new XElement("Opseg_glave", opsegGlave),
                        new XElement("Apgar_indeks", apgarIndeks),
                        new XElement("Reanimacija", reanimacija),
                        new XElement("Hipoglikemija", hipoglikemija),
                        new XElement("RDS", rds),
                        new XElement("Mehanička_ventilacija", mehaničkaventilacija),
                        new XElement("Sepsa", sepsa),
                        new XElement("Hiperbilirubinemija", hiperbilirubinemija),
                        new XElement("Konvulzije", konvulzije),
                        new XElement("PVL", pvl),
                        new XElement("PV-IVH", pv_ivh),
                        new XElement("NEC", nec),
                        new XElement("ROP", rop),
                        new XElement("Ostalo_komplikacije", ostaloTextKomplikacije)));
                    xDocument.Save("Registar.xml"); 
                }
                ResetVarijabli();
                            
            }




            //Catch ako slucajno dodje do neke greske tj. krivog unosa
            catch (Exception d)
            {
                MessageBox.Show("Neispravan unos");
            }

            Kraj:;
            }
                
                public void ResetVarijabli()
                {
                //Čišćenje svih podataka(nakon unosa)
                txtGestacijskadobTjedana.Text = "";
                txtGestacijskadobTjedana_Leave(null, null);
                txtPorodStavdjeteta.Text = "";
                txtPorodStavdjeteta_Leave(null, null);
                txtPorodKortikosteroidnaprofilaksa.Text = "";
                txtPorodKortikosteroidnaprofilaksa_Leave(null, null);
                txtTrudnoćaParitet.Text = "";
                txtTrudnocaParitet_Leave(null, null);
                txtPorodStavdjeteta.Text = "";
                txtPorodStavdjeteta_Leave(null, null);
                txtPorodTrajanjeporoda.Text = "";
                txtPorodTrajanjeporoda_Leave(null, null);
                txtGestacijskadobDana.Text = "";
                txtGestacijskadobDana_Leave(null,null);
                txtNovorodenceApgarindeks.Text = "";
                txtNovorodenceApgarindeks_Leave(null, null);
                txtNovorodenceOpsegglave.Text = "";
                txtNovorodenceOpsegglave_Leave(null, null);
                txtNovorodenceRodnaduljina.Text = "";
                txtNovorodenceRodnaduljina_Leave(null, null);
                txtNovorodenceRodnamasa.Text = "";
                txtNovorodenceRodnamasa_Leave(null, null);
                txtNovorođenčeOstalo.Clear();               
                txtOsnovnipodatciAdresa.Text = "";
                txtOsnovnipodatciAdresa_Leave(null, null);
                txtOsnovnipodatciDatumrođenja.ResetText();
                txtOsnovnipodatciIme.Text = "";
                txtOsnovnipodatciIme_Leave(null, null);
                txtOsnovnipodatciImemajke.Text = "";
                txtOsnovnipodatciImeMajke_Leave(null, null);
                txtOsnovnipodatciImeoca.Text = "";
                txtOsnovnipodatciImeOca_Leave(null, null);
                txtOsnovnipodatciKontakttelefon.Text = "";
                txtOsnovnipodatciKontakttelefon_Leave(null, null);
                txtOsnovnipodatciPrezime.Text = "";
                txtOsnovnipodatciPrezime_Leave(null, null);
                txtOsnovnipodatciSpol.ResetText();
                txtOsnovnipodatciSpol_Leave(null, null);
                txtPatologijaTrudnoćeOstalo.Clear();
                rbtnPorodCarskirez.Checked = false;
                rbtnTrunocaJednoplodna.Checked = false;
                rbtnTrunocaPotpomognuta.Checked = false;
                rbtnTrunocaPrirodna.Checked = false;
                rbtnTrunocaViseplodna.Checked = false;
                rbtnVaginalno.Checked = false;
                chkBoxNovorodenceReanimacija.Checked = false;
                chkBoxNovorođenčeOstalo.Checked = false;
                chkBoxPatologijaTrudnoćeOstalo.Checked = false;
                chkBoxPorodFebrilitetrodilje.Checked = false;
                chkBoxPorodPROM.Checked = false;
                chkBoxPatologijatrudnoceDijabetes.Checked = false;
                chkBoxPatologijatrudnoceEPH.Checked = false;
                chkBoxPatologijatrudnoceHipertenzija.Checked = false;
                chkBoxPatologijatrudnoceInfekcije.Checked = false;
                chkBoxPatologijatrudnoceKrvarenje.Checked = false;
                chkBoxPatologijatrudnocePPI.Checked = false;
                chkBoxPatologijaTrudnoćeOstalo.Checked = false;
                chkBoxNovorođenčeHiperbilirubinemija.Checked = false;
                chkBoxNovorođenčeHipoglikemija.Checked = false;
                chkBoxNovorođenčeKonvulzije.Checked = false;
                chkBoxNovorođenčeMehVentilacija.Checked = false;
                chkBoxNovorođenčeNEC.Checked = false;
                chkBoxNovorođenčeOstalo.Checked = false;
                chkBoxNovorođenčePVIVH.Checked = false;
                chkBoxNovorođenčePVL.Checked = false;
                chkBoxNovorođenčeRDS.Checked = false;
                chkBoxNovorođenčeROP.Checked = false;
                chkBoxNovorođenčeSepsa.Checked = false;
                txtNovorođenčeOstalo.Clear();
                }
     






        private void button2_Click(object sender, EventArgs e)
        {
                //pozivanje forme za pregled nakon pristiska gumba search
                PregledPodataka f2 = new PregledPodataka();
                f2.ShowDialog();
            
        }



       



        //-------------------------------------------------POSTAVLJANE "HINTOVA" U TEXT-BOXOVE POČETAK----------------------------------------------//
        // Ime


        private void txtOsnovnipodatciIme_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciIme.Text == "Ime")
            {
                txtOsnovnipodatciIme.Text = "";
                txtOsnovnipodatciIme.ForeColor = Color.Black;
            }
        }
       
        private void txtOsnovnipodatciIme_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciIme.Text == "")
            {
                txtOsnovnipodatciIme.Text = "Ime";
                txtOsnovnipodatciIme.ForeColor = Color.Gray;
            }
        }
        // Prezime
        private void txtOsnovnipodatciPrezime_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciPrezime.Text == "Prezime")
            {
                txtOsnovnipodatciPrezime.Text = "";
                txtOsnovnipodatciPrezime.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciPrezime_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciPrezime.Text == "")
            {
                txtOsnovnipodatciPrezime.Text = "Prezime";
                txtOsnovnipodatciPrezime.ForeColor = Color.Gray;
            }
        }
        // Spol

        private void txtOsnovnipodatciSpol_Enter(object sender, EventArgs e)
        {

            if (txtOsnovnipodatciSpol.Text == "Spol")
            {
                txtOsnovnipodatciSpol.Text = "";
                txtOsnovnipodatciSpol.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciSpol_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciSpol.Text == "")
            {
                txtOsnovnipodatciSpol.Text = "Spol";
                txtOsnovnipodatciSpol.ForeColor = Color.Gray;
            }
        }
        // Ime oca
        private void txtOsnovnipodatciImeOca_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciImeoca.Text == "Ime oca")
            {
                txtOsnovnipodatciImeoca.Text = "";
                txtOsnovnipodatciImeoca.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciImeOca_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciImeoca.Text == "")
            {
                txtOsnovnipodatciImeoca.Text = "Ime oca";
                txtOsnovnipodatciImeoca.ForeColor = Color.Gray;
            }
        }
        // IME MAJKE
        private void txtOsnovnipodatciImeMajke_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciImemajke.Text == "Ime majke")
            {
                txtOsnovnipodatciImemajke.Text = "";
                txtOsnovnipodatciImemajke.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciImeMajke_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciImemajke.Text == "")
            {
                txtOsnovnipodatciImemajke.Text = "Ime majke";
                txtOsnovnipodatciImemajke.ForeColor = Color.Gray;
            }
        }
        // Adresa
        private void txtOsnovnipodatciAdresa_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciAdresa.Text == "Adresa")
            {
                txtOsnovnipodatciAdresa.Text = "";
                txtOsnovnipodatciAdresa.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciAdresa_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciAdresa.Text == "")
            {
                txtOsnovnipodatciAdresa.Text = "Adresa";
                txtOsnovnipodatciAdresa.ForeColor = Color.Gray;
            }
        }
        // Kontakt telefon
        private void txtOsnovnipodatciKontakttelefon_Enter(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciKontakttelefon.Text == "Kontakt telefon")
            {
                txtOsnovnipodatciKontakttelefon.Text = "";
                txtOsnovnipodatciKontakttelefon.ForeColor = Color.Black;
            }
        }
        private void txtOsnovnipodatciKontakttelefon_Leave(object sender, EventArgs e)
        {
            if (txtOsnovnipodatciKontakttelefon.Text == "")
            {
                txtOsnovnipodatciKontakttelefon.Text = "Kontakt telefon";
                txtOsnovnipodatciKontakttelefon.ForeColor = Color.Gray;
            }
        }
        // Gestacijska dob - Tjedana
        private void txtGestacijskadobTjedana_Enter(object sender, EventArgs e)
        {
            if (txtGestacijskadobTjedana.Text == "Tjedana")
            {

                txtGestacijskadobTjedana.Text = "";
                txtGestacijskadobTjedana.ForeColor = Color.Black;
            }
        }
        private void txtGestacijskadobTjedana_Leave(object sender, EventArgs e)
        {
            if (txtGestacijskadobTjedana.Text == "")
            {
                txtGestacijskadobTjedana.Text = "Tjedana";
                txtGestacijskadobTjedana.ForeColor = Color.Gray;
            }
        }
        // Gestacijska dob - Dana
        private void txtGestacijskadobDana_Enter(object sender, EventArgs e)
        {
            if (txtGestacijskadobDana.Text == "Dana")
            {

                txtGestacijskadobDana.Text = "";
                txtGestacijskadobDana.ForeColor = Color.Black;
            }
        }
        private void txtGestacijskadobDana_Leave(object sender, EventArgs e)
        {
            if (txtGestacijskadobDana.Text == "")
            {
                txtGestacijskadobDana.Text = "Dana";
                txtGestacijskadobDana.ForeColor = Color.Gray;
            }
        }
        // Rodna masa
        private void txtNovorodenceRodnamasa_Enter(object sender, EventArgs e)
        {
            if (txtNovorodenceRodnamasa.Text == "Rodna masa (RM/g)")
            {

                txtNovorodenceRodnamasa.Text = "";
                txtNovorodenceRodnamasa.ForeColor = Color.Black;
            }
        }
        private void txtNovorodenceRodnamasa_Leave(object sender, EventArgs e)
        {
            if (txtNovorodenceRodnamasa.Text == "")
            {
                txtNovorodenceRodnamasa.Text = "Rodna masa (RM/g)";
                txtNovorodenceRodnamasa.ForeColor = Color.Gray;
            }
        }

        // Rodna duljina
        private void txtNovorodenceRodnaduljina_Enter(object sender, EventArgs e)
        {
            if (txtNovorodenceRodnaduljina.Text == "Rodna duljina (RD/cm)")
            {

                txtNovorodenceRodnaduljina.Text = "";
                txtNovorodenceRodnaduljina.ForeColor = Color.Black;
            }
        }
        private void txtNovorodenceRodnaduljina_Leave(object sender, EventArgs e)
        {
            if (txtNovorodenceRodnaduljina.Text == "")
            {

                txtNovorodenceRodnaduljina.Text = "Rodna duljina (RD/cm)";
                txtNovorodenceRodnaduljina.ForeColor = Color.Gray;
            }
        }

        // Opseg glave
        private void txtNovorodenceOpsegglave_Enter(object sender, EventArgs e)
        {
            if (txtNovorodenceOpsegglave.Text == "Opseg glave (OG/cm)")
            {
                txtNovorodenceOpsegglave.Text = "";
                txtNovorodenceOpsegglave.ForeColor = Color.Black;
            }
        }
        private void txtNovorodenceOpsegglave_Leave(object sender, EventArgs e)
        {
            if (txtNovorodenceOpsegglave.Text == "")
            {
                txtNovorodenceOpsegglave.Text = "Opseg glave (OG/cm)";
                txtNovorodenceOpsegglave.ForeColor = Color.Gray;
            }
        }

        // Apgar indeks
        private void txtNovorodenceApgarindeks_Enter(object sender, EventArgs e)
        {

            if (txtNovorodenceApgarindeks.Text == "Apgar indeks")
            {
                txtNovorodenceApgarindeks.Text = "";
                txtNovorodenceApgarindeks.ForeColor = Color.Black;
            }
        }
        private void txtNovorodenceApgarindeks_Leave(object sender, EventArgs e)
        {
            if (txtNovorodenceApgarindeks.Text == "")
            {
                txtNovorodenceApgarindeks.Text = "Apgar indeks";
                txtNovorodenceApgarindeks.ForeColor = Color.Gray;
            }
        }

        // Paritet
        private void txtTrudnocaParitet_Enter(object sender, EventArgs e)
        {
            if (txtTrudnoćaParitet.Text == "Paritet")
            {

                txtTrudnoćaParitet.Text = "";
                txtTrudnoćaParitet.ForeColor = Color.Black;
            }
        }
        private void txtTrudnocaParitet_Leave(object sender, EventArgs e)
        {
            if (txtTrudnoćaParitet.Text == "")
            {
                txtTrudnoćaParitet.Text = "Paritet";
                txtTrudnoćaParitet.ForeColor = Color.Gray;
            }
        }

        // Kortikosteroidna profilaksa
        private void txtPorodKortikosteroidnaprofilaksa_Enter(object sender, EventArgs e)
        {

            if (txtPorodKortikosteroidnaprofilaksa.Text == "Kortikosteroidna profilaksa")
            {

                txtPorodKortikosteroidnaprofilaksa.Text = "";
                txtPorodKortikosteroidnaprofilaksa.ForeColor = Color.Black;
            }
        }
        private void txtPorodKortikosteroidnaprofilaksa_Leave(object sender, EventArgs e)
        {
            if (txtPorodKortikosteroidnaprofilaksa.Text == "")
            {
                txtPorodKortikosteroidnaprofilaksa.Text = "Kortikosteroidna profilaksa";
                txtPorodKortikosteroidnaprofilaksa.ForeColor = Color.Gray;
            }
        }

        // Stav djeteta
        private void txtPorodStavdjeteta_Enter(object sender, EventArgs e)
        {
            if (txtPorodStavdjeteta.Text == "Stav djeteta")
            {

                txtPorodStavdjeteta.Text = "";
                txtPorodStavdjeteta.ForeColor = Color.Black;
            }
        }
        private void txtPorodStavdjeteta_Leave(object sender, EventArgs e)
        {
            if (txtPorodStavdjeteta.Text == "")
            {

                txtPorodStavdjeteta.Text = "Stav djeteta";
                txtPorodStavdjeteta.ForeColor = Color.Gray;
            }

        }

        // Trajanje poroda
        private void txtPorodTrajanjeporoda_Enter(object sender, EventArgs e)
        {

            if (txtPorodTrajanjeporoda.Text == "Trajanje poroda")
            {

                txtPorodTrajanjeporoda.Text = "";
                txtPorodTrajanjeporoda.ForeColor = Color.Black;
            }
        }
        private void txtPorodTrajanjeporoda_Leave(object sender, EventArgs e)
        {
            if (txtPorodTrajanjeporoda.Text == "")
            {
                txtPorodTrajanjeporoda.Text = "Trajanje poroda";
                txtPorodTrajanjeporoda.ForeColor = Color.Gray;
            }
        }

        //-------------------------------------------------POSTAVLJANE "HINTOVA" U TEXT-BOXOVE KRAJ----------------------------------------------//

        private void button3_Click(object sender, EventArgs e)
        {   
            //pozivanje funkcije za čišćenje podataka nakon odabira gumba reset
            ResetVarijabli();
        }




        //--------------------------------------------------------------------SLUČAJNO GENERIRANE FUNKCIJE POČETAK---------------------------------------------------------------//

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void chkBoxPorodPROM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxNovorođenčeMehV_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtOsnovnipodatciDatumrođenja_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void txtPorodKortikosteroidnaprofilaksa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtOsnovnipodatciIme_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNovorodenceRodnamasa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTrudnoćaParitet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPorodStavdjeteta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void txtOsnovnipodatciImeoca_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnVaginalno_CheckedChanged(object sender, EventArgs e)
        {

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
            if (chkBoxNovorođenčeOstalo.Checked)
            {
                txtNovorođenčeOstalo.Enabled = true;
            }
            else
            {
                txtNovorođenčeOstalo.Enabled = false;
            }
        }

        private void txtPatologijaTrudnoćeOstalo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOsnovnipodatciSpol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------------SLUČAJNO GENERIRANE FUNKCIJE KRAJ---------------------------------------------------------------//
    }
}

namespace KBCRijekaKantridaRegistar.GUI
{
    partial class Pocetna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUnosPacijenta = new System.Windows.Forms.Button();
            this.btnPregledPacijenata = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUnosPacijenta
            // 
            this.btnUnosPacijenta.Location = new System.Drawing.Point(12, 12);
            this.btnUnosPacijenta.Name = "btnUnosPacijenta";
            this.btnUnosPacijenta.Size = new System.Drawing.Size(156, 48);
            this.btnUnosPacijenta.TabIndex = 0;
            this.btnUnosPacijenta.Text = "Unos novog pacijenta";
            this.btnUnosPacijenta.UseVisualStyleBackColor = true;
            this.btnUnosPacijenta.Click += new System.EventHandler(this.btnUnosPacijenta_Click);
            // 
            // btnPregledPacijenata
            // 
            this.btnPregledPacijenata.Location = new System.Drawing.Point(12, 66);
            this.btnPregledPacijenata.Name = "btnPregledPacijenata";
            this.btnPregledPacijenata.Size = new System.Drawing.Size(156, 48);
            this.btnPregledPacijenata.TabIndex = 1;
            this.btnPregledPacijenata.Text = "Pregled pacijenata";
            this.btnPregledPacijenata.UseVisualStyleBackColor = true;
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Location = new System.Drawing.Point(12, 120);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(156, 48);
            this.btnIzlaz.TabIndex = 2;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            // 
            // Pocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 178);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnPregledPacijenata);
            this.Controls.Add(this.btnUnosPacijenta);
            this.Name = "Pocetna";
            this.Text = "Registar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnosPacijenta;
        private System.Windows.Forms.Button btnPregledPacijenata;
        private System.Windows.Forms.Button btnIzlaz;
    }
}
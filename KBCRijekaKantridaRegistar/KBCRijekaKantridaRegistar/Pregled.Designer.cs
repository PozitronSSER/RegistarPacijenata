namespace KBCRijekaKantridaRegistar
{
    partial class Pregled
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
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.Imelabel = new System.Windows.Forms.Label();
            this.Prezimelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Font = new System.Drawing.Font("Calibri Light", 13F);
            this.btnPretrazi.Location = new System.Drawing.Point(394, 17);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(81, 29);
            this.btnPretrazi.TabIndex = 0;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Font = new System.Drawing.Font("Calibri Light", 13F);
            this.txtPrezime.Location = new System.Drawing.Point(257, 17);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(119, 29);
            this.txtPrezime.TabIndex = 1;
            // 
            // txtIme
            // 
            this.txtIme.Font = new System.Drawing.Font("Calibri Light", 13F);
            this.txtIme.Location = new System.Drawing.Point(53, 18);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(119, 29);
            this.txtIme.TabIndex = 2;
            // 
            // Imelabel
            // 
            this.Imelabel.AutoSize = true;
            this.Imelabel.Font = new System.Drawing.Font("Calibri Light", 13F);
            this.Imelabel.Location = new System.Drawing.Point(5, 20);
            this.Imelabel.Name = "Imelabel";
            this.Imelabel.Size = new System.Drawing.Size(42, 22);
            this.Imelabel.TabIndex = 3;
            this.Imelabel.Text = "Ime:";
            // 
            // Prezimelabel
            // 
            this.Prezimelabel.AutoSize = true;
            this.Prezimelabel.Font = new System.Drawing.Font("Calibri Light", 13F);
            this.Prezimelabel.Location = new System.Drawing.Point(178, 20);
            this.Prezimelabel.Name = "Prezimelabel";
            this.Prezimelabel.Size = new System.Drawing.Size(73, 22);
            this.Prezimelabel.TabIndex = 4;
            this.Prezimelabel.Text = "Prezime:";
            // 
            // Pregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 142);
            this.Controls.Add(this.Prezimelabel);
            this.Controls.Add(this.Imelabel);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.btnPretrazi);
            this.Name = "Pregled";
            this.Text = "Pregled";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label Imelabel;
        private System.Windows.Forms.Label Prezimelabel;
    }
}
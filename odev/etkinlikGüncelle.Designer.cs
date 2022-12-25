namespace odev
{
    partial class etkinlikGüncelle
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grpPersonal = new System.Windows.Forms.GroupBox();
            this.cmbKimIcin = new System.Windows.Forms.ComboBox();
            this.dtpEtkinlikTarih = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKontenjan = new System.Windows.Forms.TextBox();
            this.txtEtkinlikSaat = new System.Windows.Forms.TextBox();
            this.txtEtkinlikAd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCalNo1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCalSoayd1 = new System.Windows.Forms.TextBox();
            this.grpCal1 = new System.Windows.Forms.GroupBox();
            this.txtCalAd1 = new System.Windows.Forms.TextBox();
            this.txtCalTC1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCinsiyet = new System.Windows.Forms.TextBox();
            this.grpPersonal.SuspendLayout();
            this.grpCal1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(44, 661);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 43);
            this.button1.TabIndex = 69;
            this.button1.Text = "Menüye Dön";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(290, 661);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 43);
            this.button2.TabIndex = 70;
            this.button2.Text = "Güncelle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grpPersonal
            // 
            this.grpPersonal.Controls.Add(this.cmbKimIcin);
            this.grpPersonal.Controls.Add(this.dtpEtkinlikTarih);
            this.grpPersonal.Controls.Add(this.label6);
            this.grpPersonal.Controls.Add(this.txtKontenjan);
            this.grpPersonal.Controls.Add(this.txtEtkinlikSaat);
            this.grpPersonal.Controls.Add(this.txtEtkinlikAd);
            this.grpPersonal.Controls.Add(this.label5);
            this.grpPersonal.Controls.Add(this.label3);
            this.grpPersonal.Controls.Add(this.label2);
            this.grpPersonal.Controls.Add(this.label1);
            this.grpPersonal.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPersonal.Location = new System.Drawing.Point(257, 112);
            this.grpPersonal.Name = "grpPersonal";
            this.grpPersonal.Size = new System.Drawing.Size(497, 488);
            this.grpPersonal.TabIndex = 75;
            this.grpPersonal.TabStop = false;
            this.grpPersonal.Text = "Etkinlik Bilgileri";
            // 
            // cmbKimIcin
            // 
            this.cmbKimIcin.FormattingEnabled = true;
            this.cmbKimIcin.Items.AddRange(new object[] {
            "Kadin",
            "Erkek",
            "Genc",
            "Cocuk"});
            this.cmbKimIcin.Location = new System.Drawing.Point(199, 395);
            this.cmbKimIcin.Name = "cmbKimIcin";
            this.cmbKimIcin.Size = new System.Drawing.Size(264, 37);
            this.cmbKimIcin.TabIndex = 42;
            // 
            // dtpEtkinlikTarih
            // 
            this.dtpEtkinlikTarih.Location = new System.Drawing.Point(199, 125);
            this.dtpEtkinlikTarih.Name = "dtpEtkinlikTarih";
            this.dtpEtkinlikTarih.Size = new System.Drawing.Size(264, 36);
            this.dtpEtkinlikTarih.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 29);
            this.label6.TabIndex = 25;
            this.label6.Text = "Kimler Icin";
            // 
            // txtKontenjan
            // 
            this.txtKontenjan.Location = new System.Drawing.Point(199, 305);
            this.txtKontenjan.Name = "txtKontenjan";
            this.txtKontenjan.Size = new System.Drawing.Size(264, 36);
            this.txtKontenjan.TabIndex = 12;
            // 
            // txtEtkinlikSaat
            // 
            this.txtEtkinlikSaat.Location = new System.Drawing.Point(199, 215);
            this.txtEtkinlikSaat.Name = "txtEtkinlikSaat";
            this.txtEtkinlikSaat.Size = new System.Drawing.Size(264, 36);
            this.txtEtkinlikSaat.TabIndex = 8;
            // 
            // txtEtkinlikAd
            // 
            this.txtEtkinlikAd.Location = new System.Drawing.Point(199, 35);
            this.txtEtkinlikAd.Name = "txtEtkinlikAd";
            this.txtEtkinlikAd.Size = new System.Drawing.Size(264, 36);
            this.txtEtkinlikAd.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kontenjan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Etkinlik Adi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Etkinlik Tarihi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Etkinlik Saati";
            // 
            // txtCalNo1
            // 
            this.txtCalNo1.Location = new System.Drawing.Point(166, 37);
            this.txtCalNo1.Name = "txtCalNo1";
            this.txtCalNo1.ReadOnly = true;
            this.txtCalNo1.Size = new System.Drawing.Size(264, 36);
            this.txtCalNo1.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 29);
            this.label7.TabIndex = 43;
            this.label7.Text = "1. Calisan No";
            // 
            // txtCalSoayd1
            // 
            this.txtCalSoayd1.Location = new System.Drawing.Point(166, 202);
            this.txtCalSoayd1.Name = "txtCalSoayd1";
            this.txtCalSoayd1.ReadOnly = true;
            this.txtCalSoayd1.Size = new System.Drawing.Size(264, 36);
            this.txtCalSoayd1.TabIndex = 8;
            // 
            // grpCal1
            // 
            this.grpCal1.Controls.Add(this.txtCinsiyet);
            this.grpCal1.Controls.Add(this.txtCalSoayd1);
            this.grpCal1.Controls.Add(this.txtCalAd1);
            this.grpCal1.Controls.Add(this.txtCalNo1);
            this.grpCal1.Controls.Add(this.label7);
            this.grpCal1.Controls.Add(this.txtCalTC1);
            this.grpCal1.Controls.Add(this.label17);
            this.grpCal1.Controls.Add(this.label18);
            this.grpCal1.Controls.Add(this.label19);
            this.grpCal1.Controls.Add(this.label20);
            this.grpCal1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCal1.Location = new System.Drawing.Point(786, 218);
            this.grpCal1.Name = "grpCal1";
            this.grpCal1.Size = new System.Drawing.Size(461, 313);
            this.grpCal1.TabIndex = 76;
            this.grpCal1.TabStop = false;
            this.grpCal1.Text = "Calisan Bilgileri";
            // 
            // txtCalAd1
            // 
            this.txtCalAd1.Location = new System.Drawing.Point(166, 146);
            this.txtCalAd1.Name = "txtCalAd1";
            this.txtCalAd1.ReadOnly = true;
            this.txtCalAd1.Size = new System.Drawing.Size(264, 36);
            this.txtCalAd1.TabIndex = 7;
            // 
            // txtCalTC1
            // 
            this.txtCalTC1.Location = new System.Drawing.Point(166, 95);
            this.txtCalTC1.Name = "txtCalTC1";
            this.txtCalTC1.ReadOnly = true;
            this.txtCalTC1.Size = new System.Drawing.Size(264, 36);
            this.txtCalTC1.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(18, 266);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 29);
            this.label17.TabIndex = 3;
            this.label17.Text = "Cinsiyet";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(18, 98);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 29);
            this.label18.TabIndex = 2;
            this.label18.Text = "TC";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(18, 154);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 29);
            this.label19.TabIndex = 1;
            this.label19.Text = "Isim";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(18, 210);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 29);
            this.label20.TabIndex = 0;
            this.label20.Text = "Soyisim";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(781, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 29);
            this.label4.TabIndex = 73;
            this.label4.Text = "Etkinlik No";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(965, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 36);
            this.textBox1.TabIndex = 74;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtCinsiyet
            // 
            this.txtCinsiyet.Location = new System.Drawing.Point(166, 259);
            this.txtCinsiyet.Name = "txtCinsiyet";
            this.txtCinsiyet.ReadOnly = true;
            this.txtCinsiyet.Size = new System.Drawing.Size(264, 36);
            this.txtCinsiyet.TabIndex = 45;
            // 
            // etkinlikGüncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.grpPersonal);
            this.Controls.Add(this.grpCal1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "etkinlikGüncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "etkinlikGüncelle";
            this.grpPersonal.ResumeLayout(false);
            this.grpPersonal.PerformLayout();
            this.grpCal1.ResumeLayout(false);
            this.grpCal1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox grpPersonal;
        private System.Windows.Forms.ComboBox cmbKimIcin;
        private System.Windows.Forms.DateTimePicker dtpEtkinlikTarih;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKontenjan;
        private System.Windows.Forms.TextBox txtEtkinlikSaat;
        private System.Windows.Forms.TextBox txtEtkinlikAd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCalNo1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCalSoayd1;
        private System.Windows.Forms.GroupBox grpCal1;
        private System.Windows.Forms.TextBox txtCalAd1;
        private System.Windows.Forms.TextBox txtCalTC1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCinsiyet;
    }
}
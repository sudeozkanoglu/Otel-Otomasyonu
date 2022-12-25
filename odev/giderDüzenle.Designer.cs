namespace odev
{
    partial class giderDüzenle
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
            this.txtGiderNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMenü = new System.Windows.Forms.Button();
            this.grpPersonal = new System.Windows.Forms.GroupBox();
            this.cmbGiderTur = new System.Windows.Forms.ComboBox();
            this.dtpGiderTarih = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtGiderTutar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.grpPersonal.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGiderNo
            // 
            this.txtGiderNo.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiderNo.Location = new System.Drawing.Point(690, 150);
            this.txtGiderNo.Name = "txtGiderNo";
            this.txtGiderNo.Size = new System.Drawing.Size(264, 36);
            this.txtGiderNo.TabIndex = 25;
            this.txtGiderNo.TextChanged += new System.EventHandler(this.txtGiderNo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(511, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 29);
            this.label4.TabIndex = 24;
            this.label4.Text = "Gider No";
            // 
            // btnMenü
            // 
            this.btnMenü.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenü.Location = new System.Drawing.Point(1230, 693);
            this.btnMenü.Name = "btnMenü";
            this.btnMenü.Size = new System.Drawing.Size(229, 43);
            this.btnMenü.TabIndex = 23;
            this.btnMenü.Text = "Menüye Dön";
            this.btnMenü.UseVisualStyleBackColor = true;
            this.btnMenü.Click += new System.EventHandler(this.btnMenü_Click);
            // 
            // grpPersonal
            // 
            this.grpPersonal.Controls.Add(this.label18);
            this.grpPersonal.Controls.Add(this.cmbGiderTur);
            this.grpPersonal.Controls.Add(this.dtpGiderTarih);
            this.grpPersonal.Controls.Add(this.label1);
            this.grpPersonal.Controls.Add(this.btnKaydet);
            this.grpPersonal.Controls.Add(this.txtGiderTutar);
            this.grpPersonal.Controls.Add(this.label3);
            this.grpPersonal.Controls.Add(this.label2);
            this.grpPersonal.Font = new System.Drawing.Font("Bradley Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPersonal.Location = new System.Drawing.Point(493, 248);
            this.grpPersonal.Name = "grpPersonal";
            this.grpPersonal.Size = new System.Drawing.Size(558, 264);
            this.grpPersonal.TabIndex = 22;
            this.grpPersonal.TabStop = false;
            this.grpPersonal.Text = "Gider Bilgileri";
            // 
            // cmbGiderTur
            // 
            this.cmbGiderTur.FormattingEnabled = true;
            this.cmbGiderTur.Items.AddRange(new object[] {
            "Elektirik",
            "Su",
            "Dogalgaz",
            "Market",
            "Etkinlik ",
            "Susleme",
            "Dekorasyon",
            "Diger"});
            this.cmbGiderTur.Location = new System.Drawing.Point(197, 41);
            this.cmbGiderTur.Name = "cmbGiderTur";
            this.cmbGiderTur.Size = new System.Drawing.Size(264, 33);
            this.cmbGiderTur.TabIndex = 12;
            // 
            // dtpGiderTarih
            // 
            this.dtpGiderTarih.Location = new System.Drawing.Point(197, 94);
            this.dtpGiderTarih.Name = "dtpGiderTarih";
            this.dtpGiderTarih.Size = new System.Drawing.Size(264, 32);
            this.dtpGiderTarih.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Gider Tarih";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(216, 219);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(192, 39);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtGiderTutar
            // 
            this.txtGiderTutar.Location = new System.Drawing.Point(197, 144);
            this.txtGiderTutar.Name = "txtGiderTutar";
            this.txtGiderTutar.Size = new System.Drawing.Size(264, 32);
            this.txtGiderTutar.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gider Türü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gider Tutari ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(478, 151);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 25);
            this.label18.TabIndex = 40;
            this.label18.Text = "TL";
            // 
            // giderDüzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.txtGiderNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnMenü);
            this.Controls.Add(this.grpPersonal);
            this.Name = "giderDüzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "giderDüzenle";
            this.grpPersonal.ResumeLayout(false);
            this.grpPersonal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGiderNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMenü;
        private System.Windows.Forms.GroupBox grpPersonal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtGiderTutar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpGiderTarih;
        private System.Windows.Forms.ComboBox cmbGiderTur;
        private System.Windows.Forms.Label label18;
    }
}
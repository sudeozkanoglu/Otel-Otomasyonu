namespace odev
{
    partial class gider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gider));
            this.btnGiderEkle = new System.Windows.Forms.Button();
            this.btnGiderGüncelle = new System.Windows.Forms.Button();
            this.btnGiderListele = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGiderSil = new System.Windows.Forms.Button();
            this.btnMenü = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGiderEkle
            // 
            this.btnGiderEkle.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiderEkle.Location = new System.Drawing.Point(746, 197);
            this.btnGiderEkle.Name = "btnGiderEkle";
            this.btnGiderEkle.Size = new System.Drawing.Size(333, 62);
            this.btnGiderEkle.TabIndex = 0;
            this.btnGiderEkle.Text = "Gider Bilgisi Ekle";
            this.btnGiderEkle.UseVisualStyleBackColor = true;
            this.btnGiderEkle.Click += new System.EventHandler(this.btnGiderEkle_Click);
            // 
            // btnGiderGüncelle
            // 
            this.btnGiderGüncelle.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiderGüncelle.Location = new System.Drawing.Point(746, 313);
            this.btnGiderGüncelle.Name = "btnGiderGüncelle";
            this.btnGiderGüncelle.Size = new System.Drawing.Size(333, 62);
            this.btnGiderGüncelle.TabIndex = 1;
            this.btnGiderGüncelle.Text = "Gider Bilgisi Güncelle";
            this.btnGiderGüncelle.UseVisualStyleBackColor = true;
            this.btnGiderGüncelle.Click += new System.EventHandler(this.btnGiderGüncelle_Click);
            // 
            // btnGiderListele
            // 
            this.btnGiderListele.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiderListele.Location = new System.Drawing.Point(746, 545);
            this.btnGiderListele.Name = "btnGiderListele";
            this.btnGiderListele.Size = new System.Drawing.Size(333, 62);
            this.btnGiderListele.TabIndex = 3;
            this.btnGiderListele.Text = "Gider Bilgisi Listele";
            this.btnGiderListele.UseVisualStyleBackColor = true;
            this.btnGiderListele.Click += new System.EventHandler(this.btnGiderListele_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(758, 766);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnGiderSil
            // 
            this.btnGiderSil.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiderSil.Location = new System.Drawing.Point(746, 429);
            this.btnGiderSil.Name = "btnGiderSil";
            this.btnGiderSil.Size = new System.Drawing.Size(333, 62);
            this.btnGiderSil.TabIndex = 2;
            this.btnGiderSil.Text = "Gider Bilgisi Sil";
            this.btnGiderSil.UseVisualStyleBackColor = true;
            this.btnGiderSil.Click += new System.EventHandler(this.btnGiderSil_Click);
            // 
            // btnMenü
            // 
            this.btnMenü.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenü.Location = new System.Drawing.Point(1262, 716);
            this.btnMenü.Name = "btnMenü";
            this.btnMenü.Size = new System.Drawing.Size(231, 62);
            this.btnMenü.TabIndex = 5;
            this.btnMenü.Text = "Menüye Dön";
            this.btnMenü.UseVisualStyleBackColor = true;
            this.btnMenü.Click += new System.EventHandler(this.btnMenü_Click);
            // 
            // gider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.btnMenü);
            this.Controls.Add(this.btnGiderListele);
            this.Controls.Add(this.btnGiderSil);
            this.Controls.Add(this.btnGiderGüncelle);
            this.Controls.Add(this.btnGiderEkle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "gider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gider";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGiderEkle;
        private System.Windows.Forms.Button btnGiderGüncelle;
        private System.Windows.Forms.Button btnGiderListele;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGiderSil;
        private System.Windows.Forms.Button btnMenü;
    }
}
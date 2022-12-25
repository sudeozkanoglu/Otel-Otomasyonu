namespace odev
{
    partial class etkinlik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(etkinlik));
            this.btnEtkinlikListele = new System.Windows.Forms.Button();
            this.btnEtkinlikSil = new System.Windows.Forms.Button();
            this.btnEtkinlikGüncelle = new System.Windows.Forms.Button();
            this.btnEtkinlikEkle = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEtkinlikListele
            // 
            this.btnEtkinlikListele.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtkinlikListele.Location = new System.Drawing.Point(746, 545);
            this.btnEtkinlikListele.Name = "btnEtkinlikListele";
            this.btnEtkinlikListele.Size = new System.Drawing.Size(337, 62);
            this.btnEtkinlikListele.TabIndex = 8;
            this.btnEtkinlikListele.Text = "Etkinlik Bilgisi Listele";
            this.btnEtkinlikListele.UseVisualStyleBackColor = true;
            this.btnEtkinlikListele.Click += new System.EventHandler(this.btnEtkinlikListele_Click);
            // 
            // btnEtkinlikSil
            // 
            this.btnEtkinlikSil.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtkinlikSil.Location = new System.Drawing.Point(746, 429);
            this.btnEtkinlikSil.Name = "btnEtkinlikSil";
            this.btnEtkinlikSil.Size = new System.Drawing.Size(337, 62);
            this.btnEtkinlikSil.TabIndex = 7;
            this.btnEtkinlikSil.Text = "Etkinlik Bilgisi Sil";
            this.btnEtkinlikSil.UseVisualStyleBackColor = true;
            this.btnEtkinlikSil.Click += new System.EventHandler(this.btnEtkinlikSil_Click);
            // 
            // btnEtkinlikGüncelle
            // 
            this.btnEtkinlikGüncelle.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtkinlikGüncelle.Location = new System.Drawing.Point(746, 313);
            this.btnEtkinlikGüncelle.Name = "btnEtkinlikGüncelle";
            this.btnEtkinlikGüncelle.Size = new System.Drawing.Size(337, 62);
            this.btnEtkinlikGüncelle.TabIndex = 6;
            this.btnEtkinlikGüncelle.Text = "Etkinlik Bilgisi Güncelle";
            this.btnEtkinlikGüncelle.UseVisualStyleBackColor = true;
            this.btnEtkinlikGüncelle.Click += new System.EventHandler(this.btnEtkinlikGüncelle_Click);
            // 
            // btnEtkinlikEkle
            // 
            this.btnEtkinlikEkle.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtkinlikEkle.Location = new System.Drawing.Point(746, 197);
            this.btnEtkinlikEkle.Name = "btnEtkinlikEkle";
            this.btnEtkinlikEkle.Size = new System.Drawing.Size(337, 62);
            this.btnEtkinlikEkle.TabIndex = 5;
            this.btnEtkinlikEkle.Text = "Etkinlik Bilgisi Ekle";
            this.btnEtkinlikEkle.UseVisualStyleBackColor = true;
            this.btnEtkinlikEkle.Click += new System.EventHandler(this.btnEtkinlikEkle_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(758, 766);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1187, 716);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 62);
            this.button1.TabIndex = 10;
            this.button1.Text = "Menüye Dön";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // etkinlik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEtkinlikListele);
            this.Controls.Add(this.btnEtkinlikSil);
            this.Controls.Add(this.btnEtkinlikGüncelle);
            this.Controls.Add(this.btnEtkinlikEkle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "etkinlik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "etkinlik";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEtkinlikListele;
        private System.Windows.Forms.Button btnEtkinlikSil;
        private System.Windows.Forms.Button btnEtkinlikGüncelle;
        private System.Windows.Forms.Button btnEtkinlikEkle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}
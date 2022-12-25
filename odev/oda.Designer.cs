namespace odev
{
    partial class oda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(oda));
            this.btnOdaListe = new System.Windows.Forms.Button();
            this.btnOdaSil = new System.Windows.Forms.Button();
            this.btnOdaGüncelle = new System.Windows.Forms.Button();
            this.btnOdaEkle = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOdaListe
            // 
            this.btnOdaListe.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdaListe.Location = new System.Drawing.Point(746, 545);
            this.btnOdaListe.Name = "btnOdaListe";
            this.btnOdaListe.Size = new System.Drawing.Size(311, 62);
            this.btnOdaListe.TabIndex = 8;
            this.btnOdaListe.Text = "Oda Bilgisi Listele";
            this.btnOdaListe.UseVisualStyleBackColor = true;
            this.btnOdaListe.Click += new System.EventHandler(this.btnOdaListe_Click);
            // 
            // btnOdaSil
            // 
            this.btnOdaSil.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdaSil.Location = new System.Drawing.Point(746, 429);
            this.btnOdaSil.Name = "btnOdaSil";
            this.btnOdaSil.Size = new System.Drawing.Size(311, 62);
            this.btnOdaSil.TabIndex = 7;
            this.btnOdaSil.Text = "Oda Bilgisi Sil";
            this.btnOdaSil.UseVisualStyleBackColor = true;
            this.btnOdaSil.Click += new System.EventHandler(this.btnOdaSil_Click);
            // 
            // btnOdaGüncelle
            // 
            this.btnOdaGüncelle.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdaGüncelle.Location = new System.Drawing.Point(746, 313);
            this.btnOdaGüncelle.Name = "btnOdaGüncelle";
            this.btnOdaGüncelle.Size = new System.Drawing.Size(311, 62);
            this.btnOdaGüncelle.TabIndex = 6;
            this.btnOdaGüncelle.Text = "Oda Bilgisi Güncelle";
            this.btnOdaGüncelle.UseVisualStyleBackColor = true;
            this.btnOdaGüncelle.Click += new System.EventHandler(this.btnOdaGüncelle_Click);
            // 
            // btnOdaEkle
            // 
            this.btnOdaEkle.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdaEkle.Location = new System.Drawing.Point(746, 197);
            this.btnOdaEkle.Name = "btnOdaEkle";
            this.btnOdaEkle.Size = new System.Drawing.Size(311, 62);
            this.btnOdaEkle.TabIndex = 5;
            this.btnOdaEkle.Text = "Oda Bilgisi Ekle";
            this.btnOdaEkle.UseVisualStyleBackColor = true;
            this.btnOdaEkle.Click += new System.EventHandler(this.btnOdaEkle_Click);
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
            this.button1.Location = new System.Drawing.Point(1197, 716);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 53);
            this.button1.TabIndex = 10;
            this.button1.Text = "Menüye Dön";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // oda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOdaListe);
            this.Controls.Add(this.btnOdaSil);
            this.Controls.Add(this.btnOdaGüncelle);
            this.Controls.Add(this.btnOdaEkle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "oda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "oda";
            this.Load += new System.EventHandler(this.oda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOdaListe;
        private System.Windows.Forms.Button btnOdaSil;
        private System.Windows.Forms.Button btnOdaGüncelle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOdaEkle;
        private System.Windows.Forms.Button button1;
    }
}
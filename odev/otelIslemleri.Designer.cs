namespace odev
{
    partial class otelIslemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(otelIslemleri));
            this.btnGelir = new System.Windows.Forms.Button();
            this.btnGider = new System.Windows.Forms.Button();
            this.btnEtkinlik = new System.Windows.Forms.Button();
            this.btnOda = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMenü = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGelir
            // 
            this.btnGelir.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGelir.Location = new System.Drawing.Point(366, 169);
            this.btnGelir.Name = "btnGelir";
            this.btnGelir.Size = new System.Drawing.Size(325, 47);
            this.btnGelir.TabIndex = 0;
            this.btnGelir.Text = "Gelir Islemleri";
            this.btnGelir.UseVisualStyleBackColor = true;
            this.btnGelir.Click += new System.EventHandler(this.btnGelir_Click);
            // 
            // btnGider
            // 
            this.btnGider.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGider.Location = new System.Drawing.Point(366, 277);
            this.btnGider.Name = "btnGider";
            this.btnGider.Size = new System.Drawing.Size(325, 47);
            this.btnGider.TabIndex = 1;
            this.btnGider.Text = "Gider Islemleri";
            this.btnGider.UseVisualStyleBackColor = true;
            this.btnGider.Click += new System.EventHandler(this.btnGider_Click);
            // 
            // btnEtkinlik
            // 
            this.btnEtkinlik.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEtkinlik.Location = new System.Drawing.Point(366, 385);
            this.btnEtkinlik.Name = "btnEtkinlik";
            this.btnEtkinlik.Size = new System.Drawing.Size(325, 47);
            this.btnEtkinlik.TabIndex = 2;
            this.btnEtkinlik.Text = "Etkinlik Islemleri";
            this.btnEtkinlik.UseVisualStyleBackColor = true;
            this.btnEtkinlik.Click += new System.EventHandler(this.btnEtkinlik_Click);
            // 
            // btnOda
            // 
            this.btnOda.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOda.Location = new System.Drawing.Point(366, 493);
            this.btnOda.Name = "btnOda";
            this.btnOda.Size = new System.Drawing.Size(325, 47);
            this.btnOda.TabIndex = 3;
            this.btnOda.Text = "Oda Islemleri";
            this.btnOda.UseVisualStyleBackColor = true;
            this.btnOda.Click += new System.EventHandler(this.btnOda_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(677, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(816, 766);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnMenü
            // 
            this.btnMenü.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenü.Location = new System.Drawing.Point(12, 731);
            this.btnMenü.Name = "btnMenü";
            this.btnMenü.Size = new System.Drawing.Size(203, 47);
            this.btnMenü.TabIndex = 6;
            this.btnMenü.Text = "Menüye Dön";
            this.btnMenü.UseVisualStyleBackColor = true;
            this.btnMenü.Click += new System.EventHandler(this.btnMenü_Click);
            // 
            // otelIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.btnMenü);
            this.Controls.Add(this.btnOda);
            this.Controls.Add(this.btnEtkinlik);
            this.Controls.Add(this.btnGider);
            this.Controls.Add(this.btnGelir);
            this.Controls.Add(this.pictureBox1);
            this.Name = "otelIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "otelIslemleri";
            this.Load += new System.EventHandler(this.otelIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGelir;
        private System.Windows.Forms.Button btnGider;
        private System.Windows.Forms.Button btnEtkinlik;
        private System.Windows.Forms.Button btnOda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMenü;
    }
}
namespace odev
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnHotel = new System.Windows.Forms.Button();
            this.btnRezervasyon = new System.Windows.Forms.Button();
            this.hotelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHotel
            // 
            this.btnHotel.BackColor = System.Drawing.Color.Transparent;
            this.btnHotel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHotel.Font = new System.Drawing.Font("Rage Italic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHotel.Location = new System.Drawing.Point(115, 354);
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(180, 68);
            this.btnHotel.TabIndex = 1;
            this.btnHotel.Text = "Hotel ";
            this.btnHotel.UseVisualStyleBackColor = false;
            this.btnHotel.Click += new System.EventHandler(this.btnHotel_Click);
            // 
            // btnRezervasyon
            // 
            this.btnRezervasyon.BackColor = System.Drawing.Color.Transparent;
            this.btnRezervasyon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRezervasyon.Font = new System.Drawing.Font("Rage Italic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervasyon.ForeColor = System.Drawing.Color.Black;
            this.btnRezervasyon.Location = new System.Drawing.Point(431, 354);
            this.btnRezervasyon.Name = "btnRezervasyon";
            this.btnRezervasyon.Size = new System.Drawing.Size(187, 68);
            this.btnRezervasyon.TabIndex = 2;
            this.btnRezervasyon.Text = "Rezervasyon ";
            this.btnRezervasyon.UseVisualStyleBackColor = false;
            this.btnRezervasyon.Click += new System.EventHandler(this.btnRezervasyon_Click);
            // 
            // hotelName
            // 
            this.hotelName.AutoSize = true;
            this.hotelName.BackColor = System.Drawing.Color.Transparent;
            this.hotelName.Font = new System.Drawing.Font("Rage Italic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelName.Location = new System.Drawing.Point(234, 271);
            this.hotelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hotelName.Name = "hotelName";
            this.hotelName.Size = new System.Drawing.Size(243, 59);
            this.hotelName.TabIndex = 0;
            this.hotelName.Text = "ST. REGIS";
            this.hotelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.btnRezervasyon);
            this.Controls.Add(this.btnHotel);
            this.Controls.Add(this.hotelName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOTEL ST. REGIS | ANA SAYFA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHotel;
        private System.Windows.Forms.Button btnRezervasyon;
        private System.Windows.Forms.Label hotelName;
    }
}


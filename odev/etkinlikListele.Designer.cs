namespace odev
{
    partial class etkinlikListele
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
            this.txtEtkinlikID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewEtkinlik = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEtkinlik)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEtkinlikID
            // 
            this.txtEtkinlikID.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEtkinlikID.Location = new System.Drawing.Point(672, 6);
            this.txtEtkinlikID.Name = "txtEtkinlikID";
            this.txtEtkinlikID.Size = new System.Drawing.Size(232, 36);
            this.txtEtkinlikID.TabIndex = 5;
            this.txtEtkinlikID.TextChanged += new System.EventHandler(this.txtEtkinlikID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(502, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Etkinlik No";
            // 
            // dataGridViewEtkinlik
            // 
            this.dataGridViewEtkinlik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEtkinlik.Location = new System.Drawing.Point(12, 57);
            this.dataGridViewEtkinlik.Name = "dataGridViewEtkinlik";
            this.dataGridViewEtkinlik.RowHeadersWidth = 51;
            this.dataGridViewEtkinlik.RowTemplate.Height = 24;
            this.dataGridViewEtkinlik.Size = new System.Drawing.Size(1481, 661);
            this.dataGridViewEtkinlik.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 738);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Menüye Dön";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // etkinlikListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEtkinlikID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewEtkinlik);
            this.Name = "etkinlikListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "etkinlikListele";
            this.Load += new System.EventHandler(this.etkinlikListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEtkinlik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEtkinlikID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewEtkinlik;
        private System.Windows.Forms.Button button1;
    }
}
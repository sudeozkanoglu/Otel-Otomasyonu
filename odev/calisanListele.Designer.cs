namespace odev
{
    partial class calisanListele
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
            this.dataGridViewCalisan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCalisanNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalisan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCalisan
            // 
            this.dataGridViewCalisan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalisan.Location = new System.Drawing.Point(12, 59);
            this.dataGridViewCalisan.Name = "dataGridViewCalisan";
            this.dataGridViewCalisan.RowHeadersWidth = 51;
            this.dataGridViewCalisan.RowTemplate.Height = 24;
            this.dataGridViewCalisan.Size = new System.Drawing.Size(1481, 661);
            this.dataGridViewCalisan.TabIndex = 0;
            this.dataGridViewCalisan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCalisan_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(531, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Calisan No";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCalisanNo
            // 
            this.txtCalisanNo.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalisanNo.Location = new System.Drawing.Point(672, 8);
            this.txtCalisanNo.Name = "txtCalisanNo";
            this.txtCalisanNo.Size = new System.Drawing.Size(232, 36);
            this.txtCalisanNo.TabIndex = 2;
            this.txtCalisanNo.TextChanged += new System.EventHandler(this.txtCalisanNo_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 739);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "Menüye Dön";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // calisanListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCalisanNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCalisan);
            this.Name = "calisanListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "calisanListele";
            this.Load += new System.EventHandler(this.calisanListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalisan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCalisan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCalisanNo;
        private System.Windows.Forms.Button button1;
    }
}
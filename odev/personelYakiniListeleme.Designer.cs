namespace odev
{
    partial class personelYakiniListeleme
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
            this.txtPersonelYakNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewPersonel = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonel)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPersonelYakNo
            // 
            this.txtPersonelYakNo.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonelYakNo.Location = new System.Drawing.Point(672, 14);
            this.txtPersonelYakNo.Name = "txtPersonelYakNo";
            this.txtPersonelYakNo.Size = new System.Drawing.Size(232, 36);
            this.txtPersonelYakNo.TabIndex = 5;
            this.txtPersonelYakNo.TextChanged += new System.EventHandler(this.txtPersonelYakNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Personel Yakini No";
            // 
            // dataGridViewPersonel
            // 
            this.dataGridViewPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersonel.Location = new System.Drawing.Point(12, 65);
            this.dataGridViewPersonel.Name = "dataGridViewPersonel";
            this.dataGridViewPersonel.RowHeadersWidth = 51;
            this.dataGridViewPersonel.RowTemplate.Height = 24;
            this.dataGridViewPersonel.Size = new System.Drawing.Size(1481, 661);
            this.dataGridViewPersonel.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 747);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(333, 41);
            this.button1.TabIndex = 34;
            this.button1.Text = "Menüye Dön";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // personelYakiniListeleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPersonelYakNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPersonel);
            this.Name = "personelYakiniListeleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "personelYakiniListeleme";
            this.Load += new System.EventHandler(this.personelYakiniListeleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPersonelYakNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewPersonel;
        private System.Windows.Forms.Button button1;
    }
}
namespace odev
{
    partial class gelir
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
            this.dataGridViewGelir = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtGelirNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGelir)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGelir
            // 
            this.dataGridViewGelir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGelir.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewGelir.Name = "dataGridViewGelir";
            this.dataGridViewGelir.RowHeadersWidth = 51;
            this.dataGridViewGelir.RowTemplate.Height = 24;
            this.dataGridViewGelir.Size = new System.Drawing.Size(918, 705);
            this.dataGridViewGelir.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1290, 683);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 49);
            this.button1.TabIndex = 7;
            this.button1.Text = "Menüye Dön";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtGelirNo
            // 
            this.txtGelirNo.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGelirNo.Location = new System.Drawing.Point(1206, 144);
            this.txtGelirNo.Name = "txtGelirNo";
            this.txtGelirNo.Size = new System.Drawing.Size(200, 36);
            this.txtGelirNo.TabIndex = 25;
            this.txtGelirNo.TextChanged += new System.EventHandler(this.txtGelirNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bradley Hand ITC", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1067, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "Gelir No";
            // 
            // gelir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1505, 790);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGelirNo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewGelir);
            this.Name = "gelir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gelir";
            this.Load += new System.EventHandler(this.gelir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGelir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewGelir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtGelirNo;
        private System.Windows.Forms.Label label1;
    }
}
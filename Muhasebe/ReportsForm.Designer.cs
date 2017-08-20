namespace Muhasebe
{
    partial class ReportsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbProducts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.chbSale = new System.Windows.Forms.CheckBox();
            this.chbPurchase = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvReport = new System.Windows.Forms.ListView();
            this.pbProduct = new System.Windows.Forms.PictureBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chbDate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(264, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün Kodu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbProducts
            // 
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Location = new System.Drawing.Point(268, 77);
            this.cbProducts.Margin = new System.Windows.Forms.Padding(4);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(176, 24);
            this.cbProducts.TabIndex = 3;
            this.cbProducts.SelectedIndexChanged += new System.EventHandler(this.cbProducts_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(550, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "Eleman";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(554, 79);
            this.cbEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(160, 24);
            this.cbEmployee.TabIndex = 4;
            // 
            // chbSale
            // 
            this.chbSale.AutoSize = true;
            this.chbSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chbSale.Location = new System.Drawing.Point(814, 115);
            this.chbSale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbSale.Name = "chbSale";
            this.chbSale.Size = new System.Drawing.Size(71, 28);
            this.chbSale.TabIndex = 8;
            this.chbSale.Text = "Satış";
            this.chbSale.UseVisualStyleBackColor = true;
            this.chbSale.Click += new System.EventHandler(this.chbSale_Click);
            // 
            // chbPurchase
            // 
            this.chbPurchase.AutoSize = true;
            this.chbPurchase.Checked = true;
            this.chbPurchase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chbPurchase.Location = new System.Drawing.Point(814, 71);
            this.chbPurchase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbPurchase.Name = "chbPurchase";
            this.chbPurchase.Size = new System.Drawing.Size(62, 28);
            this.chbPurchase.TabIndex = 7;
            this.chbPurchase.Text = "Alış";
            this.chbPurchase.UseVisualStyleBackColor = true;
            this.chbPurchase.Click += new System.EventHandler(this.chbPurchase_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Turquoise;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearch.Location = new System.Drawing.Point(1019, 78);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(167, 69);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Listele";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvReport
            // 
            this.lvReport.Location = new System.Drawing.Point(72, 202);
            this.lvReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvReport.Name = "lvReport";
            this.lvReport.Size = new System.Drawing.Size(1148, 651);
            this.lvReport.TabIndex = 15;
            this.lvReport.UseCompatibleStateImageBehavior = false;
            // 
            // pbProduct
            // 
            this.pbProduct.Location = new System.Drawing.Point(72, 38);
            this.pbProduct.Name = "pbProduct";
            this.pbProduct.Size = new System.Drawing.Size(166, 159);
            this.pbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProduct.TabIndex = 16;
            this.pbProduct.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(438, 158);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(130, 26);
            this.dtpDate.TabIndex = 17;
            // 
            // chbDate
            // 
            this.chbDate.AutoSize = true;
            this.chbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chbDate.Location = new System.Drawing.Point(415, 126);
            this.chbDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbDate.Name = "chbDate";
            this.chbDate.Size = new System.Drawing.Size(189, 28);
            this.chbDate.TabIndex = 18;
            this.chbDate.Text = "Tarihinden İtibaren";
            this.chbDate.UseVisualStyleBackColor = true;
            this.chbDate.CheckStateChanged += new System.EventHandler(this.chbDate_CheckStateChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(567, 856);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 32);
            this.label3.TabIndex = 19;
            this.label3.Text = "Adet Sayısı";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(837, 856);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "Toplam Fiyat";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(567, 899);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(114, 51);
            this.lblAmount.TabIndex = 21;
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(814, 899);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(157, 51);
            this.lblPrice.TabIndex = 22;
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(1086, 889);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 69);
            this.button1.TabIndex = 23;
            this.button1.Text = "Rapor Oluştur";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 981);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.pbProduct);
            this.Controls.Add(this.lvReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.chbSale);
            this.Controls.Add(this.chbPurchase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProducts);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.CheckBox chbSale;
        private System.Windows.Forms.CheckBox chbPurchase;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvReport;
        private System.Windows.Forms.PictureBox pbProduct;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.CheckBox chbDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button button1;
    }
}
namespace Muhasebe
{
    partial class SaleForm
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
            this.chbUSD = new System.Windows.Forms.CheckBox();
            this.chbTL = new System.Windows.Forms.CheckBox();
            this.btnSale = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProducts = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbtCustomerName = new System.Windows.Forms.TextBox();
            this.lblStockAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chbUSD
            // 
            this.chbUSD.AutoSize = true;
            this.chbUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chbUSD.Location = new System.Drawing.Point(491, 227);
            this.chbUSD.Margin = new System.Windows.Forms.Padding(2);
            this.chbUSD.Name = "chbUSD";
            this.chbUSD.Size = new System.Drawing.Size(77, 22);
            this.chbUSD.TabIndex = 6;
            this.chbUSD.Text = "USD($)";
            this.chbUSD.UseVisualStyleBackColor = true;
            this.chbUSD.CheckedChanged += new System.EventHandler(this.chbUSD_Click);
            // 
            // chbTL
            // 
            this.chbTL.AutoSize = true;
            this.chbTL.Checked = true;
            this.chbTL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chbTL.Location = new System.Drawing.Point(491, 191);
            this.chbTL.Margin = new System.Windows.Forms.Padding(2);
            this.chbTL.Name = "chbTL";
            this.chbTL.Size = new System.Drawing.Size(62, 22);
            this.chbTL.TabIndex = 5;
            this.chbTL.Text = "TL(₺)";
            this.chbTL.UseVisualStyleBackColor = true;
            this.chbTL.CheckedChanged += new System.EventHandler(this.chbTL_Click);
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.Color.Lime;
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSale.Location = new System.Drawing.Point(491, 285);
            this.btnSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(238, 56);
            this.btnSale.TabIndex = 8;
            this.btnSale.Text = "Satışı Tamamla";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(316, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 29);
            this.label5.TabIndex = 25;
            this.label5.Text = "Satış Fiyatı";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbtPrice
            // 
            this.tbtPrice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbtPrice.Location = new System.Drawing.Point(319, 191);
            this.tbtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tbtPrice.Multiline = true;
            this.tbtPrice.Name = "tbtPrice";
            this.tbtPrice.Size = new System.Drawing.Size(136, 63);
            this.tbtPrice.TabIndex = 4;
            this.tbtPrice.TextChanged += new System.EventHandler(this.tbtCheckInput);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(99, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "Satılan Ürün Adeti";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbtAmount
            // 
            this.tbtAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbtAmount.Location = new System.Drawing.Point(102, 191);
            this.tbtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.tbtAmount.Multiline = true;
            this.tbtAmount.Name = "tbtAmount";
            this.tbtAmount.Size = new System.Drawing.Size(136, 63);
            this.tbtAmount.TabIndex = 3;
            this.tbtAmount.TextChanged += new System.EventHandler(this.tbtCheckInput);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(287, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ürünün Satış Tarihi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTime
            // 
            this.dtpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(408, 65);
            this.dtpTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(88, 23);
            this.dtpTime.TabIndex = 10;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(287, 65);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(92, 23);
            this.dtpDate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(605, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Satış Elemanı";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(608, 69);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(121, 21);
            this.cbEmployee.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(99, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ürün Kodu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbProducts
            // 
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Location = new System.Drawing.Point(102, 65);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(133, 21);
            this.cbProducts.TabIndex = 1;
            this.cbProducts.SelectedIndexChanged += new System.EventHandler(this.cbProducts_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(590, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 29);
            this.label6.TabIndex = 30;
            this.label6.Text = "Müşteri Adı";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbtCustomerName
            // 
            this.tbtCustomerName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbtCustomerName.Location = new System.Drawing.Point(593, 191);
            this.tbtCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.tbtCustomerName.Multiline = true;
            this.tbtCustomerName.Name = "tbtCustomerName";
            this.tbtCustomerName.Size = new System.Drawing.Size(136, 58);
            this.tbtCustomerName.TabIndex = 7;
            // 
            // lblStockAmount
            // 
            this.lblStockAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStockAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStockAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStockAmount.Location = new System.Drawing.Point(221, 111);
            this.lblStockAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStockAmount.Name = "lblStockAmount";
            this.lblStockAmount.Size = new System.Drawing.Size(79, 32);
            this.lblStockAmount.TabIndex = 33;
            this.lblStockAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(102, 111);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 32);
            this.label8.TabIndex = 34;
            this.label8.Text = "Stokta Kalan Miktar :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 374);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblStockAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbtCustomerName);
            this.Controls.Add(this.chbUSD);
            this.Controls.Add(this.chbTL);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbtPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProducts);
            this.Name = "SaleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaleForm";
            this.Load += new System.EventHandler(this.SaleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbUSD;
        private System.Windows.Forms.CheckBox chbTL;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbtCustomerName;
        private System.Windows.Forms.Label lblStockAmount;
        private System.Windows.Forms.Label label8;
    }
}
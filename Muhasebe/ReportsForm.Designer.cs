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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(118, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün Kodu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbProducts
            // 
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Location = new System.Drawing.Point(121, 80);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(133, 21);
            this.cbProducts.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(332, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Eleman";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(335, 81);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(121, 21);
            this.cbEmployee.TabIndex = 4;
            // 
            // chbSale
            // 
            this.chbSale.AutoSize = true;
            this.chbSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chbSale.Location = new System.Drawing.Point(530, 91);
            this.chbSale.Margin = new System.Windows.Forms.Padding(2);
            this.chbSale.Name = "chbSale";
            this.chbSale.Size = new System.Drawing.Size(60, 22);
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
            this.chbPurchase.Location = new System.Drawing.Point(530, 55);
            this.chbPurchase.Margin = new System.Windows.Forms.Padding(2);
            this.chbPurchase.Name = "chbPurchase";
            this.chbPurchase.Size = new System.Drawing.Size(50, 22);
            this.chbPurchase.TabIndex = 7;
            this.chbPurchase.Text = "Alış";
            this.chbPurchase.UseVisualStyleBackColor = true;
            this.chbPurchase.Click += new System.EventHandler(this.chbPurchase_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Turquoise;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearch.Location = new System.Drawing.Point(684, 61);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 56);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Raporla";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvReport
            // 
            this.lvReport.Location = new System.Drawing.Point(54, 164);
            this.lvReport.Margin = new System.Windows.Forms.Padding(2);
            this.lvReport.Name = "lvReport";
            this.lvReport.Size = new System.Drawing.Size(862, 530);
            this.lvReport.TabIndex = 15;
            this.lvReport.UseCompatibleStateImageBehavior = false;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 783);
            this.Controls.Add(this.lvReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.chbSale);
            this.Controls.Add(this.chbPurchase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProducts);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
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
    }
}
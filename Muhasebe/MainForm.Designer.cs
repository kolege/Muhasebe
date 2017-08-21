namespace Muhasebe
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ürünnlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elemenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elemanEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaleProduct = new System.Windows.Forms.Button();
            this.btnPurchaseProduct = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.lvReport = new System.Windows.Forms.ListView();
            this.tbtProCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünnlerToolStripMenuItem,
            this.elemenaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(824, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ürünnlerToolStripMenuItem
            // 
            this.ürünnlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünEkleToolStripMenuItem});
            this.ürünnlerToolStripMenuItem.Name = "ürünnlerToolStripMenuItem";
            this.ürünnlerToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.ürünnlerToolStripMenuItem.Text = "Ürünler";
            // 
            // ürünEkleToolStripMenuItem
            // 
            this.ürünEkleToolStripMenuItem.Name = "ürünEkleToolStripMenuItem";
            this.ürünEkleToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.ürünEkleToolStripMenuItem.Text = "Ürün Ekle";
            this.ürünEkleToolStripMenuItem.Click += new System.EventHandler(this.ürünEkleToolStripMenuItem_Click);
            // 
            // elemenaToolStripMenuItem
            // 
            this.elemenaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elemanEkleToolStripMenuItem});
            this.elemenaToolStripMenuItem.Name = "elemenaToolStripMenuItem";
            this.elemenaToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.elemenaToolStripMenuItem.Text = "Elemanlar";
            // 
            // elemanEkleToolStripMenuItem
            // 
            this.elemanEkleToolStripMenuItem.Name = "elemanEkleToolStripMenuItem";
            this.elemanEkleToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.elemanEkleToolStripMenuItem.Text = "Eleman Ekle";
            this.elemanEkleToolStripMenuItem.Click += new System.EventHandler(this.elemanEkleToolStripMenuItem_Click);
            // 
            // btnSaleProduct
            // 
            this.btnSaleProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaleProduct.Location = new System.Drawing.Point(65, 340);
            this.btnSaleProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaleProduct.Name = "btnSaleProduct";
            this.btnSaleProduct.Size = new System.Drawing.Size(183, 49);
            this.btnSaleProduct.TabIndex = 4;
            this.btnSaleProduct.Text = "Ürün Çıkışı";
            this.btnSaleProduct.UseVisualStyleBackColor = true;
            this.btnSaleProduct.Click += new System.EventHandler(this.btnSaleProduct_Click);
            // 
            // btnPurchaseProduct
            // 
            this.btnPurchaseProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseProduct.Location = new System.Drawing.Point(65, 256);
            this.btnPurchaseProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPurchaseProduct.Name = "btnPurchaseProduct";
            this.btnPurchaseProduct.Size = new System.Drawing.Size(183, 49);
            this.btnPurchaseProduct.TabIndex = 3;
            this.btnPurchaseProduct.Text = "Ürün Girişi";
            this.btnPurchaseProduct.UseVisualStyleBackColor = true;
            this.btnPurchaseProduct.Click += new System.EventHandler(this.btnPurchaseProduct_Click);
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnReports.Location = new System.Drawing.Point(91, 412);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(129, 49);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Raporlar";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // lvReport
            // 
            this.lvReport.Location = new System.Drawing.Point(324, 32);
            this.lvReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvReport.Name = "lvReport";
            this.lvReport.Size = new System.Drawing.Size(484, 607);
            this.lvReport.TabIndex = 16;
            this.lvReport.UseCompatibleStateImageBehavior = false;
            // 
            // tbtProCode
            // 
            this.tbtProCode.Location = new System.Drawing.Point(65, 95);
            this.tbtProCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbtProCode.Name = "tbtProCode";
            this.tbtProCode.Size = new System.Drawing.Size(181, 22);
            this.tbtProCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(101, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ürün Kodu";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(105, 139);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ara";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(824, 654);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbtProCode);
            this.Controls.Add(this.lvReport);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnPurchaseProduct);
            this.Controls.Add(this.btnSaleProduct);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem elemenaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elemanEkleToolStripMenuItem;
        private System.Windows.Forms.Button btnSaleProduct;
        private System.Windows.Forms.Button btnPurchaseProduct;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.ToolStripMenuItem ürünnlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünEkleToolStripMenuItem;
        private System.Windows.Forms.ListView lvReport;
        private System.Windows.Forms.TextBox tbtProCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}


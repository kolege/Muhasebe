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
            this.elemenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elemanEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elemanBilançosuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genelRaporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aylıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünRaporuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.belirliÜrünRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnSaleProduct = new System.Windows.Forms.Button();
            this.btnPurchaseProduct = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elemenaToolStripMenuItem,
            this.raporToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1393, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // elemenaToolStripMenuItem
            // 
            this.elemenaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elemanEkleToolStripMenuItem,
            this.elemanBilançosuToolStripMenuItem});
            this.elemenaToolStripMenuItem.Name = "elemenaToolStripMenuItem";
            this.elemenaToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.elemenaToolStripMenuItem.Text = "Elemanlar";
            // 
            // elemanEkleToolStripMenuItem
            // 
            this.elemanEkleToolStripMenuItem.Name = "elemanEkleToolStripMenuItem";
            this.elemanEkleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.elemanEkleToolStripMenuItem.Text = "Eleman Ekle";
            this.elemanEkleToolStripMenuItem.Click += new System.EventHandler(this.elemanEkleToolStripMenuItem_Click);
            // 
            // elemanBilançosuToolStripMenuItem
            // 
            this.elemanBilançosuToolStripMenuItem.Name = "elemanBilançosuToolStripMenuItem";
            this.elemanBilançosuToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.elemanBilançosuToolStripMenuItem.Text = "Eleman Bilançosu";
            // 
            // raporToolStripMenuItem
            // 
            this.raporToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.görüntüleToolStripMenuItem,
            this.aylıkToolStripMenuItem});
            this.raporToolStripMenuItem.Name = "raporToolStripMenuItem";
            this.raporToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.raporToolStripMenuItem.Text = "Raporlar";
            // 
            // görüntüleToolStripMenuItem
            // 
            this.görüntüleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genelRaporToolStripMenuItem,
            this.ürünRaporuToolStripMenuItem});
            this.görüntüleToolStripMenuItem.Name = "görüntüleToolStripMenuItem";
            this.görüntüleToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.görüntüleToolStripMenuItem.Text = "Haftalık";
            // 
            // genelRaporToolStripMenuItem
            // 
            this.genelRaporToolStripMenuItem.Name = "genelRaporToolStripMenuItem";
            this.genelRaporToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.genelRaporToolStripMenuItem.Text = "Genel Ürün Raporu";
            // 
            // ürünRaporuToolStripMenuItem
            // 
            this.ürünRaporuToolStripMenuItem.Name = "ürünRaporuToolStripMenuItem";
            this.ürünRaporuToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ürünRaporuToolStripMenuItem.Text = "Belirli Ürün Raporu";
            // 
            // aylıkToolStripMenuItem
            // 
            this.aylıkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ürünRaporuToolStripMenuItem1,
            this.belirliÜrünRaporuToolStripMenuItem});
            this.aylıkToolStripMenuItem.Name = "aylıkToolStripMenuItem";
            this.aylıkToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.aylıkToolStripMenuItem.Text = "Aylık ";
            // 
            // ürünRaporuToolStripMenuItem1
            // 
            this.ürünRaporuToolStripMenuItem1.Name = "ürünRaporuToolStripMenuItem1";
            this.ürünRaporuToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.ürünRaporuToolStripMenuItem1.Text = "Genel Ürün Raporu";
            // 
            // belirliÜrünRaporuToolStripMenuItem
            // 
            this.belirliÜrünRaporuToolStripMenuItem.Name = "belirliÜrünRaporuToolStripMenuItem";
            this.belirliÜrünRaporuToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.belirliÜrünRaporuToolStripMenuItem.Text = "Belirli Ürün Raporu";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddProduct.Location = new System.Drawing.Point(467, 162);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(97, 40);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "Ürün Ekle";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnSaleProduct
            // 
            this.btnSaleProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaleProduct.Location = new System.Drawing.Point(447, 362);
            this.btnSaleProduct.Name = "btnSaleProduct";
            this.btnSaleProduct.Size = new System.Drawing.Size(137, 40);
            this.btnSaleProduct.TabIndex = 2;
            this.btnSaleProduct.Text = "Ürün Çıkışı";
            this.btnSaleProduct.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseProduct
            // 
            this.btnPurchaseProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseProduct.Location = new System.Drawing.Point(447, 273);
            this.btnPurchaseProduct.Name = "btnPurchaseProduct";
            this.btnPurchaseProduct.Size = new System.Drawing.Size(137, 40);
            this.btnPurchaseProduct.TabIndex = 3;
            this.btnPurchaseProduct.Text = "Ürün Girişi";
            this.btnPurchaseProduct.UseVisualStyleBackColor = true;
            this.btnPurchaseProduct.Click += new System.EventHandler(this.btnPurchaseProduct_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1393, 634);
            this.Controls.Add(this.btnPurchaseProduct);
            this.Controls.Add(this.btnSaleProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolStripMenuItem elemanBilançosuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genelRaporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünRaporuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aylıkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünRaporuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem belirliÜrünRaporuToolStripMenuItem;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnSaleProduct;
        private System.Windows.Forms.Button btnPurchaseProduct;
    }
}


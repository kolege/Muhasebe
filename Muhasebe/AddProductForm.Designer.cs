namespace Muhasebe
{
    partial class AddProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductForm));
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbtProductCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbtProductDetail = new System.Windows.Forms.TextBox();
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.cpbSend = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSend)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProductImage
            // 
            this.pbProductImage.Image = ((System.Drawing.Image)(resources.GetObject("pbProductImage.Image")));
            this.pbProductImage.Location = new System.Drawing.Point(89, 96);
            this.pbProductImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(203, 229);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.TabIndex = 0;
            this.pbProductImage.TabStop = false;
            this.pbProductImage.Click += new System.EventHandler(this.pbProductImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(351, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ürün Kodu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbtProductCode
            // 
            this.tbtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbtProductCode.Location = new System.Drawing.Point(345, 181);
            this.tbtProductCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbtProductCode.Name = "tbtProductCode";
            this.tbtProductCode.Size = new System.Drawing.Size(132, 30);
            this.tbtProductCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(572, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ürün Açıklaması";
            // 
            // tbtProductDetail
            // 
            this.tbtProductDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbtProductDetail.Location = new System.Drawing.Point(577, 181);
            this.tbtProductDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbtProductDetail.Multiline = true;
            this.tbtProductDetail.Name = "tbtProductDetail";
            this.tbtProductDetail.Size = new System.Drawing.Size(179, 106);
            this.tbtProductDetail.TabIndex = 2;
            // 
            // btnProductAdd
            // 
            this.btnProductAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnProductAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProductAdd.Location = new System.Drawing.Point(323, 338);
            this.btnProductAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(435, 68);
            this.btnProductAdd.TabIndex = 3;
            this.btnProductAdd.Text = "Ürünü Ekle";
            this.btnProductAdd.UseVisualStyleBackColor = false;
            this.btnProductAdd.Click += new System.EventHandler(this.btnProductAdd_Click);
            // 
            // cpbSend
            // 
            this.cpbSend.Image = ((System.Drawing.Image)(resources.GetObject("cpbSend.Image")));
            this.cpbSend.Location = new System.Drawing.Point(486, 336);
            this.cpbSend.Name = "cpbSend";
            this.cpbSend.Size = new System.Drawing.Size(109, 70);
            this.cpbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cpbSend.TabIndex = 5;
            this.cpbSend.TabStop = false;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 437);
            this.Controls.Add(this.cpbSend);
            this.Controls.Add(this.btnProductAdd);
            this.Controls.Add(this.tbtProductDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbtProductCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbProductImage);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbtProductCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbtProductDetail;
        private System.Windows.Forms.Button btnProductAdd;
        private System.Windows.Forms.PictureBox cpbSend;
    }
}
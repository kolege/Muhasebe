using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class AddProductForm : Form
    {
        SQLiteConnection connection=MainForm.connection;
        bool boolImageSelected = false;

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbtProductCode.Text) && !string.IsNullOrWhiteSpace(tbtProductDetail.Text) && boolImageSelected)
            {
                String proCode = tbtProductCode.Text;
                String proDetail = tbtProductDetail.Text;
                byte[] proImage = imageToByteArray(pbProductImage.Image);
                connection.Open();
                try {
                    SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_product(proCode,description,image,adet) values"
                        + "(@proCode,@description,@image,@adet)", connection);
                    query.Parameters.AddWithValue("@proCode", proCode);
                    query.Parameters.AddWithValue("@description", proDetail);
                    query.Parameters.AddWithValue("@image", proImage);
                    query.Parameters.AddWithValue("@adet", 0);
                    query.ExecuteNonQuery();
                    query.Dispose();
                    connection.Close();
                    this.Close();
                }
                catch(SQLiteException ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Bu kod numarasına sahip ürününüz mevcuttur.\n Lütfen benzersiz bi ürün kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen ürün bilgilerini ve resmini girdiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public byte[] imageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void pbProductImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {   // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    pbProductImage.Image = new Bitmap(dlg.FileName);
                    boolImageSelected = true;
                }
            }
        }
    }
}

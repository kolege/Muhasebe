using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class AddProductForm : Form
    {
        SQLiteConnection connection=MainForm.connection;
        string proCode, proDetail;
        byte[] proImage;
        bool boolImageSelected = false;

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbtProductCode.Text) && !string.IsNullOrWhiteSpace(tbtProductDetail.Text) && boolImageSelected)
            {
                Utils.show();
                this.Hide();
                if (addProductToServer())
                    addProductToLocalDb();
                else {
                    Utils.hide();
                    this.Show();
                    MessageBox.Show("İnternet bağlantınızı kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen ürün bilgilerini ve resmini girdiğinizden emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool addProductToServer()
        {
            proCode = tbtProductCode.Text;
            proDetail = tbtProductDetail.Text;
            proImage = imageToByteArray(pbProductImage.Image);
            string result = Convert.ToBase64String(proImage);
            var request = (HttpWebRequest)WebRequest.Create("http://www.stokcontrol.com/addProduct.php");

            var postData = "signup_submit=signup_submit";
            postData += "&proCode=" + proCode;
            postData += "&description=" + proDetail;
            postData += "&image=" + result;
            postData += "&adet=0";
            var data = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                request.UserAgent = "Kolege";
                request.Accept = "success";
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                JObject json = JsonConvert.DeserializeObject<JObject>(responseString);
                if ((int)json["response"]["success"] == 1)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Girmiş olduğunuz bilgiler hatalıdır.\n Ürün kodunuzun benzersiz olduğundan emin olunuz.");
                    return false;
                }
            }
            catch (WebException error)
            {
                Console.WriteLine(error.ToString());
                return false;
            }
        }

        private void addProductToLocalDb()
        {
            String proCode = tbtProductCode.Text;
            String proDetail = tbtProductDetail.Text;
            connection.Open();
            try
            {
                SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_product(proCode,description,image,adet) values"
                    + "(@proCode,@description,@image,@adet)", connection);
                query.Parameters.AddWithValue("@proCode", proCode);
                query.Parameters.AddWithValue("@description", proDetail);
                string result = Convert.ToBase64String(proImage);
                query.Parameters.AddWithValue("@image", result);
                query.Parameters.AddWithValue("@adet", 0);
                query.ExecuteNonQuery();
                query.Dispose();
                connection.Close();
                Utils.hide();
                this.Close();
            }
            catch (SQLiteException ex)
            {
                connection.Close();
                Console.WriteLine(ex.ToString());
                this.Show();
                Utils.hide();
                MessageBox.Show("Verileri eklerken hata oluştu. Lütfen serverla bağlantınızı yenileyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

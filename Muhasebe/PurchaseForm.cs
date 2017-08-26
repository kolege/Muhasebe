using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class PurchaseForm : Form
    {
        SQLiteConnection connection = MainForm.connection;
        int paymentType;
        List<int> listEmployees=new List<int>();
        int purchaseId;       

        public PurchaseForm()
        {
            InitializeComponent();
            paymentType = Utils.paymentTypeTL;
            chbTL.Checked = true;
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            fillCbEmployee();
            fillCbProducts();
        }

        private void fillCbProducts()
        {
            connection.Open();
            SQLiteCommand query = new SQLiteCommand("Select proCode From mhsb_product", connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                cbProducts.Items.Add(reader["proCode"].ToString());
            }
            connection.Close();
            cbProducts.DropDownStyle = ComboBoxStyle.DropDown;
            cbProducts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProducts.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void fillCbEmployee()
        {
            connection.Open();
            SQLiteCommand query = new SQLiteCommand("Select * From mhsb_employee", connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                listEmployees.Add(int.Parse(reader["id"].ToString()));
                cbEmployee.Items.Add(reader["name"].ToString()+" "+reader["surName"].ToString());
            }
            connection.Close();
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDown;
            cbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public long getDate()
        {
            DateTime date = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
            return (long)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        private void tbtCheckInput(object sender, EventArgs e)
        {
            TextBox tbt=(TextBox)sender;
            if (tbt.Text.Contains("\n"))
            {
                tbt.Text = tbt.Text.Remove(tbt.Text.Length - 2);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(tbt.Text, "[^-0-9]"))
            {
                MessageBox.Show("Lütfen Sadece Sayı Giriniz!");
                tbt.Text = tbt.Text.Remove(tbt.Text.Length - 1);
            }
        }

        private void chbUSD_Click(object sender, EventArgs e)
        {
            chbUSD.Checked = true;
            chbTL.Checked = false;
            paymentType = Utils.paymentTypeUSD;
        }

        private void chbTL_Click(object sender, EventArgs e)
        {
            chbTL.Checked = true;
            chbUSD.Checked = false;
            paymentType = Utils.paymentTypeTL;
        }

        public void addPurchaseToLocalDb()
        {
            connection.Open();
            try
            {
                SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_purchase(id,proCode,amount,date,sellerId,price,type) values"
                    + "(@id,@proCode,@amount,@date,@sellerId,@price,@type)", connection);
                query.Parameters.AddWithValue("@id", purchaseId);
                query.Parameters.AddWithValue("@proCode", cbProducts.SelectedItem);
                query.Parameters.AddWithValue("@amount", tbtAmount.Text);
                query.Parameters.AddWithValue("@date", getDate());
                query.Parameters.AddWithValue("@sellerId", listEmployees[cbEmployee.SelectedIndex]);
                query.Parameters.AddWithValue("@price", tbtPrice.Text);
                query.Parameters.AddWithValue("@type", paymentType);
                query.ExecuteNonQuery();
                query.Dispose();
                SQLiteCommand queryIncrease = new SQLiteCommand("UPDATE mhsb_product SET adet = adet + " + tbtAmount.Text 
                    + " WHERE proCode='" + cbProducts.SelectedItem + "'", connection);
                queryIncrease.ExecuteNonQuery();
                query.Dispose();
                connection.Close();
            }
            catch (SQLiteException ex)
            {
                connection.Close();
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Veritabanına eklerken bir hata oluştu.\n Lütfen server bağlanıtınız yenileyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Utils.hide();
            this.Close();
        }

        public bool addPurchaseToServer()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.stokcontrol.com/addPurchase.php");

            var postData = "signup_submit=signup_submit";
            postData += "&proCode=" + cbProducts.SelectedItem;
            postData += "&date=" + getDate();
            postData += "&sellerId=" + listEmployees[cbEmployee.SelectedIndex];
            postData += "&amount=" + tbtAmount.Text;
            postData += "&price=" + tbtPrice.Text;
            postData += "&type=" + paymentType;
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
                    purchaseId = (int)json["response"]["id"];
                    return true;
                }
                else
                {
                    MessageBox.Show("Girmiş olduğunuz bilgiler hatalıdır.");
                    return false;
                }
            }
            catch (WebException error)
            {
                Console.WriteLine(error.ToString());
                return false;
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbtAmount.Text) && !string.IsNullOrWhiteSpace(tbtPrice.Text)
                && cbProducts.SelectedItem != null && cbEmployee.SelectedItem != null)
            {
                Utils.show();
                this.Hide();
                if (addPurchaseToServer())
                {
                    addPurchaseToLocalDb();
                }
                else
                {
                    Utils.hide();
                    this.Show();
                    MessageBox.Show("İnternet Bağlantınız olduğundan emin olunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm verileri doldurduğunuzdan emin olunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

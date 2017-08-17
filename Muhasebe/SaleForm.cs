using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhasebe
{
    public partial class SaleForm : Form
    {
        SQLiteConnection connection = MainForm.connection;
        int paymentType;
        List<int> listEmployees = new List<int>();
        List<int> listStocks = new List<int>();

        public SaleForm()
        {
            InitializeComponent();
            paymentType = Utils.paymentTypeTL;
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStockAmount.Text = listStocks[cbProducts.SelectedIndex] + "";
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            fillCbEmployee();
            fillCbProducts();
        }

        private void fillCbProducts()
        {
            connection.Open();
            SQLiteCommand query = new SQLiteCommand("Select proCode, adet From mhsb_product", connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                cbProducts.Items.Add(reader["proCode"].ToString());
                listStocks.Add(int.Parse(reader["adet"].ToString()));
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
                cbEmployee.Items.Add(reader["name"].ToString() + " " + reader["surName"].ToString());
            }
            connection.Close();
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDown;
            cbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
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

        private void tbtCheckInput(object sender, EventArgs e)
        {
            TextBox tbt = (TextBox)sender;
            if (tbt.Text.Contains("\n"))
            {
                tbt.Text = tbt.Text.Remove(tbt.Text.Length - 2);
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(tbt.Text, "[^-0-9]"))
            {
                MessageBox.Show("Lütfen Sadece Sayı Giriniz!");
                tbt.Text = tbt.Text.Remove(tbt.Text.Length - 1);
            }
            try { 
                if (tbt == tbtAmount && int.Parse(tbtAmount.Text)>int.Parse(lblStockAmount.Text))
                {
                    MessageBox.Show("Stoklarımızdaki üründen fazlasını satamazsınız.");
                    lblStockAmount.Text = "";
                }
            }catch(Exception error)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public long getDate()
        {
            DateTime date = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
            return (long)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbtAmount.Text) && !string.IsNullOrWhiteSpace(tbtPrice.Text)
                && !string.IsNullOrWhiteSpace(tbtCustomerName.Text)
                && cbProducts.SelectedItem != null && cbEmployee.SelectedItem != null)
            {
                connection.Open();
                try
                {
                    SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_sale(id,proCode,date,sellerId,buyer,amount,price,type) values"
                        + "(NULL,@proCode,@date,@sellerId,@buyer,@amount,@price,@type)", connection);
                    query.Parameters.AddWithValue("@proCode", cbProducts.SelectedItem);
                    query.Parameters.AddWithValue("@date", getDate());
                    query.Parameters.AddWithValue("@sellerId", listEmployees[cbEmployee.SelectedIndex]);
                    query.Parameters.AddWithValue("@buyer", tbtCustomerName);
                    query.Parameters.AddWithValue("@amount", tbtAmount.Text);
                    query.Parameters.AddWithValue("@price", tbtPrice.Text);
                    query.Parameters.AddWithValue("@type", paymentType);
                    query.ExecuteNonQuery();
                    query.Dispose();
                    SQLiteCommand queryIncrease = new SQLiteCommand("UPDATE mhsb_product SET adet = adet - " + tbtAmount.Text + " WHERE proCode='" + cbProducts.SelectedItem + "'", connection);
                    queryIncrease.ExecuteNonQuery();
                    query.Dispose();
                    connection.Close();
                    this.Close();
                }
                catch (SQLiteException ex)
                {
                    connection.Close();
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Veritabanına eklerken bir hata oluştu.\n", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm verileri doldurduğunuzdan emin olunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

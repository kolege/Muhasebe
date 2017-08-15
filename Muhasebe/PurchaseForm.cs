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
    public partial class PurchaseForm : Form
    {
        SQLiteConnection connection = MainForm.connection;
        int paymentType;
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

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbtAmount.Text) && !string.IsNullOrWhiteSpace(tbtPrice.Text)
                && cbProducts.SelectedItem!=null && cbEmployee.SelectedItem != null)
            {
                connection.Open();
                try
                {
                    SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_purchase(id,proCode,amount,date,sellerId,price,type) values"
                        + "(NULL,@proCode,@amount,@date,@sellerId,@price,@type)", connection);
                    query.Parameters.AddWithValue("@proCode", cbProducts.SelectedText);
                    query.Parameters.AddWithValue("@amount", tbtAmount.Text);
                    query.Parameters.AddWithValue("@date", getDate());
                    query.Parameters.AddWithValue("@sellerId", cbEmployee.SelectedText);
                    query.Parameters.AddWithValue("@price", tbtPrice.Text);
                    query.Parameters.AddWithValue("@type", paymentType);
                    query.ExecuteNonQuery();
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
    }
}

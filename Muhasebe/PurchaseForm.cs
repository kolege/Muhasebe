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
        public PurchaseForm()
        {
            InitializeComponent();
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


    }
}

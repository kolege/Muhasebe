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

    }
}

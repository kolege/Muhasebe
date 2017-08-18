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
    public partial class ReportsForm : Form
    {

        SQLiteConnection connection;
        List<int> listEmployees = new List<int>();

        public ReportsForm()
        {
            InitializeComponent();
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
                cbEmployee.Items.Add(reader["name"].ToString() + " " + reader["surName"].ToString());
            }
            connection.Close();
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDown;
            cbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void fillList()
        {
            //listPayments.Clear();
            lvReport.Clear();
            lvReport.View = View.Details;
            lvReport.FullRowSelect = true;
            lvReport.Columns.Add("Ürün Kodu", 80, HorizontalAlignment.Left);
            lvReport.Columns.Add("Tarih", 80, HorizontalAlignment.Left);
            lvReport.Columns.Add("Satış Elemanı", 80, HorizontalAlignment.Left);
            lvReport.Columns.Add("Miktar", 80, HorizontalAlignment.Left);
            lvReport.Columns.Add("Fiyat", 80, HorizontalAlignment.Left);
            lvReport.Columns.Add("Birim", 80, HorizontalAlignment.Left);
            lvReport.Columns.Add("Müşteri", 80, HorizontalAlignment.Left);
        }
    }
}

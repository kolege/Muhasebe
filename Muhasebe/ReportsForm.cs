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

        SQLiteConnection connection = MainForm.connection;
        List<int> listEmployees = new List<int>();
        List<ProductModel> listProducts = new List<ProductModel>();
        List<DealModel> listDeals;
        long totalPriceTL=0, totalPriceUSD=0, totalAmountUSD=0, totalAmountTL=0;

        public ReportsForm()
        {
            InitializeComponent();
            listDeals = new List<DealModel>();
            dtpDate.Visible = false;
        }

        private void fillCbProducts()
        {
            listProducts.Clear();
            cbProducts.Items.Clear();
            connection.Open();
            SQLiteCommand query = new SQLiteCommand("Select * From mhsb_product", connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                ProductModel product = new ProductModel(reader["proCode"].ToString());
                product.amount=long.Parse(reader["adet"].ToString());
                product.image = (Bitmap)((new ImageConverter()).ConvertFrom(reader["image"]));
                product.description = reader["description"].ToString();
                cbProducts.Items.Add(product.proCode);
                listProducts.Add(product);
            }
            connection.Close();
            cbProducts.DropDownStyle = ComboBoxStyle.DropDown;
            cbProducts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProducts.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void fillCbEmployee()
        {
            listEmployees.Clear();
            cbEmployee.Items.Clear();
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
            totalPriceUSD = 0;
            totalPriceTL = 0;
            totalAmountTL = 0;
            totalAmountUSD = 0;
            lvReport.Clear();
            lvReport.View = View.Details;
            lvReport.FullRowSelect = true;
            lvReport.Columns.Add("Ürün Kodu", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Tarih", 180, HorizontalAlignment.Left);
            lvReport.Columns.Add("Miktar", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Fiyat", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Birim", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Satış Elemanı", 140, HorizontalAlignment.Left);
            if (chbSale.Checked)
                lvReport.Columns.Add("Müşteri", 140, HorizontalAlignment.Left);
            for(int i=0; i < listDeals.Count; i++)
            {
                DealModel deal = listDeals[i];
                string[] itemArrayLv = new string[7];
                ListViewItem lviPayments;
                itemArrayLv[0] = deal.proCode;
                itemArrayLv[1] = UnixTimeStampToDateTime(deal.date).ToString();
                itemArrayLv[2] = deal.amount.ToString();
                itemArrayLv[3] = deal.price + "";
                if (deal.type == Utils.paymentTypeTL)
                {
                    itemArrayLv[4] = "TL";
                    totalPriceTL += long.Parse(deal.price + "");
                    totalAmountTL += deal.amount;
                }
                else
                {
                    itemArrayLv[4] = "USD";
                    totalPriceUSD += long.Parse(deal.price + "");
                    totalAmountUSD += deal.amount;
                }
                itemArrayLv[5] = deal.sellerID + "";
                if (chbSale.Checked)
                    itemArrayLv[6] = deal.customer;
                lviPayments = new ListViewItem(itemArrayLv);
                lvReport.Items.Insert(lviPayments.IndentCount, lviPayments);
                lblAmount.Text = totalAmountTL + " TL/" + totalAmountUSD + " USD";
                lblPrice.Text = totalPriceTL + " TL/" + totalPriceUSD + " USD";
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getDeals();
            fillList();
        }

        public void getDeals()
        {
            Console.WriteLine(cbProducts.SelectedIndex + "/" + cbProducts.SelectedItem+"/"+cbProducts.SelectedValue);
            Console.WriteLine(cbEmployee.SelectedIndex + "/" + cbEmployee.SelectedItem + "/" + cbEmployee.SelectedValue);
            listDeals.Clear();
            connection.Open();
            String queryString;
            if (chbPurchase.Checked)
                queryString = "Select * From mhsb_purchase ";
            else
                queryString = "Select * From mhsb_sale";
            if (cbProducts.SelectedIndex != -1 || cbEmployee.SelectedIndex != -1 || chbDate.Checked)
                queryString += " WHERE ";
            if (cbProducts.SelectedIndex != -1)
                queryString += "proCode = '" + cbProducts.SelectedItem + "'";
            if (cbProducts.SelectedIndex != -1 && (cbEmployee.SelectedIndex != -1 || chbDate.Checked))
                queryString += " and ";
            if (cbEmployee.SelectedIndex != -1)
                queryString += "sellerId = '" + listEmployees[cbEmployee.SelectedIndex] + "'";
            if ((cbProducts.SelectedIndex != -1 || cbEmployee.SelectedIndex != -1) && chbDate.Checked)
                queryString += " and ";
            if (chbDate.Checked)
            {
                queryString+=" date >= "+ getDate();
            }
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                DealModel deal = new DealModel(int.Parse(reader["id"].ToString()));
                deal.proCode = reader["proCode"].ToString();
                Console.WriteLine("Code : "+reader["proCode"].ToString());
                deal.date = long.Parse(reader["date"].ToString());
                deal.amount = long.Parse(reader["amount"].ToString());
                deal.price = float.Parse(reader["price"].ToString());
                deal.type = int.Parse(reader["type"].ToString());
                deal.sellerID = int.Parse(reader["sellerId"].ToString());
                if (chbSale.Checked)
                {
                    deal.customer = reader["buyer"].ToString();
                }
                listDeals.Add(deal);
            }
            reader.Close();
            query.Dispose();
            connection.Close();
            Console.WriteLine(listDeals.Count.ToString());
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            fillCbEmployee();
            fillCbProducts();
        }

        private void chbPurchase_Click(object sender, EventArgs e)
        {
            chbPurchase.Checked = true;
            chbSale.Checked = false;
        }

        private void chbSale_Click(object sender, EventArgs e)
        {
            chbSale.Checked = true;
            chbPurchase.Checked = false;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.AddHours(-3);
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProducts.SelectedIndex != -1)
            {
                pbProduct.Image = listProducts[cbProducts.SelectedIndex].image;
            }
        }

        private void chbDate_CheckStateChanged(object sender, EventArgs e)
        {
            if (dtpDate.Visible==true)
                dtpDate.Visible = false;
            else
                dtpDate.Visible = true;
        }

        public long getDate()
        {
            DateTime date = dtpDate.Value.Date;
            return (long)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}

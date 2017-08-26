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
    public partial class MainForm : Form
    {
        public static SQLiteConnection connection;
        List<ProductModel> listProducts=new List<ProductModel>();
        public MainForm()
        {
            InitializeComponent();
            if (!File.Exists("MHSB_Database.sqlite"))
            {
                SQLiteConnection.CreateFile("MHSB_Database.sqlite");
                connection = new SQLiteConnection("Data Source=MHSB_Database.sqlite;Version=3;");
                createDbTables();
            }
            else
            {
                connection = new SQLiteConnection("Data Source=MHSB_Database.sqlite;Version=3;");
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

        public void createDbTables()
        {
            connection.Open();
            SQLiteCommand CREATE_PRODUCT_TABLE = new SQLiteCommand("CREATE TABLE mhsb_product(proCode TEXT NOT NULL PRIMARY KEY, description TEXT, image TEXT, adet TEXT)", connection);
            CREATE_PRODUCT_TABLE.ExecuteNonQuery();
            CREATE_PRODUCT_TABLE.Dispose();

            SQLiteCommand CREATE_SALE_TABLE = new SQLiteCommand("CREATE TABLE mhsb_sale(id INTEGER NOT NULL PRIMARY KEY, proCode TEXT, date LONG, sellerId INTEGER, buyer TEXT, amount TEXT, price TEXT, type INTEGER)", connection);
            CREATE_SALE_TABLE.ExecuteNonQuery();
            CREATE_SALE_TABLE.Dispose();

            SQLiteCommand CREATE_PURCHASE_TABLE = new SQLiteCommand("CREATE TABLE mhsb_purchase(id INTEGER NOT NULL PRIMARY KEY, proCode TEXT, amount TEXT, date LONG, sellerId INTEGER, price TEXT, type INTEGER)", connection);
            CREATE_PURCHASE_TABLE.ExecuteNonQuery();
            CREATE_PURCHASE_TABLE.Dispose();

            SQLiteCommand CREATE_EMPLOYEE_TABLE = new SQLiteCommand("CREATE TABLE mhsb_employee(id INTEGER NOT NULL PRIMARY KEY, name TEXT, surName TEXT)", connection);
            CREATE_EMPLOYEE_TABLE.ExecuteNonQuery();
            CREATE_EMPLOYEE_TABLE.Dispose();
            connection.Close();
        }

        private void fillDb()
        {
            JObject data = getJsonFromUrl("http://www.stokcontrol.com/getAllData.php");
            if (data != null)
            {
                clearDbTables();
                //Console.WriteLine(data.ToString());
                connection.Open();
                data = (JObject)data["response"];
                if ((int)data["success"] == 1)
                {
                    JArray jsonArrayDatas = (JArray)data["products"];
                    for (var i = 0; i < jsonArrayDatas.Count; i++)
                    {
                        JObject productObject = (JObject)jsonArrayDatas[i];
                        SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_product (proCode,description,image,adet) values (@proCode,@description,@image,@adet)", connection);
                        query.Parameters.AddWithValue("@proCode", productObject["proCode"]);
                        query.Parameters.AddWithValue("@description", productObject["description"]);
                        string image = productObject["image"].ToString().Replace(' ', '+');
                        query.Parameters.AddWithValue("@image", image);
                        query.Parameters.AddWithValue("@adet", productObject["adet"]);
                        query.ExecuteNonQuery();
                    }
                    jsonArrayDatas = (JArray)data["employees"];
                    for (var i = 0; i < jsonArrayDatas.Count; i++)
                    {
                        JObject employeeObject = (JObject)jsonArrayDatas[i];
                        SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_employee (id, name, surname) values (@id, @name, @surname)", connection);
                        query.Parameters.AddWithValue("@id", employeeObject["id"]);
                        query.Parameters.AddWithValue("@name", employeeObject["name"]);
                        query.Parameters.AddWithValue("@surname", employeeObject["surname"]);
                        query.ExecuteNonQuery();
                    }
                    jsonArrayDatas = (JArray)data["purchases"];
                    for (var i = 0; i < jsonArrayDatas.Count; i++)
                    {
                        JObject purchaseObject = (JObject)jsonArrayDatas[i];
                        SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_purchase (id, proCode, amount, date, sellerId, price, type) " +
                            "values (@id, @proCode, @amount, @date, @sellerId, @price, @type)", connection);
                        query.Parameters.AddWithValue("@id", purchaseObject["id"]);
                        query.Parameters.AddWithValue("@proCode", purchaseObject["proCode"]);
                        query.Parameters.AddWithValue("@amount", purchaseObject["amount"]);
                        query.Parameters.AddWithValue("@date", purchaseObject["date"]);
                        query.Parameters.AddWithValue("@sellerId", purchaseObject["sellerId"]);
                        query.Parameters.AddWithValue("@price", purchaseObject["price"]);
                        query.Parameters.AddWithValue("@type", purchaseObject["type"]);
                        query.ExecuteNonQuery();
                    }
                    jsonArrayDatas = (JArray)data["sales"];
                    for (var i = 0; i < jsonArrayDatas.Count; i++)
                    {
                        JObject categoryDetailObject = (JObject)jsonArrayDatas[i];
                        SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_sale (id, proCode, date, sellerId, buyer, amount, price, type)" +
                            " values (@id,@proCode,@date,@sellerId,@buyer,@amount,@price,@type)", connection);
                        query.Parameters.AddWithValue("@id", categoryDetailObject["id"]);
                        query.Parameters.AddWithValue("@proCode", categoryDetailObject["proCode"]);
                        query.Parameters.AddWithValue("@date", categoryDetailObject["date"]);
                        query.Parameters.AddWithValue("@sellerId", categoryDetailObject["sellerId"]);
                        query.Parameters.AddWithValue("@buyer", categoryDetailObject["customer"]);
                        query.Parameters.AddWithValue("@amount", categoryDetailObject["amount"]);
                        query.Parameters.AddWithValue("@price", categoryDetailObject["price"]);
                        query.Parameters.AddWithValue("@type", categoryDetailObject["type"]);
                        query.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }

        private void clearDbTables()
        {
            connection.Open();
            SQLiteCommand query;
            query = new SQLiteCommand("DELETE FROM mhsb_product", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM mhsb_employee", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM mhsb_purchase", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM mhsb_sale", connection);
            query.ExecuteNonQuery();
            query.Dispose();
            connection.Close();
        }

        internal static JObject getJsonFromUrl(string Url)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);

            var postData = "s=" + "Mhsb";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //Console.WriteLine(responseString);
                JObject json = JsonConvert.DeserializeObject<JObject>(responseString);

                return json;
            }catch(WebException error)
            {
                MessageBox.Show("Lütfen Internet Bağlantınızı Kontrol ediniz.\n Eğer internet bağlantınızda sorun yok ise, serverla iletişime geçiniz.");
                Console.WriteLine(error.ToString());
                return null;
            }
        }

        private void btnPurchaseProduct_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
        }

        private void elemanEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployee = new AddEmployeeForm();
            addEmployee.Show();
        }

        private void btnSaleProduct_Click(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm();
            saleForm.Show();
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }

        public void fillList()
        {
            lvReport.Clear();
            lvReport.View = View.Details;
            lvReport.FullRowSelect = true;
            lvReport.Columns.Add("Ürün Kodu", 100, HorizontalAlignment.Left);
            lvReport.Columns.Add("Açıklama", 340, HorizontalAlignment.Left);
            lvReport.Columns.Add("Miktar", 70, HorizontalAlignment.Left);
            for (int i = 0; i < listProducts.Count; i++)
            {
                ProductModel pro = listProducts[i];
                string[] itemArrayLv = new string[3];
                ListViewItem lviPayments;
                itemArrayLv[0] = pro.proCode;
                itemArrayLv[1] = pro.description;
                itemArrayLv[2] = pro.amount+"";
                lviPayments = new ListViewItem(itemArrayLv);
                lvReport.Items.Insert(lviPayments.IndentCount, lviPayments);
            }

        }

        public void getProducts()
        {
            listProducts.Clear();
            connection.Open();
            String queryString;
            queryString = "Select * From mhsb_product ";
            
            if (!string.IsNullOrWhiteSpace(tbtProCode.Text))
                queryString += " WHERE proCode LIKE '"+tbtProCode.Text+"%'";

            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.ExecuteNonQuery();
            SQLiteDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                ProductModel product = new ProductModel(reader["proCode"].ToString());
                product.description = reader["description"].ToString();
                product.amount = long.Parse(reader["adet"].ToString());
                //product.image = (Bitmap)((new ImageConverter()).ConvertFrom(reader["image"]));
                listProducts.Add(product);
            }
            reader.Close();
            query.Dispose();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm_Activated(null, null);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            getProducts();
            fillList();
        }

        private void btnSyncToServer_Click(object sender, EventArgs e)
        {
            Utils.show();
            this.Hide();
            fillDb();
            MainForm_Activated(null, null);
            Utils.hide();
            this.Show();
        }
    }
}

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
        internal static SQLiteConnection connection;
        public MainForm()
        {
            InitializeComponent();
            if (!File.Exists("KURS_Database.sqlite"))
            {
                SQLiteConnection.CreateFile("KURS_Database.sqlite");
                connection = new SQLiteConnection("Data Source=KURS_Database.sqlite;Version=3;");
                createDbTables();
            }
            else
            {
                connection = new SQLiteConnection("Data Source=KURS_Database.sqlite;Version=3;");
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
            SQLiteCommand CREATE_PRODUCT_TABLE = new SQLiteCommand("CREATE TABLE mhsb_product(proCode INTEGER UNIQUE, description TEXT, image BLOB)", connection);
            CREATE_PRODUCT_TABLE.ExecuteNonQuery();
            CREATE_PRODUCT_TABLE.Dispose();

            SQLiteCommand CREATE_SALE_TABLE = new SQLiteCommand("CREATE TABLE mhsb_sale(id INTEGER UNIQUE, proCode INTEGER, date DATETIME, sellerId INTEGER, price FLOAT, type INTEGER)", connection);
            CREATE_SALE_TABLE.ExecuteNonQuery();
            CREATE_SALE_TABLE.Dispose();

            SQLiteCommand CREATE_PURCHASE_TABLE = new SQLiteCommand("CREATE TABLE mhsb_urchase(id INTEGER UNIQUE, proCode INTEGER, date DATETIME, sellerId INTEGER)", connection);
            CREATE_PURCHASE_TABLE.ExecuteNonQuery();
            CREATE_PURCHASE_TABLE.Dispose();

            SQLiteCommand CREATE_EMPLOYEE_TABLE = new SQLiteCommand("CREATE TABLE mhsb_product(id INTEGER UNIQUE, name TEXT, surName TEXT)", connection);
            CREATE_EMPLOYEE_TABLE.ExecuteNonQuery();
            CREATE_EMPLOYEE_TABLE.Dispose();
            connection.Close();
        }

        private void fillDb()
        {
            JObject data = getJsonFromUrl("http://www.smartmenuexpress.com/mobile/sme/reload_menu.html");
            clearDbTables();
            //Console.WriteLine(jsonArrayWaiters.ToString());
            connection.Open();
            JArray jsonArrayDatas = (JArray)data["sme_menu"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject categoryObject = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_product (proCode, description, image) values (@proCode,@description,@image)", connection);
                query.Parameters.AddWithValue("@ID", categoryObject["procode"]);
                query.Parameters.AddWithValue("@Name", categoryObject["description"]);
                query.Parameters.AddWithValue("@UserID", categoryObject["image"]);
                query.ExecuteNonQuery();
            }
            jsonArrayDatas = (JArray)data["sme_menu_detail"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject categoryDetailObject = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO sme_menu_detail (ID, MasterID, language, Name, Description) values (@ID,@MasterID,@language, @Name, @Description)", connection);
                query.Parameters.AddWithValue("@ID", categoryDetailObject["ID"]);
                query.Parameters.AddWithValue("@MasterID", categoryDetailObject["MasterID"]);
                query.Parameters.AddWithValue("@language", categoryDetailObject["language"]);
                query.Parameters.AddWithValue("@Name", categoryDetailObject["Name"]);
                query.Parameters.AddWithValue("@Description", categoryDetailObject["Description"]);
                query.ExecuteNonQuery();
            }
            jsonArrayDatas = (JArray)data["sme_menu_properties"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject categoryDetailObject = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO sme_menu_properties (ID, cID) values (@ID,@cID)", connection);
                query.Parameters.AddWithValue("@ID", categoryDetailObject["ID"]);
                query.Parameters.AddWithValue("@cID", categoryDetailObject["cID"]);
                query.ExecuteNonQuery();
            }
            jsonArrayDatas = (JArray)data["sme_menu_properties_detail"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject categoryDetailObject = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO sme_menu_properties_detail (ID, MasterID, language, Name, Description) values (@ID,@MasterID,@language, @Name, @Description)", connection);
                query.Parameters.AddWithValue("@ID", categoryDetailObject["ID"]);
                query.Parameters.AddWithValue("@MasterID", categoryDetailObject["MasterID"]);
                query.Parameters.AddWithValue("@language", categoryDetailObject["language"]);
                query.Parameters.AddWithValue("@Name", categoryDetailObject["Name"]);
                query.Parameters.AddWithValue("@Description", categoryDetailObject["Description"]);
                query.ExecuteNonQuery();
            }
            jsonArrayDatas = (JArray)data["sme_menu_detail_properties"];
            jsonArrayDatas = (JArray)data["sme_products"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject productObject = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO sme_products (ID, MenuID, Calories, PreparationTime, Price, PriceCurrency, Photo, UserID)" +
                                          "values (@ID,@MenuID,@Calories, @PreparationTime, @Price, @PriceCurrency, @Photo, @UserID)", connection);
                query.Parameters.AddWithValue("@ID", productObject["ID"]);
                query.Parameters.AddWithValue("@MenuID", productObject["MenuID"]);
                query.Parameters.AddWithValue("@Calories", productObject["Calories"]);
                query.Parameters.AddWithValue("@PreparationTime", productObject["PreparationTime"]);
                query.Parameters.AddWithValue("@Price", productObject["Price"]);
                query.Parameters.AddWithValue("@PriceCurrency", productObject["PriceCurrency"]);
                query.Parameters.AddWithValue("@Photo", productObject["Photo"]);
                query.Parameters.AddWithValue("@UserID", productObject["UserID"]);
                query.ExecuteNonQuery();
            }
            jsonArrayDatas = (JArray)data["sme_products_detail"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject productDetail = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO sme_products_detail (ID, MasterID, language, Name, Description) values (@ID,@MasterID,@language, @Name, @Description)", connection);
                query.Parameters.AddWithValue("@ID", productDetail["ID"]);
                query.Parameters.AddWithValue("@MasterID", productDetail["MasterID"]);
                query.Parameters.AddWithValue("@language", productDetail["language"]);
                query.Parameters.AddWithValue("@Name", productDetail["Name"]);
                query.Parameters.AddWithValue("@Description", productDetail["Description"]);
                query.ExecuteNonQuery();
            }
            jsonArrayDatas = (JArray)data["sme_waiters"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject waiter = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO sme_waiters (ID, Name, Pin, UserID) values (@ID,@Name,@Pin, @UserID)", connection);
                query.Parameters.AddWithValue("@ID", waiter["ID"]);
                query.Parameters.AddWithValue("@Name", waiter["Name"]);
                query.Parameters.AddWithValue("@Pin", waiter["Pin"]);
                query.Parameters.AddWithValue("@UserID", waiter["UserID"]);
                query.ExecuteNonQuery();
            }
            jsonArrayDatas = (JArray)data["sme_tables"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject table = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO sme_tables (ID, Name, Description, UserID, PositionX, PositionY, Width, Height)" +
                    " values (@ID,@Name,@Description, @UserID, @PositionX, @PositionY, @Width, @Height)", connection);
                query.Parameters.AddWithValue("@ID", table["ID"]);
                query.Parameters.AddWithValue("@Name", table["Name"]);
                query.Parameters.AddWithValue("@Description", table["Description"]);
                query.Parameters.AddWithValue("@UserID", table["UserID"]);
                query.Parameters.AddWithValue("@PositionX", table["PositionX"]);//
                query.Parameters.AddWithValue("@PositionY", table["PositionY"]);// 
                query.Parameters.AddWithValue("@Width", table["Width"]);//
                query.Parameters.AddWithValue("@Height", table["Height"]);//

                query.ExecuteNonQuery();
            }
            jsonArrayDatas = (JArray)data["sme_images"];
            for (var i = 0; i < jsonArrayDatas.Count; i++)
            {
                JObject image = (JObject)jsonArrayDatas[i];
                SQLiteCommand query = new SQLiteCommand("INSERT INTO sme_images (ID, Logo, Splash, Background, UserID) values (@ID, @Logo, @Splash, @Background, @UserID)", connection);
                query.Parameters.AddWithValue("@ID", image["ID"]);
                query.Parameters.AddWithValue("@Logo", image["Logo"]);
                query.Parameters.AddWithValue("@Splash", image["Splash"]);
                query.Parameters.AddWithValue("@Background", image["Background"]);
                query.Parameters.AddWithValue("@UserID", image["UserID"]);
                query.ExecuteNonQuery();
            }
            connection.Close();
        }

        private void clearDbTables()
        {
            connection.Open();
            SQLiteCommand query;
            query = new SQLiteCommand("DELETE FROM sme_waiters", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_images", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_menu", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_menu_detail", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_products", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_products_detail", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_waiters", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_tables", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_menu_properties", connection);
            query.ExecuteNonQuery();
            query = new SQLiteCommand("DELETE FROM sme_menu_properties_detail", connection);
            query.ExecuteNonQuery();
            //query = new SQLiteCommand("DELETE FROM sme_calls", connection);
            //query.ExecuteNonQuery();
            //query = new SQLiteCommand("DELETE FROM sme_adresses", connection);
            //query.ExecuteNonQuery();
            //query = new SQLiteCommand("DELETE FROM sme_orders", connection);
            //query.ExecuteNonQuery();
            //query = new SQLiteCommand("DELETE FROM sme_orders_detail", connection);
            //query.ExecuteNonQuery();
            connection.Close();
        }

        internal static JObject getJsonFromUrl(string Url)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);

            var postData = "s=" + "key";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(responseString);
            JObject json = JsonConvert.DeserializeObject<JObject>(responseString);

            return json;
        }
    }
}

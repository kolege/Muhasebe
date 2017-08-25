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
    public partial class AddEmployeeForm : Form
    {
        SQLiteConnection connection;
        int employeeID;
        LoadingForm loadingForm = new LoadingForm();


        public AddEmployeeForm()
        {
            InitializeComponent();
            connection = MainForm.connection;
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbtName.Text) && !string.IsNullOrWhiteSpace(tbtSurname.Text))
            {
                this.Hide();
                loadingForm.Show();
                if(addEmloyeeToServer(tbtName.Text.ToString(), tbtSurname.Text.ToString()))
                {
                    addEmployeeToLocalDb();
                }
                else
                {
                    this.Show();
                    loadingForm.Close();
                    MessageBox.Show("İnternet Bağlantınız olduğundan emin olunuz.");
                }
            }


        }

        public bool addEmloyeeToServer(string name, string surname)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.stokcontrol.com/addEmployee.php");

            var postData = "signup_submit=signup_submit";
            postData += "&name=" + name;
            postData += "&surname=" + surname;
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
                    employeeID = (int)json["response"]["id"];
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

        public void addEmployeeToLocalDb()
        {
            try
            {
                connection.Open();
                SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_employee(id,name,surName) values(@id,@name,@surName)", connection);
                query.Parameters.AddWithValue("@id", employeeID);
                query.Parameters.AddWithValue("@name", tbtName.Text.ToString());
                query.Parameters.AddWithValue("@surName", tbtSurname.Text.ToString());
                query.ExecuteNonQuery();
                query.Dispose();
                connection.Close();
                loadingForm.Close();
                this.Close();
            }
            catch (SQLiteException error)
            {
                connection.Close();
                Console.WriteLine(error.ToString());
                loadingForm.Close();
                MessageBox.Show("Verileri eklerken hata oluştu. Lütfen serverla bağlantınızı yenileyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}

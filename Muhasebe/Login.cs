using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SQLite;

namespace Muhasebe
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            lblError.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String mail=tctEmail.Text;
            String pw = tctPassword.Text;
            var request = (HttpWebRequest)WebRequest.Create("http://www.smartmenuexpress.com/mobile/sme/login.html");

            var postData = "login_submit=login_submit";
            postData += "&username="+mail;
            postData += "&password=" + pw;
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

            JObject json = JsonConvert.DeserializeObject<JObject>(responseString);
            if ((int)json["response"]["success"]==1)
            {
                MainForm form2 = new MainForm();
                form2.Show();
                this.Hide();
            }
            else
            {
                lblError.Show();
                lblError.Text = json["response"]["message"].ToString();
            }
        }
       
    }


}

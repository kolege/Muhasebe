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
    public partial class AddEmployeeForm : Form
    {
        SQLiteConnection connection;
        public AddEmployeeForm()
        {
            InitializeComponent();
            connection = MainForm.connection;
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbtName.Text) && !string.IsNullOrWhiteSpace(tbtSurname.Text))
            {
                try { 
                    connection.Open();
                    SQLiteCommand query = new SQLiteCommand("INSERT INTO mhsb_employee(id,name,surName) values(NULL,@name,@surName)", connection);
                    query.Parameters.AddWithValue("@name", tbtName.Text.ToString());
                    query.Parameters.AddWithValue("@surName", tbtSurname.Text.ToString());
                    query.ExecuteNonQuery();
                    query.Dispose();
                    connection.Close();
                    this.Close();
                }catch(SQLiteException error)
                {
                    connection.Close();
                    Console.WriteLine(error.ToString());
                    MessageBox.Show("Verileri eklerken hata oluştu. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }
    }
}

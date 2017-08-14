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
    public partial class AddProductForm : Form
    {
        SQLiteConnection connection=MainForm.connection;

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            String proCode = tbtProductCode.Text;
            String proDetail = tbtProductDetail.Text;
            
        }
    }
}

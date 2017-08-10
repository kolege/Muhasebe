using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public void createDbTables()
        {

        }
    }
}

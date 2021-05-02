using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAbdelMoumen
{
    public partial class Eleves : Form
    {
        public Eleves()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source = localhost\SQLZXPRESS; Inetial Catalog = Abdelmoumen; Integrated Security = true";
        private void Eleves_Load(object sender, EventArgs e)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            {

            }
        }
    }
}

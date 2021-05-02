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
    public partial class Authentification : Form
    {
        public Authentification()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = Abdelmoumen; Integrated Security = True";
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = true;
        }

        private void ch_view_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_view.Checked)
            {
                txt_Password.UseSystemPasswordChar = false;
            }else
                txt_Password.UseSystemPasswordChar = true;
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_Connexion_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select MotDePasse from Administrateur where Mail = @Mail";
                SqlParameter par = new SqlParameter("@Mail", SqlDbType.VarChar, 30);
                par.Value = txt_Mail.Text;
                command.Parameters.Add(par);
                
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Menu frm = new Menu();
                        frm.Show();
                        this.Hide();
                    } else
                        lb_Message.Text = "Mail ou le mot de passe incorrect !!";
                }catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
}

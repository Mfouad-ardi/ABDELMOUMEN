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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = Abdelmoumen; Integrated Security = True";
        private int Id;
        private void Remplire()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * from Administrateur";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Id = int.Parse(reader[0].ToString());
                        lb_Nom.Text = reader["Nom"].ToString();
                        lb_Prenom.Text = reader["Prenom"].ToString();
                        lb_Mail.Text = reader["Mail"].ToString();
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Profile_Load(object sender, EventArgs e)
        {
            txt_Npassw.UseSystemPasswordChar = true;
            txt_Rpassw.UseSystemPasswordChar = true;
            Remplire();
        }

        private void bt_Modifier_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update Administrateur Set Nom = @Nom, Prenom = @Prenom, Mail = @Mail where IdAdmi = @Id";
                SqlParameter par = new SqlParameter("@Nom", SqlDbType.VarChar, 30);
                par.Value = txt_Nom.Text;
                command.Parameters.Add(par);
                par = new SqlParameter("@Prenom", SqlDbType.VarChar, 30);
                par.Value = txt_Prenom.Text;
                command.Parameters.Add(par);
                par = new SqlParameter("@Mail", SqlDbType.VarChar, 30);
                par.Value = txt_Nom.Text + "." + txt_Prenom.Text + "@Abdelmoumen.com";
                command.Parameters.Add(par);
                par = new SqlParameter("@Id", SqlDbType.Int);
                par.Value = Id;
                command.Parameters.Add(par);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Bien Modifier  !!");
                    txt_Nom.Clear();
                    txt_Prenom.Clear();
                    Remplire();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bt_Changer_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update Administrateur Set MotDePasse = @Passw where IdAdmi = @Id";
                SqlParameter par = new SqlParameter("@Passw", SqlDbType.VarChar, 30);
                par.Value = txt_Npassw.Text;
                command.Parameters.Add(par);
                par = new SqlParameter("@Id", SqlDbType.Int);
                par.Value = Id;
                command.Parameters.Add(par);
                try
                {
                    connection.Open();
                    if (txt_Npassw.Text == txt_Rpassw.Text)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Bien Changer  !!");
                        txt_Npassw.Clear();
                        txt_Rpassw.Clear();
                    }
                    else
                        lb_Message.Text = "Le Mot de passe ne sont pas la même !!";
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txt_Nom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

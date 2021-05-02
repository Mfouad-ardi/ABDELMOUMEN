using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAbdelMoumen
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            panel_SubMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panel_SubMenu.Visible == true)
                panel_SubMenu.Visible = false;
        }
        private Form activeForm = null;
        private void openForm(Form ChildForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            Panel_Content.Controls.Add(ChildForm);
            Panel_Content.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        private void bt_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_SiteWeb_Click(object sender, EventArgs e)
        {
            if (panel_SubMenu.Visible == false)
                panel_SubMenu.Visible = true;
            else
                panel_SubMenu.Visible = false;
        }

        private void bt_Profile_Click(object sender, EventArgs e)
        {
            Profile form = new Profile();
            openForm(form);

            hideSubMenu();
            lb_head.Text = "Profile";
        }

        private void bt_Eleves_Click(object sender, EventArgs e)
        {
            Eleves form = new Eleves();
            openForm(form);

            hideSubMenu();
            lb_head.Text = "Elèves";
        }

        private void bt_Filiere_Click(object sender, EventArgs e)
        {
            Filieres form = new Filieres();
            openForm(form);
            hideSubMenu();
            lb_head.Text = "Filiéres";
        }

        private void bt_Matiere_Click(object sender, EventArgs e)
        {
            Matieres form = new Matieres();
            openForm(form);
            hideSubMenu();
            lb_head.Text = "Matiéres";
        }

        private void bt_Enseignant_Click(object sender, EventArgs e)
        {
            Enseignanats form = new Enseignanats();
            openForm(form);
            hideSubMenu();
            lb_head.Text = "Enseignants";
        }

        private void bt_Classes_Click(object sender, EventArgs e)
        {
            Classes form = new Classes();
            openForm(form);
            hideSubMenu();
            lb_head.Text = "Classes";
        }

        private void bt_Certificats_Click(object sender, EventArgs e)
        {
            Certificats form = new Certificats();
            openForm(form);
            hideSubMenu();
            lb_head.Text = "Certificats";
        }

        private void bt_Insat_Click(object sender, EventArgs e)
        {
            INSAT form = new INSAT();
            openForm(form);
            hideSubMenu();
            lb_head.Text = "INSAT";
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
        }
    }
}

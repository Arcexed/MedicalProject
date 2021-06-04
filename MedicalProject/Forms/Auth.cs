using MedicalProject.DB;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalProject
{
    public partial class Auth : MetroForm
    {
        public Auth()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                ConnectionDB.GenerateCFG(UsernameTextBox.Text,PasswordTextBox.Text);
                string login = UsernameTextBox.Text;
                ConnectionDB.conn.Open();
                FormLists.auth.Hide();
                FormLists.Panel.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            FormLists.auth = this;
            UsernameTextBox.Text = "admin";
            PasswordTextBox.Text = "admin";
            button1_Click(new object(), new EventArgs());

        }
    }
}

using MedicalProject.DB;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
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
    public partial class AdminPanel : MetroForm
    {
        public AdminPanel()
        {
            InitializeComponent();
        }


        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = ConnectionDB.userName;
        }

        private void ChangeUserButton_Click_1(object sender, EventArgs e)
        {
            ConnectionDB.conn.Close();
            this.Hide();
            FormLists.auth.Show();
        }

        private void refresh_preparation_tile_Click(object sender, EventArgs e)
        {
            preparation_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT Preparation_name,Form_name,Brand_name,Price FROM preparation_view", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                preparation_show_infogrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
            }
            reader.Close(); // закрываем reader
        }

        private void refresh_disease_tile_Click(object sender, EventArgs e)
        {
            disease_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT ID_disease,Disease_name,Disease_descr FROM disease", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                disease_show_infogrid.Rows.Add(reader[0], reader[1], reader[2]);
            }
            reader.Close(); // закрываем reader
        }

        private void refresh_producer_tile_Click(object sender, EventArgs e)
        {
            producer_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT ID_producer,Brand_name,Phone_producer,Address FROM producer", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                producer_show_infogrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
            }
            reader.Close(); // закрываем reader
        }

        private void refresh_license_tile_Click(object sender, EventArgs e)
        {
            license_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT Brand_name,Register,License_date FROM license_view", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                license_show_infogrid.Rows.Add(reader[0], reader[1], reader[2]);
            }
            reader.Close(); // закрываем reader
        }

        private void refresh_recipe_tile_Click(object sender, EventArgs e)
        {

            recipe_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT id_recipe,Substance_name1,Substance_name2,Substance_name3 FROM Recipe_view", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                recipe_show_infogrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
            }
            reader.Close(); // закрываем reader
        }

        private void refresh_medicine_tile_Click(object sender, EventArgs e)
        {
            // TODO
            medicine_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT Brand_Name,preparation_name FROM Medicine_view", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            { 
                medicine_show_infogrid.Rows.Add(reader[0], reader[1]);
            }
            reader.Close(); // закрываем reader
        }

        private void refresh_compability_tile_Click(object sender, EventArgs e)
        {
            compability_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT Disease_name,Preparation_name FROM compatibility_view", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                compability_show_infogrid.Rows.Add(reader[0], reader[1]);
            }
            reader.Close(); // закрываем reader
        }

        private void refresh_medicalform_tile_Click(object sender, EventArgs e)
        {
            medicalform_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT id_form,Form_name FROM medical_form", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                medicalform_show_infogrid.Rows.Add(reader[0], reader[1]);
            }
            reader.Close(); // закрываем reader
        }
    }
}

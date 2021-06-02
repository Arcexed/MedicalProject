﻿using MedicalProject.DB;
using MetroFramework;
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
            MySqlCommand command = new MySqlCommand("SELECT id_recipe,Substance_name1,Substance_name2,Substance_name3,Quantity FROM Recipe_view", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                recipe_show_infogrid.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
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

        private void activesubstance_add_button_Click(object sender, EventArgs e)
        {
            if (activesubstance_add_textbox.Text != "")
            {
                try
                {

                    MySqlCommand command = new MySqlCommand($"CALL add_active_substance(\"{activesubstance_add_textbox.Text}\")", ConnectionDB.conn);
                    command.ExecuteNonQuery();
                    MetroMessageBox.Show(this, $"Added record {activesubstance_add_textbox.Text}", "Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    activesubstance_add_textbox.Text = "";
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void refresh_activesubstance_tile_Click(object sender, EventArgs e)
        {
            activesubstance_show_infogrid.Rows.Clear();
            MySqlCommand command = new MySqlCommand("SELECT ID_substance, Substance_name FROM active_substance", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                activesubstance_show_infogrid.Rows.Add(reader[0], reader[1]);
            }
            reader.Close(); // закрываем reader
        }

        private void activesubstance_find_button_Click(object sender, EventArgs e)
        {
            if (activesubstance_find_textbox.Text != "")
            {
                activesubstance_find_infogrid.Rows.Clear();
                MySqlCommand command = new MySqlCommand($"SELECT ID_substance, Substance_name FROM active_substance WHERE Substance_name LIKE '%{activesubstance_find_textbox.Text}%'", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    activesubstance_find_infogrid.Rows.Add(reader[0], reader[1]);
                }
                activesubstance_find_textbox.Text = "";
                reader.Close(); // закрываем reader
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void medicalform_find_button_Click(object sender, EventArgs e)
        {
            //TODO
            if (medicalform_find_textbox.Text != "")
            {
                medicalform_find_infogrid.Rows.Clear();
                MySqlCommand command = new MySqlCommand($"SELECT ID_form, Form_name FROM medical_form WHERE Form_name LIKE '%{medicalform_find_textbox.Text}%'", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    medicalform_find_infogrid.Rows.Add(reader[0], reader[1]);
                }
                medicalform_find_textbox.Text = "";
                reader.Close(); // закрываем reader
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void medicalform_add_button_Click(object sender, EventArgs e)
        {
            if (medicalform_add_textbox.Text != "")
            {
                try
                {

                    MySqlCommand command = new MySqlCommand($"CALL add_medical_form(\"{medicalform_add_textbox.Text}\")", ConnectionDB.conn);
                    command.ExecuteNonQuery();
                    MetroMessageBox.Show(this, $"Added record {medicalform_add_textbox.Text}", "Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    medicalform_add_textbox.Text = "";
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        void CompabilityCheck()
        {
            try
            {
                compability_add_disease_combobox.Items.Clear();
                compability_add_preparation_combobox.Items.Clear();
                MySqlCommand command_disease = new MySqlCommand($"SELECT Disease_name,id_disease FROM disease", ConnectionDB.conn);
                MySqlDataReader reader_disease = command_disease.ExecuteReader();

                while (reader_disease.Read())
                {
                    compability_add_disease_combobox.Items.Add(reader_disease[0]);
                }
                reader_disease.Close();
                MySqlCommand command_preparation = new MySqlCommand($"SELECT ID_preparation,Preparation_name FROM preparation", ConnectionDB.conn);
                MySqlDataReader reader_preparation = command_preparation.ExecuteReader();

                while (reader_preparation.Read())
                {
                    compability_add_preparation_combobox.Items.Add(reader_preparation[0]);
                }
                reader_preparation.Close();
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }
        private void compaility_tabcontrol_Click(object sender, EventArgs e)
        {
            CompabilityCheck();
        }


        private void compability_add_preparation_combobox_Click(object sender, EventArgs e)
        {
            CompabilityCheck();
        }

        private void compability_add_disease_combobox_Click(object sender, EventArgs e)
        {
            CompabilityCheck();
        }

        private void compability_add_button_Click(object sender, EventArgs e)
        {
            //TODO
            try
            {
                if (compability_add_disease_combobox.SelectedItem.ToString() != "" && compability_add_preparation_combobox.SelectedItem.ToString() != "")
                {
                    MySqlCommand command_disease = new MySqlCommand($"SELECT id_disease FROM disease WHERE disease_name='{compability_add_disease_combobox.SelectedItem}'", ConnectionDB.conn);
                    string id_disease = command_disease.ExecuteScalar().ToString();
                    MySqlCommand command_preparation = new MySqlCommand($"SELECT id_preparation FROM preparation WHERE preparation_name='{compability_add_preparation_combobox.SelectedItem}'", ConnectionDB.conn);
                    string id_preparation = command_preparation.ExecuteScalar().ToString();
                    MySqlCommand add_compability = new MySqlCommand($"INSERT INTO compability (id_disease,id_preparation) VALUES ('{id_disease}','{id_preparation}')", ConnectionDB.conn);
                    add_compability.ExecuteNonQuery();
                    MetroMessageBox.Show(this, $"Successfully added record", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MetroMessageBox.Show(this, $"Fields must be not null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }

        }

        private void compability_find_button_Click(object sender, EventArgs e)
        {
            try
            {
                compability_find_infogrid.Rows.Clear();
                string name = compability_find_textbox.Text;
                MySqlCommand command = new MySqlCommand($"SELECT Disease_name,Preparation_name FROM compatibility_view WHERE Disease_name LIKE '%{name}%' OR Preparation_name LIKE '%{name}%'", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    compability_find_infogrid.Rows.Add(reader[0],reader[1]);
                }
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void medicine_find_button_Click(object sender, EventArgs e)
        {
            try
            {
                medicine_find_infogrid.Rows.Clear();
                string name = compability_find_textbox.Text;
                MySqlCommand command = new MySqlCommand($"SELECT Brand_Name,Preparation_name FROM medicine_view WHERE Brand_Name LIKE '%{name}%' OR Preparation_name LIKE '%{name}%'", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    medicine_find_infogrid.Rows.Add(reader[0], reader[1]);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        void MedicineCheck()
        {
            medicine_add_producername_combobox.Items.Clear();
            medicine_add_preparation_combobox.Items.Clear();
            MySqlCommand command_producer = new MySqlCommand("Select Brand_name FROM producer", ConnectionDB.conn);
            MySqlDataReader reader_producer = command_producer.ExecuteReader();
            while (reader_producer.Read())
            {
                medicine_add_producername_combobox.Items.Add(reader_producer[0]);
            }
            reader_producer.Close();
            MySqlCommand command_preparation = new MySqlCommand("Select Preparation_name FROM Preparation", ConnectionDB.conn);
            MySqlDataReader reader_preparation = command_preparation.ExecuteReader();
            while (reader_preparation.Read())
            {
                medicine_add_preparation_combobox.Items.Add(reader_preparation[0]);
            }
            reader_preparation.Close();
        }
        private void medicine_add_tabpage_Click(object sender, EventArgs e)
        {
            MedicineCheck();
        }
        private void medicine_add_producername_combobox_Click(object sender, EventArgs e)
        {
            MedicineCheck();
        }
        private void medicine_add_preparation_combobox_Click(object sender, EventArgs e)
        {
            MedicineCheck();
        }

        private void medicine_add_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (medicine_add_producername_combobox.SelectedItem.ToString() != "" && medicine_add_preparation_combobox.SelectedItem.ToString() != "")
                {
                    MySqlCommand command_producer = new MySqlCommand($"SELECT id_producer FROM producer WHERE Brand_name='{compability_add_disease_combobox.SelectedItem}'", ConnectionDB.conn);
                    string id_producer = command_producer.ExecuteScalar().ToString();
                    MySqlCommand command_preparation = new MySqlCommand($"SELECT id_preparation FROM preparation WHERE preparation_name='{compability_add_preparation_combobox.SelectedItem}'", ConnectionDB.conn);
                    string id_preparation = command_preparation.ExecuteScalar().ToString();
                    MySqlCommand add_compability = new MySqlCommand($"INSERT INTO medicine (ID_producer,id_preparation) VALUES ('{id_producer}','{id_preparation}')", ConnectionDB.conn);
                    add_compability.ExecuteNonQuery();
                    MetroMessageBox.Show(this, $"Successfully added record", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MetroMessageBox.Show(this, $"Fields must be not null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }

        }

        private void recipe_add_button_Click(object sender, EventArgs e)
        {

            string name_substance1 = recipe_add_substance1_name_combobox.SelectedItem.ToString();
            string name_substance2 = recipe_add_substance2_name_combobox.SelectedItem.ToString();
            string name_substance3 = recipe_add_substance3_name_combobox.SelectedItem.ToString();
            int quantity = 0;
            try
            {
                quantity = int.Parse(recipe_add_quantity_textbox.Text);
            }
            catch
            {
                MetroMessageBox.Show(this, $"Error in parse Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            if (name_substance1 != name_substance2 && name_substance2 != name_substance3 &&name_substance1!=name_substance3 && quantity>0)
            {
                MySqlCommand command_id1 = new MySqlCommand($"SELECT id_substance FROM active_substance WHERE Substance_name='{name_substance1}'", ConnectionDB.conn);
                string id_substance1 = command_id1.ExecuteScalar().ToString();
                MySqlCommand command_id2 = new MySqlCommand($"SELECT id_substance FROM active_substance WHERE Substance_name='{name_substance2}'", ConnectionDB.conn);
                string id_substance2 = command_id2.ExecuteScalar().ToString();
                MySqlCommand command_id3 = new MySqlCommand($"SELECT id_substance FROM active_substance WHERE Substance_name='{name_substance3}'", ConnectionDB.conn);
                string id_substance3 = command_id3.ExecuteScalar().ToString();
                MySqlCommand command = new MySqlCommand($"CALL add_recipe({id_substance1},{id_substance2},{id_substance3},{quantity})", ConnectionDB.conn);
                command.ExecuteNonQuery();
                recipe_add_quantity_textbox.Text = "";
            }
            else
            {
                MetroMessageBox.Show(this, $"Somewhere the names of substances coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void recipe_tabpage_Click(object sender, EventArgs e)
        {
            GetActiveSubstance();
        }

        private void GetActiveSubstance()
        {
            recipe_add_substance1_name_combobox.Items.Clear();
            recipe_add_substance2_name_combobox.Items.Clear();
            recipe_add_substance3_name_combobox.Items.Clear();
            MySqlCommand command = new MySqlCommand("SELECT Substance_name FROM active_substance", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                recipe_add_substance1_name_combobox.Items.Add(reader[0]);
                recipe_add_substance2_name_combobox.Items.Add(reader[0]);
                recipe_add_substance3_name_combobox.Items.Add(reader[0]);
            }
            reader.Close();
        }
        private void recipe_add_substance1_name_combobox_Click(object sender, EventArgs e)
        {
            GetActiveSubstance();
        }
        private void recipe_add_substance2_name_combobox_Click(object sender, EventArgs e)
        {
            GetActiveSubstance();
        }
        private void recipe_add_substance3_name_combobox_Click(object sender, EventArgs e)
        {
            GetActiveSubstance();
        }

        private void recipe_find_button_Click(object sender, EventArgs e)
        {
            string substance_name = recipe_find_textbox.Text;
            MySqlCommand command = new MySqlCommand("SELECT sub", ConnectionDB.conn);
        }
    }
}

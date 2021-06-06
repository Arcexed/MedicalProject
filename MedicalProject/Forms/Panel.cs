using MedicalProject.DB;
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
using Microsoft.Reporting;
namespace MedicalProject
{
    public partial class Panel : MetroForm
    {
        public Panel()
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
            if (ConnectionDB.userName == "admin")
            {
                {
                    if (!preparation_tabcontrol.TabPages.Contains(preparation_add_tabpage))
                    {
                        preparation_tabcontrol.TabPages.Add(preparation_add_tabpage);
                    }
                    if (!preparation_tabcontrol.TabPages.Contains(preparation_delete_tabpage))
                    {
                        preparation_tabcontrol.TabPages.Add(preparation_delete_tabpage);
                    }
                }
                {
                    if (!disease_tabcontrol.TabPages.Contains(disease_add_tabpage))
                    {
                        disease_tabcontrol.TabPages.Add(disease_add_tabpage);
                    }
                    if (!disease_tabcontrol.TabPages.Contains(disease_delete_tabpage))
                    {
                        disease_tabcontrol.TabPages.Add(disease_delete_tabpage);
                    }
                }
                {
                    if (!producer_tabcontrol.TabPages.Contains(producer_add_tabpage))
                    {
                        producer_tabcontrol.TabPages.Add(producer_add_tabpage);
                    }
                    if (!producer_tabcontrol.TabPages.Contains(producer_delete_tabpage))
                    {
                        producer_tabcontrol.TabPages.Add(producer_delete_tabpage);
                    }
                }
                {
                    if (!license_tabcontrol.TabPages.Contains(license_add_tabpage))
                    {
                        license_tabcontrol.TabPages.Add(license_add_tabpage);
                    }
                    if (!license_tabcontrol.TabPages.Contains(license_delete_tabpage))
                    {
                        license_tabcontrol.TabPages.Add(license_delete_tabpage);
                    }
                }
                {
                    if (!recipe_tabcontrol.TabPages.Contains(recipe_add_tabpage))
                    {
                        recipe_tabcontrol.TabPages.Add(recipe_add_tabpage);
                    }
                    if (!recipe_tabcontrol.TabPages.Contains(recipe_delete_tabpage))
                    {
                        recipe_tabcontrol.TabPages.Add(recipe_delete_tabpage);
                    }
                }
                {
                    if (!medicine_tabcontrol.TabPages.Contains(medicine_add_tabpage))
                    {
                        medicine_tabcontrol.TabPages.Add(medicine_add_tabpage);
                    }
                    if (!medicine_tabcontrol.TabPages.Contains(medicine_delete_tabpage))
                    {
                        medicine_tabcontrol.TabPages.Add(medicine_delete_tabpage);
                    }
                }
                {
                    if (!compability_tabcontrol.TabPages.Contains(compability_add_tabpage))
                    {
                        compability_tabcontrol.TabPages.Add(compability_add_tabpage);
                    }
                    if (!compability_tabcontrol.TabPages.Contains(compability_delete_tabpage))
                    {
                        compability_tabcontrol.TabPages.Add(compability_delete_tabpage);
                    }
                }
                {
                    if (!medicalform_tabcontrol.TabPages.Contains(medicalform_add_tabpage))
                    {
                        medicalform_tabcontrol.TabPages.Add(medicalform_add_tabpage);
                    }
                    if (!medicalform_tabcontrol.TabPages.Contains(medicalform_delete_tabpage))
                    {
                        medicalform_tabcontrol.TabPages.Add(medicalform_delete_tabpage);
                    }
                }
                {
                    if (!activesubstance_tabcontrol.TabPages.Contains(activesubstance_add_tabpage))
                    {
                        activesubstance_tabcontrol.TabPages.Add(activesubstance_add_tabpage);
                    }
                    if (!activesubstance_tabcontrol.TabPages.Contains(activesubstance_delete_tabpage))
                    {
                        activesubstance_tabcontrol.TabPages.Add(activesubstance_delete_tabpage);
                    }
                }
            }
            else if (ConnectionDB.userName == "employee")
            {
                preparation_tabcontrol.TabPages.Remove(preparation_add_tabpage);
                preparation_tabcontrol.TabPages.Remove(preparation_delete_tabpage);
                disease_tabcontrol.TabPages.Remove(disease_add_tabpage);
                disease_tabcontrol.TabPages.Remove(disease_delete_tabpage);
                producer_tabcontrol.TabPages.Remove(producer_add_tabpage);
                producer_tabcontrol.TabPages.Remove(producer_delete_tabpage);
                license_tabcontrol.TabPages.Remove(license_add_tabpage);
                license_tabcontrol.TabPages.Remove(license_delete_tabpage);
                recipe_tabcontrol.TabPages.Remove(recipe_add_tabpage);
                recipe_tabcontrol.TabPages.Remove(recipe_delete_tabpage);
                medicine_tabcontrol.TabPages.Remove(medicine_add_tabpage);
                medicine_tabcontrol.TabPages.Remove(medicine_delete_tabpage);
                compability_tabcontrol.TabPages.Remove(compability_add_tabpage);
                compability_tabcontrol.TabPages.Remove(compability_delete_tabpage);
                medicalform_tabcontrol.TabPages.Remove(medicalform_add_tabpage);
                medicalform_tabcontrol.TabPages.Remove(medicalform_delete_tabpage);
                activesubstance_tabcontrol.TabPages.Remove(activesubstance_add_tabpage);
                activesubstance_tabcontrol.TabPages.Remove(activesubstance_delete_tabpage);
            }
            this.report_preparation.RefreshReport();
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
            MySqlCommand command = new MySqlCommand("SELECT ID_license,Register,License_date FROM license", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                license_show_infogrid.Rows.Add(reader[0], reader[1], Convert.ToDateTime(reader[2]).ToString("yyyy-MM-dd"));
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
            compability_add_preparation_combobox_Click(new object(), new EventArgs());
            compability_add_disease_combobox_Click(new object(), new EventArgs());
        }
        private void compaility_tabcontrol_Click(object sender, EventArgs e)
        {
            CompabilityCheck();
        }


        private void compability_add_preparation_combobox_Click(object sender, EventArgs e)
        {
            try
            {
                compability_add_preparation_combobox.Items.Clear();
                MySqlCommand command_preparation = new MySqlCommand($"SELECT ID_preparation,Preparation_name FROM preparation", ConnectionDB.conn);
                MySqlDataReader reader_preparation = command_preparation.ExecuteReader();

                while (reader_preparation.Read())
                {
                    compability_add_preparation_combobox.Items.Add($"{reader_preparation[0]}|{reader_preparation[1]}");
                }
                reader_preparation.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void compability_add_disease_combobox_Click(object sender, EventArgs e)
        {
            try
            {
                compability_add_disease_combobox.Items.Clear();
                MySqlCommand command_disease = new MySqlCommand($"SELECT id_disease,Disease_name FROM disease", ConnectionDB.conn);
                MySqlDataReader reader_disease = command_disease.ExecuteReader();

                while (reader_disease.Read())
                {
                    compability_add_disease_combobox.Items.Add($"{reader_disease[0]}|{reader_disease[1]}");
                }
                reader_disease.Close();
               
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void compability_add_button_Click(object sender, EventArgs e)
        {
            //TODO
            try
            {
                if (compability_add_disease_combobox.SelectedItem.ToString() != "" && compability_add_preparation_combobox.SelectedItem.ToString() != "")
                {
                    string id_disease = compability_add_disease_combobox.SelectedItem.ToString().Split('|')[0];
                    string id_preparation = compability_add_preparation_combobox.SelectedItem.ToString().Split('|')[0];
                    MySqlCommand add_compability = new MySqlCommand($"INSERT INTO compatibility (id_disease,id_preparation) VALUES ('{id_disease}','{id_preparation}')", ConnectionDB.conn);
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

        private void medicine_add_producername_combobox_Click(object sender, EventArgs e)
        {
            medicine_add_producername_combobox.Items.Clear();
            MySqlCommand command_producer = new MySqlCommand("Select Brand_name FROM producer", ConnectionDB.conn);
            MySqlDataReader reader_producer = command_producer.ExecuteReader();
            while (reader_producer.Read())
            {
                medicine_add_producername_combobox.Items.Add(reader_producer[0]);
            }
            reader_producer.Close();
        }
        private void medicine_add_preparation_combobox_Click(object sender, EventArgs e)
        {
            medicine_add_preparation_combobox.Items.Clear();
            MySqlCommand command_preparation = new MySqlCommand("Select Preparation_name FROM Preparation", ConnectionDB.conn);
            MySqlDataReader reader_preparation = command_preparation.ExecuteReader();
            while (reader_preparation.Read())
            {
                medicine_add_preparation_combobox.Items.Add(reader_preparation[0]);
            }
            reader_preparation.Close();
        }

        private void medicine_add_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (medicine_add_producername_combobox.SelectedItem.ToString() != "" && medicine_add_preparation_combobox.SelectedItem.ToString() != "")
                {
                    MySqlCommand command_producer = new MySqlCommand($"SELECT id_producer FROM producer WHERE Brand_name='{medicine_add_producername_combobox.SelectedItem}'", ConnectionDB.conn);
                    string id_producer = command_producer.ExecuteScalar().ToString();
                    MySqlCommand command_preparation = new MySqlCommand($"SELECT id_preparation FROM preparation WHERE preparation_name='{medicine_add_preparation_combobox.SelectedItem}'", ConnectionDB.conn);
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



        private void GetActiveSubstance()
        {
            recipe_add_substance1_name_combobox_Click(new object(), new EventArgs());
            recipe_add_substance2_name_combobox_Click(new object(), new EventArgs());
            recipe_add_substance3_name_combobox_Click(new object(), new EventArgs());
        }
        private void recipe_add_substance1_name_combobox_Click(object sender, EventArgs e)
        {
            recipe_add_substance1_name_combobox.Items.Clear();

            MySqlCommand command = new MySqlCommand("SELECT Substance_name FROM active_substance", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                recipe_add_substance1_name_combobox.Items.Add(reader[0]);

            }
            reader.Close();
        }
        private void recipe_add_substance2_name_combobox_Click(object sender, EventArgs e)
        {
            recipe_add_substance2_name_combobox.Items.Clear();

            MySqlCommand command = new MySqlCommand("SELECT Substance_name FROM active_substance", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                recipe_add_substance2_name_combobox.Items.Add(reader[0]);

            }
            reader.Close();
        }
        private void recipe_add_substance3_name_combobox_Click(object sender, EventArgs e)
        {
            recipe_add_substance3_name_combobox.Items.Clear();

            MySqlCommand command = new MySqlCommand("SELECT Substance_name FROM active_substance", ConnectionDB.conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                recipe_add_substance3_name_combobox.Items.Add(reader[0]);
            }
            reader.Close();
        }
        private void recipe_find_button_Click(object sender, EventArgs e)
        {
            recipe_find_infogrid.Rows.Clear();
            string substance_name = recipe_find_textbox.Text;
            if (substance_name != "")
            {
                MySqlCommand command = new MySqlCommand("SELECT Substance_name1,Substance_name2,Substance_name3,Quantity FROM " +
                    $"recipe_view WHERE Substance_name1 LIKE '%{substance_name}%' OR Substance_name2 LIKE '%{substance_name}%'" +
                    $"OR Substance_name3 LIKE '%{substance_name}%'", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    recipe_find_infogrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                reader.Close();
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void license_find_button_Click(object sender, EventArgs e)
        {
            license_find_infogrid.Rows.Clear();
            string name = license_find_textbox.Text;
            if (name != "")
            {
                MySqlCommand command = new MySqlCommand("SELECT id_license,Register,License_date FROM license WHERE " +
                    $"Register LIKE '%{name}%'", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    license_find_infogrid.Rows.Add(reader[0], reader[1], Convert.ToDateTime(reader[2]).ToString("yyyy-MM-dd"));
                }
                reader.Close();
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void license_add_button_Click(object sender, EventArgs e)
        {
            string register = license_add_register_textbox.Text;
            DateTime date = license_add_date_datatime.Value.ToUniversalTime();
            if (register != "")
            {
                try
                {
                    MySqlCommand command = new MySqlCommand($"CALL add_license('{register}','{date.ToString("yyyy-MM-dd")}')", ConnectionDB.conn);
                    command.ExecuteNonQuery();
                }
                catch(Exception ex) { 
                    MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            license_add_register_textbox.Text = "";
        }

        private void producer_find_button_Click(object sender, EventArgs e)
        {
            producer_find_infogrid.Rows.Clear();
            string name = producer_find_textbox.Text;
            if (name != "")
            {
                MySqlCommand command = new MySqlCommand($"SELECT ID_producer,Brand_name,Phone_producer,Address FROM producer WHERE Brand_name LIKE '%{name}%' OR Phone_producer LIKE '%{name}%' OR Address Like '%{name}%'", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    producer_find_infogrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                reader.Close();
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
            producer_find_textbox.Text = "";

        }

        private void producer_add_button_Click(object sender, EventArgs e)
        {
            string brand_name = producer_add_brandname_textbox.Text;
            string phone = producer_add_phone_textbox.Text;
            string address = producer_add_address_textbox.Text;
            if (brand_name != "" && phone != "" && address != "")
            {
                try
                {
                    MySqlCommand command = new MySqlCommand($"CALL add_producer('{brand_name}','{phone}','{address}')", ConnectionDB.conn);
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {   
                    MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            producer_add_address_textbox.Text = "";
            producer_add_brandname_textbox.Text = "";
            producer_add_phone_textbox.Text = "";
        }

        private void disease_find_button_Click(object sender, EventArgs e)
        {
            string name = disease_find_textbox.Text;
            disease_find_infogrid.Rows.Clear();
            if (name != "")
            {
                try {
                    MySqlCommand command = new MySqlCommand($"SELECT id_disease,Disease_name,Disease_descr FROM disease WHERE " +
                        $"Disease_name LIKE '%{name}%' OR Disease_descr LIKE '%{name}%'", ConnectionDB.conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        disease_find_infogrid.Rows.Add(reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            disease_find_textbox.Text = "";

        }

        private void disease_add_button_Click(object sender, EventArgs e)
        {
            string name = disease_add_diseasename_textbox.Text;
            string descr = disease_add_diseasedescr_textbox.Text;
            if (name != "" && descr != "")
            {
                try
                {
                    MySqlCommand command = new MySqlCommand($"CALL add_disease('{name}','{descr}')", ConnectionDB.conn);
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            disease_add_diseasename_textbox.Text = "";
            disease_add_diseasedescr_textbox.Text = "";
        }

        private void preparation_find_button_Click(object sender, EventArgs e)
        {
            preparation_show_infogrid.Rows.Clear();
            string name = preparation_find_NameOrForm_textbox.Text;
            string price = preparation_find_price_textbox.Text;
            if (name != "" && price != "")
            {
                MySqlCommand command = new MySqlCommand($"SELECT Preparation_name,Form_name,Brand_name,Price FROM preparation_view WHERE (Preparation_name LIKE '%{name}%' " +
                    $"OR Brand_name LIKE '%{name}%') AND (Price<={Convert.ToInt32(price) + 50} AND price>={Convert.ToInt32(price) - 50})", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    preparation_find_infogrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                reader.Close();
                preparation_find_NameOrForm_textbox.Text = "";
                preparation_find_price_textbox.Text = "";
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
  

        private void preparation_add_medicalform_combobox_Click(object sender, EventArgs e)
        {
            preparation_add_medicalform_combobox.Items.Clear();
            preparation_add_recipe_combobox.Items.Clear();
            preparation_add_license_combobox.Items.Clear();
            MySqlCommand command_medicalForm = new MySqlCommand("SELECT form_name FROM medical_form", ConnectionDB.conn);
            MySqlDataReader reader_medicalForm = command_medicalForm.ExecuteReader();
            while (reader_medicalForm.Read())
            {
                preparation_add_medicalform_combobox.Items.Add(reader_medicalForm[0]);
            }
            reader_medicalForm.Close();
        }
        private void preparation_add_recipe_combobox_Click(object sender, EventArgs e)
        {
            MySqlCommand command_recipe = new MySqlCommand("SELECT id_recipe,Substance_name1,Substance_name2,	Substance_name3,Quantity FROM recipe_view", ConnectionDB.conn);
            MySqlDataReader reader_recipe = command_recipe.ExecuteReader();
            while (reader_recipe.Read())
            {
                preparation_add_recipe_combobox.Items.Add($"{reader_recipe[0]}|{reader_recipe[1]}|{reader_recipe[2]}|{reader_recipe[3]}|{reader_recipe[4]}");
            }
            reader_recipe.Close();
        }
        private void preparation_add_license_combobox_Click(object sender, EventArgs e)
        {
            MySqlCommand command_license = new MySqlCommand("SELECT ID_license,Register,License_date FROM license", ConnectionDB.conn);
            MySqlDataReader reader_license = command_license.ExecuteReader();
            while (reader_license.Read())
            {
                preparation_add_license_combobox.Items.Add($"{reader_license[0]}|{reader_license[1]}|{Convert.ToDateTime(reader_license[2]).ToString("yyyy-MM-dd")}");
            }
            reader_license.Close();
        }

        private void preparation_add_button_Click(object sender, EventArgs e)
        {
            string preparation_name = preparation_add_PreparationName_textbox.Text;
            string preparation_descr = preparation_add_Preparationdescr_textbox.Text;
            string expiration_date = preparation_add_expirationDate_dateTime.Value.ToString("yyyy-MM-dd");
            string medical_form = preparation_add_medicalform_combobox.SelectedItem.ToString(); 
            string recipe_id = preparation_add_recipe_combobox.SelectedItem.ToString().Split('|')[0]; 
            string license_id = preparation_add_license_combobox.SelectedItem.ToString().Split('|')[0];
            string price = preparation_add_price_textbox.Text;
            if (preparation_name != "" && preparation_descr != "" && medical_form != "" && recipe_id != "" && license_id != "" && price != "")
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO preparation (Preparation_name,Preparation_descr,Price,Expiration_date,ID_form," +
                    $"ID_recipe,ID_license) VALUES ('{preparation_name}','{preparation_descr}',{Convert.ToDouble(price)},'{expiration_date}',(SELECT ID_form from medical_form WHERE Form_name='{medical_form}'),{Convert.ToInt32(recipe_id)},{Convert.ToInt32(license_id)})", ConnectionDB.conn);
                command.ExecuteNonQuery();
                preparation_add_Preparationdescr_textbox.Text = "";
                preparation_add_Preparationdescr_textbox.Text = "";
                preparation_add_price_textbox.Text = "";
            }
            else
            {
                MetroMessageBox.Show(this, $"Field is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void preparation_delete_information_combobox_Click(object sender, EventArgs e)
        {
            preparation_delete_information_combobox.Items.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT ID_preparation,Preparation_name,Preparation_descr,Form_name,Brand_name,Price,Expiration_date,Substance_name1,Substance_name2,Substance_name3,Quantity,Register,License_date FROM preparation_view", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string id_preparation = reader[0].ToString();
                    string preparation_name = reader[1].ToString();
                    //string preparation_descr = reader[2].ToString();
                    string name_form = reader[3].ToString();
                    string brand_name = reader[4].ToString();
                    string price = reader[5].ToString();
                    string Expiration_date = reader[6].ToString();
                    //string name_recipe = "{reader[7].ToString()}|{reader[8].ToString()}|{reader[9].ToString()}";
                    string name_license = reader[11].ToString();
                    string date_license = reader[12].ToString();
                    preparation_delete_information_combobox.Items.Add($"{id_preparation}|{preparation_name}|{name_form}|{price}|{Convert.ToDateTime(Expiration_date).ToString("yyyy-MM-dd")}|{name_license}|{brand_name}");

                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void Preparation_delete_button_Click(object sender, EventArgs e)
        {

            string id_preparation = preparation_delete_information_combobox.SelectedItem.ToString().Split('|')[0];
            try
            {
                //try
                //{
                //    MySqlCommand command = new MySqlCommand($"DELETE FROM compatibility WHERE ID_preparation={id_preparation}", ConnectionDB.conn);
                //    command.ExecuteNonQuery();
                //}
                //catch
                //{

                //}
                //try
                //{
                //    MySqlCommand command = new MySqlCommand($"DELETE FROM medicine WHERE ID_preparation={id_preparation}", ConnectionDB.conn);
                //    command.ExecuteNonQuery();
                //}
                //catch
                //{

                //}
                //try
                //{
                    MySqlCommand command = new MySqlCommand($"DELETE FROM preparation WHERE ID_preparation={id_preparation}", ConnectionDB.conn);
                    command.ExecuteNonQuery();
                //}
                //catch { 
                    
                //}

                MetroMessageBox.Show(this, $"Successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }

        private void disease_delete_combobox_Click(object sender, EventArgs e)
        {
            try
            {
                disease_delete_combobox.Items.Clear();
                MySqlCommand command = new MySqlCommand("SELECT id_disease,Disease_name FROM disease", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    disease_delete_combobox.Items.Add($"{reader[0]}|{reader[1]}");
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void disease_delete_button_Click(object sender, EventArgs e)
        {
            string disease_id = disease_delete_combobox.SelectedItem.ToString().Split('|')[0];
            try
            {
                MySqlCommand command = new MySqlCommand($"DELETE FROM disease WHERE id_disease={disease_id}", ConnectionDB.conn);
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void producer_delete_button_Click(object sender, EventArgs e)
        {
            string id_producer = producer_delete_combobox.SelectedItem.ToString().Split('|')[0];
            try
            {
                MySqlCommand command = new MySqlCommand($"DELETE from producer WHERE id_producer={id_producer}",ConnectionDB.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void producer_delete_combobox_Click(object sender, EventArgs e)
        {
            producer_delete_combobox.Items.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT id_producer,Brand_name,Phone_Producer FROM producer", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    producer_delete_combobox.Items.Add($"{reader[0]}|{reader[1]}|{reader[2]}");
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void license_delete_combobox_Click(object sender, EventArgs e)
        {
            license_delete_combobox.Items.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT ID_license,Register,License_date FROM license", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    license_delete_combobox.Items.Add($"{reader[0]}|{reader[1]}|{reader[2]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void license_delete_button_Click(object sender, EventArgs e)
        {
            string ID_license = license_delete_combobox.SelectedItem.ToString().Split('|')[0];
            try
            {
                MySqlCommand command = new MySqlCommand($"DELETE from license WHERE ID_license={ID_license}", ConnectionDB.conn);
                command.ExecuteNonQuery();
                license_delete_combobox_Click(new object(), new EventArgs());
                MetroMessageBox.Show(this, $"Successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void recipe_delete_button_Click(object sender, EventArgs e)
        {
            string recipe_id = recipe_delete_combobox.SelectedItem.ToString().Split('|')[0];
            try
            {
                MySqlCommand command = new MySqlCommand($"DELETE from recipe WHERE ID_recipe={recipe_id}", ConnectionDB.conn);
                command.ExecuteNonQuery();
                recipe_delete_combobox_Click(new object(), new EventArgs());
                MetroMessageBox.Show(this, $"Successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void recipe_delete_combobox_Click(object sender, EventArgs e)
        {
            recipe_delete_combobox.Items.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT id_recipe,Substance_name1,Substance_name2,Substance_name3,Quantity FROM recipe_view", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    recipe_delete_combobox.Items.Add($"{reader[0]}|{reader[1]}|{reader[2]}|{reader[3]}|{reader[4]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void medicine_delete_button_Click(object sender, EventArgs e)
        {
            string brand_name = medicine_delete_combobox.SelectedItem.ToString().Split('|')[0];
            string preparation_name = medicine_delete_combobox.SelectedItem.ToString().Split('|')[1];
            try
            {
                MySqlCommand command = new MySqlCommand($"DELETE from medicine WHERE ID_producer=(SELECT ID_producer FROM producer WHERE Brand_name='{brand_name}') AND ID_preparation=(SELECT ID_preparation FROM Preparation WHERE Preparation_name='{preparation_name}')", ConnectionDB.conn);
                command.ExecuteNonQuery();
                medicine_delete_combobox_Click(new object(), new EventArgs());
                MetroMessageBox.Show(this, $"Successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void medicine_delete_combobox_Click(object sender, EventArgs e)
        {
            medicine_delete_combobox.Items.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT Brand_Name,Preparation_name FROM medicine_view", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    medicine_delete_combobox.Items.Add($"{reader[0]}|{reader[1]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void compability_delete_combobox_Click(object sender, EventArgs e)
        {
            compability_delete_combobox.Items.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT id_disease,Disease_name,id_preparation,Preparation_name FROM compatibility_view", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    compability_delete_combobox.Items.Add($"{reader[0]}|{reader[1]}|{reader[2]}|{reader[3]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void compability_delete_button_Click(object sender, EventArgs e)
        {
            string id_disease = compability_delete_combobox.SelectedItem.ToString().Split('|')[0];
            string id_preparation = compability_delete_combobox.SelectedItem.ToString().Split('|')[2];
            try
            {
                MySqlCommand command = new MySqlCommand($"DELETE from compatibility WHERE id_disease='{id_disease}' AND ID_preparation='{id_preparation}'", ConnectionDB.conn);
                command.ExecuteNonQuery();
                compability_delete_combobox_Click(new object(), new EventArgs());
                MetroMessageBox.Show(this, $"Successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void medicalForm_delete_combobox_Click(object sender, EventArgs e)
        {
            medicalForm_delete_combobox.Items.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT ID_form,Form_name FROM medical_form", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    medicalForm_delete_combobox.Items.Add($"{reader[0]}|{reader[1]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void medicalForm_delete_button_Click(object sender, EventArgs e)
        {
            string id_form = medicalForm_delete_combobox.SelectedItem.ToString().Split('|')[0];
            try
            {
                MySqlCommand command = new MySqlCommand($"DELETE from medical_form WHERE ID_form='{id_form}'", ConnectionDB.conn);
                command.ExecuteNonQuery();
                medicalForm_delete_combobox_Click(new object(), new EventArgs());
                MetroMessageBox.Show(this, $"Successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void activesubstance_delete_button_Click(object sender, EventArgs e)
        {
            string ID_substance = medicalForm_delete_combobox.SelectedItem.ToString().Split('|')[0];
            try
            {
                MySqlCommand command = new MySqlCommand($"DELETE from active_substance WHERE ID_substance='{ID_substance}'", ConnectionDB.conn);
                command.ExecuteNonQuery();
                activesubstance_delete_combobox_Click(new object(), new EventArgs());
                MetroMessageBox.Show(this, $"Successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void activesubstance_delete_combobox_Click(object sender, EventArgs e)
        {
            activesubstance_delete_combobox.Items.Clear();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT ID_substance,Substance_name FROM active_substance", ConnectionDB.conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    activesubstance_delete_combobox.Items.Add($"{reader[0]}|{reader[1]}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

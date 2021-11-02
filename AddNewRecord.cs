using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentSessionTry
{
    public partial class AddNewRecord : Form
    {
        public AddNewRecord()
        {
            InitializeComponent();
        }

        private void addnewrecordButton_Click(object sender, EventArgs e)
        {
            String query = "call sp_InsertIntoSessionStudent ('" + quickmathBox.Text + "','" + infBox.Text + "','" + phyBox.Text + "','" +  FIOBox.Text + "', '" + numgroupBox.Text + "', '" + yearstBox.Text + "','" + numZBox.Text + "')";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            MySqlDataReader rd;
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления");
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

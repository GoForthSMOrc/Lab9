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
    public partial class RefreshRecord : Form
    {
        public RefreshRecord()
        {
            InitializeComponent();
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            String query = "call sp_UpdateSessionStudents('"+ idBox.Text +"','" + NumBookBox.Text +"','" + NameStudentBox.Text +"','" + GroupStudentBox.Text +"','" + YearStBox.Text +"','" + mathBox.Text +"','" + infBox.Text +"','" + phyBox.Text +"')";
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
                MessageBox.Show("Ошибка обновления записи");
                MessageBox.Show(ex.Message);
            }
        }
    }
}

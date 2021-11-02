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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            getInfo(listView1);
        }

        //Получение информации из базы данных при входе в главное меню//
        void getInfo(ListView list)
        {
            String query = "Select Student.Id_Student,Student.NumBook,Student.NameStudent,Student.GroupStudent,Student.YearSt,Session.Mathematics,Session.Informatics,Session.Phylosophy from Student join Session on Session.Id_Session = Student.id_Session";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            MySqlDataReader rd;
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(6), rd.GetString(7) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка вывода информации из базы данных");
                MessageBox.Show(ex.Message);
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewRecord win = new AddNewRecord();
            win.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            String query = "Delete from Student where Id_Student = '" + deleteBox.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDBW = new MySqlCommand(query, conn);
            MySqlDataReader rd;
            try
            {
                conn.Open();
                rd = cmDBW.ExecuteReader();
                getInfo(listView1);
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка. Попробуйте еще раз");
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshlistButton_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            getInfo(listView1);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshRecord win = new RefreshRecord();
            win.Show();
        }
        
    }
}

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

namespace Lecture_Seri
{
    public partial class UniversityScreen : Form
    {
        public UniversityScreen()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        MySqlCommand cmd;

        private void sqlConn()
        {
            string server = "localhost";
            string database = "lecture_seri";
            string username = "root";
            string password = "pass@123";
            string port = "3306";

            string conString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "USER=" + username + ";" + "PASSWORD=" + password + ";";

            conn = new MySqlConnection(conString);
            conn.Open();
        }

        private void addGrade()
        {
            if(GradeTxt.Text !=null && locationTxt.Text != null)
            {

                GradeView.ColumnCount = 3;
                string[] row = new string[] { GradeTxt.Text, locationTxt.Text, "Delete" };
                GradeView.Rows.Add(row); 
                GradeView.Refresh();


            }

        }

        private void loadUniData()
        {

        }



        
        private void button2_Click(object sender, EventArgs e)
        {
          

        }

        private void UniversityScreen_Load(object sender, EventArgs e)
        {
            sqlConn();
            movingPanel.Width = 0;
            GradeView.ColumnCount = 3;
            durationCombo.SelectedIndex = 0;
            string[] row = new string[] { "Grade", "Credit", "Action" };
            GradeView.Rows.Add(row);
        }

        private void GradeView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete this grade?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //delete row from database or datagridview...
                    GradeView.Rows.RemoveAt(e.RowIndex);
                }
                else if (dr == DialogResult.No)
                {
                    //Nothing to do
                }
            }
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            movingPanel.Width = 568;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            movingPanel.Width = 0;
        }

        private void addGradeBtn_Click(object sender, EventArgs e)
        {
            addGrade();
        }
    }
}

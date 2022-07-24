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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

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
        MySqlDataReader reader;

        List<string> uniList = new List<string>();
        List<string> uniIdList = new List<string>();

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
                string[] row = new string[] { GradeTxt.Text, creditTxt.Text, "Delete" };
                GradeView.Rows.Add(row); 
                GradeView.Refresh();

                GradeTxt.Text = "";
                creditTxt.Text = "";

            }

        }

        private void loadUniData()
        {
            string query = "select * from University;";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
           

            uniCombo.Items.Clear();
            while (reader.Read())
            {
                uniIdList.Add(reader.GetString(0));
                uniList.Add(reader.GetString(1));
                uniCombo.Items.Add(reader.GetString(1));

            }

            reader.Close();
            uniCombo.SelectedIndex = 0;
           // uniCombo.Items.Add(uniList);


        }

        private void saveEnrollData()
        {
            int duration = durationCombo.SelectedIndex + 1;
            string query = "Insert Into Enroll (user_id, uni_id,index_no, degree, faculty, duration, location)" +
             "values ('" + userSettings.Default.id + "', '" + uniIdList[uniCombo.SelectedIndex] + "', '" + indexTxt.Text + "', '" + degreeTxt.Text + "', '" + facTxt.Text + "', '" +
             duration + "', '" + locationTxt.Text + "');";

            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        private int getEnrollID()
        {
            int eid = 0;
            string query = "select * from University;";
            cmd = new MySqlCommand(query, conn);
            reader.Close();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                eid++;
            }
            reader.Close();
            return eid;
        }

        private void saveGrades()
        {
            MessageBox.Show(GradeView.Rows[1].Cells[1].Value.ToString());
            string query = "Insert Into Grade (enroll_id, grade, credit)";
            string values = "Values ('"+getEnrollID()+"', '" +GradeView.Rows[1].Cells[0].Value.ToString() + "', '" + (float)Convert.ToDouble(GradeView.Rows[1].Cells[1].Value.ToString()) + "')";
            int rc = GradeView.RowCount;
            for (int i = 2; i < rc; i++)
            {
              values = values +  " ,('" + getEnrollID() + "', '" + GradeView.Rows[i].Cells[0].Value.ToString() + "', '" + (float)Convert.ToDouble(GradeView.Rows[i].Cells[1].Value.ToString()) + "')";

            }
            cmd = new MySqlCommand(query+" "+ values, conn);
            cmd.ExecuteNonQuery();
        }
        private string uniID()
        {
            return "U0001";
        }
        private void saveUniSettings()
        {
            uniSettings.Default.uniID = uniID();
            uniSettings.Default.uniName = uniCombo.SelectedItem.ToString();
            uniSettings.Default.location = locationTxt.Text;
            uniSettings.Default.Save();
        }
        private void generateFolders()
        {
            string[] paths = { locationTxt.Text,uniCombo.SelectedItem.ToString() };
            string path = Path.Combine(paths);

            MessageBox.Show(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                for (int i = 1; i <= durationCombo.SelectedIndex+1; i++)
                {
                    string tempPath = "L" + i + "S" + 1;
                    string[] tempPaths = {path,tempPath };
                    Directory.CreateDirectory(Path.Combine(tempPaths));

                    string tempPath2 = "L" + i + "S" + 2;
                    string[] tempPaths2 = { path, tempPath2 };
                    Directory.CreateDirectory(Path.Combine(tempPaths2));
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
          /*  CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                locationTxt.Text = dialog.FileName;
               // MessageBox.Show("You selected: " + dialog.FileName);
            }*/

            FolderBrowserDialog folder = new FolderBrowserDialog();

            //folder.RootFolder = Environment.SpecialFolder.MyDocuments;

           // folder.ShowDialog();
           if(folder.ShowDialog() == DialogResult.OK)
            {
                locationTxt.Text = folder.SelectedPath;
            }

        }

        private void UniversityScreen_Load(object sender, EventArgs e)
        {
            sqlConn();
            loadUniData();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //saveEnrollData();
            //saveGrades();
            saveUniSettings();
            generateFolders();
            this.Close();
        }
    }
}

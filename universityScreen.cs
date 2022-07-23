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

        

        private void addGrade()
        {
            if(GradeTxt.Text !=null && creditTxt.Text != null)
            {

                GradeView.ColumnCount = 3;
                string[] row = new string[] { GradeTxt.Text, creditTxt.Text, "Delete" };
                GradeView.Rows.Add(row); 
                GradeView.Refresh();


            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            addGrade();

        }

        private void UniversityScreen_Load(object sender, EventArgs e)
        {
            GradeView.ColumnCount = 3;
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
    }
}

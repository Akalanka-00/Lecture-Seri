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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        
        private void newCourse()
        {
            newCourseScreen ncs = new newCourseScreen();
            ncs.Show();
        }

        private void newLectureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newCourse();
        }
    }
}

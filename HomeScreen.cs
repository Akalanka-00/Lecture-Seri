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

        private void newNote()
        {
            addNoteScreen ans = new addNoteScreen();
            ans.Show();
        }

        private void newReference()
        {
            addReferencesScreen arf = new addReferencesScreen();
            arf.Show();
        }

        private void newRecord()
        {
            recordingScreen rs = new recordingScreen();
            rs.Show();
        }

        private void newLectureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newCourse();
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newNote();
        }

        private void lectureReferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newReference();
        }

        private void recordingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newRecord();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

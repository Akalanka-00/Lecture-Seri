using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void addUni()
        {
            UniversityScreen us = new UniversityScreen();
            us.Show();
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

        private void signIn()
        {
            signInScreen sis = new signInScreen();
            sis.Show();
        }

        public Image byteArrayToImage(byte[] source)
        {
            MemoryStream ms = new MemoryStream(source);
            Image ret = Image.FromStream(ms);
            return ret;
        }

        private void loadAvatar()
        {
            Image img;
            byte[] imageArray;
            String avatarTxt = userSettings.Default.Avatar;
           if(avatarTxt != "")
            {
                imageArray = Convert.FromBase64String(avatarTxt);
                img = byteArrayToImage(imageArray);
                avatarShape.Image = img;
            }
            else
            {
                
            }
          

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

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            lvlComboBox.SelectedIndex = 0;
            materialSelectBox.SelectedIndex = 0;
            loadAvatar();

            if (userSettings.Default.access == false)
            {
                signIn();
            }
        }

        private void SignInToolBtn_Click(object sender, EventArgs e)
        {
            signIn();
        }

        private void exitToolBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeScreen_Activated(object sender, EventArgs e)
        {
            loadAvatar();
        }

        private void addUniversityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUni();
        }

        private void avatarShape_Click(object sender, EventArgs e)
        {
            userSettings.Default.access = false;
            userSettings.Default.Save();
        }
    }
}
